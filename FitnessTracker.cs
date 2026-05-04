using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection.Metadata;
using Newtonsoft.Json;

namespace FitnessTracker
{
    // Manager class coordinates users and activities
    // Handles file storage and retrieval
    // Uses List<> to store users and activities
    public class FitnessTrackerManager
    {
        private List<RegisteredUser> users;
        private List<Activity> activities;
        private RegisteredUser currentUser;
        private string usersFilePath;
        private string activitiesFilePath;
        private List<ActivityRecord> activityHistory;

        public RegisteredUser CurrentUser
        {
            get { return currentUser; }
        }

        public List<Activity> Activities
        {
            get { return activities; }
        }

        public FitnessTrackerManager()
        {
            users = new List<RegisteredUser>();
            activities = new List<Activity>();
            activityHistory = new List<ActivityRecord>();
            currentUser = null;
            usersFilePath = "users.txt";
            activitiesFilePath = "activities.json";

            LoadUsersFromFile();
        }

        // Registers a new user after validating username and password
        public string RegisterUser(string username, string password)
        {
            if (!User.IsValidUsername(username))
                return "Invalid username. Only letters and numbers are allowed.";

            if (!User.IsValidPassword(password))
                return "Invalid password: must be 12 chars with\nat least 1 uppercase and 1 lowercase.";
            
            if (FindUser(username) != null)
                return "Username already exists. Please choose a different username.";

            RegisteredUser newUser = new RegisteredUser(username, password);
            users.Add(newUser);

            SaveUsersToFile();

            return "Registration successful. You can now log in.";
        }

        // Attempts to log in with provided credentials
        public string LoginUser(string username, string password)
        {
            RegisteredUser user = FindUser(username);
            if (user == null)
                return "Username not found. Please register first.";

            if (user.IsLocked)
                return "Account is locked due to too many failed attempts. " + "Please restart the application to try again.";

            if (user.CheckPassword(password))
            {
                currentUser = user;
                activities = new List<Activity>();
                activityHistory = LoadActivityHistory(currentUser.Username);
                return "Login successful.";
            }
            else
            {
                if (user.IsLocked)
                    return "Incorrect password. Account is now locked.";
                    
                    return $"Incorrect password. " + $"{user.RemainingAttempts()} attempt(s) remaining.";
            }
        }

        public void LogoutUser()
        {
            currentUser = null;
            activities = new List<Activity>();
            activityHistory = new List<ActivityRecord>();
        }

        private RegisteredUser FindUser(string username)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Username.ToLower() == username.ToLower())
                    return users[i];
            }
            return null;
        }

        // Goal Management: Sets a calorie goal for the current user
        public string SetGoal(double goalCalories)
        {
            if (currentUser == null)
                return "No user is logged in.";
            
            if (goalCalories <= 0)
                return "Goal must be a positive number.";

            currentUser.GoalCalories = goalCalories;

            SaveUsersToFile();

            return $"Goal set to {goalCalories} kcal successfully.";
        }

        // Activity Management: Adds a new activity for the current user after validating metrics
        public string AddActivity(Activity activity)
        {
            if (currentUser == null)
                return "No user is logged in.";
            
            if (!activity.AreMetricsValid())
                return "All metric values must be greater than zero.";
            
            activities.Add(activity);

            ActivityRecord record = new ActivityRecord(currentUser.Username, activity);
            activityHistory.Add(record);
            SaveActivityHistory();

            return $"{activity.ActivityName} recorded successfully.";
        }

        public void ClearActivities()
        {
            activities = new List<Activity>();
        }

        // Calorie Calculations: Sums calories from all activities to get total calories burned
        public double CalculateTotalCalories()
        {
            double total = 0;

            for (int i = 0; i < activities.Count; i++)
                total += activities[i].CalculateCalories();
            return total;
        }

        public bool HasAchievedGoal()
        {
            if (currentUser == null || currentUser.GoalCalories <= 0)
                return false;
            
            return CalculateTotalCalories() >= currentUser.GoalCalories;
        }

        public string GetProgressSummary()
        {
            if (currentUser == null)
                return "No user is logged in.";
            
            double total = CalculateTotalCalories();
            double goal = currentUser.GoalCalories;
            string achieved = HasAchievedGoal() ? "✓ Goal Achieved." : "✗ Goal Not Yet Achieved.";
        
            string nl = "\r\n";

            string summary = $"User: {currentUser.Username}" + nl;
            summary += $"Goal: {goal:F2} kcal" + nl;
            summary += $"Total Burned: {total:F2} kcal" + nl;
            summary += $"Status: {achieved}" + nl + nl;
            summary += nl;
            summary += "─────────────────────────────────" + nl;
            summary += "Activities:" + nl;
            summary += "─────────────────────────────────" + nl;

            for (int i = 0; i < activities.Count; i++)
                summary += $" - {activities[i].GetSummary()}" + nl;
            
            summary += "─────────────────────────────────" + nl;
            return summary;
        }

        // File IO: Saves and loads user data to/from a text file
        private void SaveUsersToFile()
        {
            try
            {
                StreamWriter writer = new StreamWriter(usersFilePath, false);

                for (int i = 0; i < users.Count; i++)
                    writer.WriteLine(users[i].ToFileString());
                
                writer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving users: " + ex.Message);
            }
        }

        private void LoadUsersFromFile()
        {
            if (!File.Exists(usersFilePath))
                return;
            
            try
            {
                StreamReader reader = new StreamReader(usersFilePath);
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;
                    
                    RegisteredUser user = RegisteredUser.FromFileString(line);
                    users.Add(user);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading users: " + ex.Message);
            }
        }

        // JSON Activity History
        public List<ActivityRecord> GetActivityHistory()
        {
            return activityHistory;
        }

        private void SaveActivityHistory()
        {
            try
            {
                List<ActivityRecord> allRecords = new List<ActivityRecord>();

                if (File.Exists(activitiesFilePath))
                {
                    string existingJson = File.ReadAllText(activitiesFilePath);
                    allRecords = JsonConvert.DeserializeObject<List<ActivityRecord>>(existingJson) ?? new List<ActivityRecord>();
                }

                allRecords.RemoveAll(r => r.Username == currentUser.Username);
                allRecords.AddRange(activityHistory);

                string json = JsonConvert.SerializeObject(allRecords, Formatting.Indented);
                File.WriteAllText(activitiesFilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving activity history: " + ex.Message);
            }
        }

        private List<ActivityRecord> LoadActivityHistory(string username)
        {
            if (!File.Exists(activitiesFilePath))
                return new List<ActivityRecord>();
            
            try
            {
                string json = File.ReadAllText(activitiesFilePath);
                List<ActivityRecord> allRecords = JsonConvert.DeserializeObject<List<ActivityRecord>>(json) ?? new List<ActivityRecord>();
                
                List<ActivityRecord> userRecords = new List<ActivityRecord>();

                for (int i = 0; i < allRecords.Count; i++)
                {
                    if (allRecords[i].Username == username)
                        userRecords.Add(allRecords[i]);
                }

                return userRecords;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading activity history: " + ex.Message);
                return new List<ActivityRecord>();
            }
        }
    }
}