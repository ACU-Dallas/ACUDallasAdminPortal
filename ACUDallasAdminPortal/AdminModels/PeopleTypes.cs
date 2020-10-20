using System;
using System.Collections.Generic;

namespace ACUDallasAdminPortal.AdminModels
{
    public partial class PeopleTypes
    {
        public PeopleTypes()
        {
            People = new HashSet<People>();
        }

        public int PeopleTypeId { get; set; }
        public string PeopleTypeDesc { get; set; }

        public virtual ICollection<People> People { get; set; }
    }
}
