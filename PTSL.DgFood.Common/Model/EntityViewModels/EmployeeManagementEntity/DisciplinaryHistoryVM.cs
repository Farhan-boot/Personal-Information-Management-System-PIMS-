using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Helper;
using PTSL.DgFood.Common.Model.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity
{
    public class DisciplinaryHistoryVM : BaseModel
    {
        public DateTime SubmissonDate { get; set; }
        public string Description { get; set; }
        public IList<Document> Documents { get; set; }
        public long? PresentStatusId { get; set; }
        [SwaggerExclude]
        public virtual PresentStatus PresentStatus { get; set; }
        public long? DisciplinaryAndCriminalId { get; set; }
        [SwaggerExclude]
        public virtual DisciplinaryActionsAndCriminalProsecution DisciplinaryAndCriminal { get; set; }
    }
}