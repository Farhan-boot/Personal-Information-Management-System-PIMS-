using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.EmployeeManagementEntity
{
    public class Document : BaseEntity
    {
        public string Name { get; set; }
        public long DisciplinaryHistoryId { get; set; }
        [SwaggerExclude]
        public DisciplinaryHistory DisciplinaryHistory{ get; set; }
    }
}