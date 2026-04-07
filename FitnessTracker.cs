using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection.Metadata;

namespace FitnessTracker
{
    public class FitnessTrackerManager
    {
        private List<RegisteredUser> users;
        private List<Activity> activities;
        private RegisteredUser currentUser;
        private string usersFilePath;

        public FitnessTrackerManager()
        {
            users = new List<RegisteredUser>();
            activities = new List<Activity>();
            currentUser = null;
            usersFilePath = "users.txt";

            LoadUsersFromFile();
        }

        public RegisteredUser CurrentUser
        {
            get { return currentUser; }
        }

        public List<Activity> Activities
        {
            get { return activities; }
        }

        public string RegisterUser(string username, string password)
        {
            if (!User.IsValidUsername(username))
                return "Invalid username. Only letters and numbers are allowed.";

            if (!User.IsValidPassword(password))
                return "Invalid password. Must be exactly 12 characters with " + "at least one uppercase and one lowercase letter.";
            
            if (FindUser(username) != null)
                return "Username already exists. Please choose a different username.";

            RegisteredUser newUser = new RegisteredUser(username, password);
            users.Add(newUser);

            SaveUsersToFile();

            return "Registration successful. You can now log in.";
        }

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
                return "Login successful.";
            }
            else
            {
                if (user.IsLocked)
                    return "Incorrect password. Account is not locked.";
                    
                    return $"Incorrect password. " + $"{user.RemainingAttempts()} attempt(s) remaining.";
            }
        }

        public void LogoutUser()
        {
            currentUser = null;
            activities = new List<Activity>();
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

        public string SetGoal(double goalCalories)
        {
            if (currentUser == null)
                return "No user is logged in.";
            
            if (goalCalories <= 0)
                return "Goal must be a positive number.";

            currentUser.GoalCalories = goalCalories;

            SaveUsersToFile();

            return $"Goal set to {goalCalories} calories successfully.";
        }

        public string AddActivity(Activity activity)
        {
            if (currentUser == null)
                return "No user is logged in.";
            
            if (!activity.AreMetricsValid())
                return "All metric values must be greater than zero.";
            
            activities.Add(activity);
            return $"{activity.ActivityName} recorded successfully.";
        }

        public void ClearActivities()
        {
            activities = new List<Activity>();
        }

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
        
            string summary = $"User: {currentUser.Username}\n";
            summary += $"Goal: {goal:F2} calories\n";
            summary += $"Total Burned: {total:F2} calories\n";
            summary += $"Status: {achieved}\n\n";
            summary += "Activities:\n";

            for (int i = 0; i < activities.Count; i++)
                summary += $" - {activities[i].GetSummary()}\n";
            
            return summary;
        }

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
    }
}