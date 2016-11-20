#region

using System;
using System.ComponentModel.DataAnnotations;

#endregion

namespace Data.Models
{
    public class Organisation
    {
        [Key]
        public int Id { get; set; }

        public Guid OrgGuid { get; set; }

        public int OldId { get; set; }
        public Guid OrganisationAdmin { get; set; }
        public string OrganisationName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ContactForename { get; set; }
        public string ContactSurname { get; set; }
        public string Postcode { get; set; }
        public string Town { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public string Tel { get; set; }
    }
}