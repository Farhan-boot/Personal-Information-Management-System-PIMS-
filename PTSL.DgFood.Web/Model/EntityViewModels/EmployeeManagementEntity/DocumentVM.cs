using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity
{
    public class DocumentVM : BaseModel
    {
        public string Name { get; set; }
        public long DisciplinaryHistoryId { get; set; }
        public DisciplinaryHistoryVM DisciplinaryHistory { get; set; }
    }
}