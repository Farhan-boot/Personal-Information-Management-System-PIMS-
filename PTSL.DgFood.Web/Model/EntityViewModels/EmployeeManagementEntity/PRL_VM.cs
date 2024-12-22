using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity
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
        public EmployeeInformationVM EmployeeInformation { get; set; }
    }
}