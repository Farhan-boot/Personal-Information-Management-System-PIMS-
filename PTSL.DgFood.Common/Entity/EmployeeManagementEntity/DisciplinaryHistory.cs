using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PTSL.DgFood.Common.Entity.EmployeeManagementEntity
{
    public class DisciplinaryHistory : BaseEntity
    {
        public DateTime SubmissonDate { get; set; }
        public string Description { get; set; }
        public IList<Document> Documents { get; set; }
        public long PresentStatusId { get; set; }
        public virtual PresentStatus PresentStatus { get; set; }
        public long DisciplinaryAndCriminalId { get; set; }
        public virtual DisciplinaryActionsAndCriminalProsecution DisciplinaryAndCriminal { get; set; }
    }
}