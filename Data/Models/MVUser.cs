#region

using System;
using System.ComponentModel.DataAnnotations;

#endregion

namespace Data.Models
{
    public class MvUser
    {
        [Key]
        public int Id { get; set; }

        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}