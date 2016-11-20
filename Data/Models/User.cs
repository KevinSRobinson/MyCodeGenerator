#region

using System;

#endregion

namespace Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int OldId { get; set; }
        public int OldOrgId { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordText { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Organisation { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Hours { get; set; }
        public string Mobile { get; set; }
        public string UserType { get; set; }

        public Guid Role { get; set; }
    }
}