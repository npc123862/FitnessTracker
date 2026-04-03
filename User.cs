using System;
using System.Text.RegularExpressions;

namespace FitnessTracker
{
    public class User
    {
        private string username;
        private int password;
        private double goalCalories;

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
            this.goalCalories = 0;
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public double GoalCalories
        {
            get { return goalCalories; }
            set { goalCalories = value; }
        }

        public static bool IsValidUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
                return false;
            
            return Regex.IsMatch(username, @"^[a-zA-Z0-9]+$");
        }

        public static bool IsValidPassword(string password)
        {
            if (password == null || password.Length != 12)
                return false;

            bool hasUpper = false;
            bool hasLower = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpper = true;
                if (char.IsLower(c)) hasLower = true;
            }

            return hasUpper && hasLower;
        }

        public virtual bool CheckPassword(string inputPassword)
        {
            return password == inputPassword;
        }

        public virtual string ToFileString()
        {
            return $"{username}|{password}|{goalCalories}";
        }
    }
}