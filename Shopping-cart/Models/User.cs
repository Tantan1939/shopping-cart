using System.ComponentModel.DataAnnotations;

namespace Shopping_cart.Models
{
    public class User
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        public string? ConfirmPassword { get; set; }

        private DateTime dateCreated;

        private DateTime lastLogin;

        public DateTime DateCreated
        {
            get { return dateCreated; }
            private set
            {
                dateCreated = value;
            }
        }

        public DateTime LastLogin
        {
            get { return lastLogin; }
            private set
            {
                lastLogin = value;
            }
        }

        public User(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
            DateCreated = DateTime.Now;
        }

        public User() { }

    }
}
