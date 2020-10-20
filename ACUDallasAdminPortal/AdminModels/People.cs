using System;
using System.Collections.Generic;

namespace ACUDallasAdminPortal.AdminModels
{
    public partial class People
    {
        public People()
        {
            FacultyChairs = new HashSet<FacultyChairs>();
            PeopleEducation = new HashSet<PeopleEducation>();
            PersonalContacts = new HashSet<PersonalContacts>();
        }

        public int PersonId { get; set; }
        public int PeopleTypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public byte[] Photo { get; set; }
        public string Title { get; set; }

        public virtual PeopleTypes PeopleType { get; set; }
        public virtual ICollection<FacultyChairs> FacultyChairs { get; set; }
        public virtual ICollection<PeopleEducation> PeopleEducation { get; set; }
        public virtual ICollection<PersonalContacts> PersonalContacts { get; set; }
    }
}
