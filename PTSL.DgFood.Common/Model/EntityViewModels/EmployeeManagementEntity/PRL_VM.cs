using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Helper;
using PTSL.DgFood.Common.Model.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity
{
    public class PRL_VM : BaseModel
    {
        public long EmployeeInformationId { get; set; }
        public string MessageBody { get; set; }
        public string MessageSubject { get; set; }
        public DateTime NoticeDate { get; set; }
        public long NoticeBy { get; set; }
        public bool IsEmail { get; set; }
        public bool IsSMS { get; set; }
        [SwaggerExclude]
        public EmployeeInformation EmployeeInformation { get; set; }
    }
}
