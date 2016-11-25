using System;

namespace Data
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid UserId { get; set; }
    }
}