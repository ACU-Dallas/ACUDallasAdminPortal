using System;
using System.Collections.Generic;

namespace ACUDallasAdminPortal.AdminModels
{
    public partial class PeopleEducation
    {
        public int PeopleEducationId { get; set; }
        public int PersonId { get; set; }
        public string Degree { get; set; }
        public string Institution { get; set; }
        public string Discipline { get; set; }
        public DateTime? GraduationDate { get; set; }

        public virtual People Person { get; set; }
    }
}
