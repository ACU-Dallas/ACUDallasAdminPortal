using System;
using System.Collections.Generic;

namespace ACUDallasAdminPortal.AdminModels
{
    public partial class PersonalContacts
    {
        public int PeopleContactId { get; set; }
        public int PersonId { get; set; }
        public int ContactTypeId { get; set; }
        public string Contact { get; set; }
        public bool Active { get; set; }

        public virtual ContactTypes ContactType { get; set; }
        public virtual People Person { get; set; }
    }
}
