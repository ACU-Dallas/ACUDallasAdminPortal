using System;
using System.Collections.Generic;

namespace ACUDallasAdminPortal.AdminModels
{
    public partial class ContactTypes
    {
        public ContactTypes()
        {
            PersonalContacts = new HashSet<PersonalContacts>();
        }

        public int ContactTypeId { get; set; }
        public string ContactType { get; set; }

        public virtual ICollection<PersonalContacts> PersonalContacts { get; set; }
    }
}
