using System;
using System.Collections.Generic;

namespace ACUDallasAdminPortal.AdminModels
{
    public partial class FacultyChairs
    {
        public int FacultyChairId { get; set; }
        public int PersonId { get; set; }
        public string ResearchFocus { get; set; }
        public bool ChairAvailable { get; set; }
        public bool CommitteAvailable { get; set; }
        public bool MentorAvailable { get; set; }

        public virtual People Person { get; set; }
    }
}
