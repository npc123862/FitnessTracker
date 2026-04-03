using System;

namespace FitnessTracker
{
    public class RegisteredUser : User
    {
        private int failedAttempts;
        private bool isLocked;

        private const int MaxAttempts = 3;

        public RegisteredUser(string username, string password)
            : base(username, password)
        {
            this.failedAttempts = 0;
            this.isLocked = false;
        }

        public int FailedAttempts
        {
            get { return failedAttempts; }
            set { failedAttempts = value; }
        }

        public bool IsLocked
        {
            get { return isLocked; }
            set { isLocked = value; }
        }
        public override bool CheckPassword(string inputPassword)
        {
            if (isLocked)
                return false;
            bool result = base.CheckPassword(inputPassword);

            if (result)
            {
                failedAttempts = 0;
                return true;
            }
            else
            {
                failedAttempts++;
                if (failedAttempts >= MaxAttempts)
                    isLocked = true;

                return false;
            }
        }

        public int RemainingAttempts()
        {
            return MaxAttempts - failedAttempts;
        }

        public override string ToFileString()
        {
            return base.ToFileString();
        }

        public static RegisteredUser FromFileString(string fileLine)
        {
            string[] parts = fileLine.Split('|');

            if (parts.Length != 3)
                throw new FormatException("Invalid user data in file.");

            string username = parts[0];
            string password = parts[1];
            double goalCalories = double.Parse(parts[2]);

            RegisteredUser user = new RegisteredUser(username, password);
            user.GoalCalories = goalCalories;
            return user;
        }
    }
}