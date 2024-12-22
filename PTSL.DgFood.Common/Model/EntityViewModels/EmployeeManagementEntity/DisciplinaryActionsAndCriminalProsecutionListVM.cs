using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity
{
    public class DisciplinaryActionsAndCriminalProsecutionListVM
    {
        public long Id { get; set; }
        public long EmpoloyeeInformationId { get; set; }
        public string Category { get; set; }
        public string PresentStatus { get; set; }
        public string Document { get; set; }
    }
}
