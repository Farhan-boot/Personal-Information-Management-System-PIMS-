using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity
{
    public class TrainingInformationManagementMasterVM : BaseModel
    {
        public long TrainingManagementTypeId { get; set; }
        public bool Status { get; set; }
        [NotMapped]
        public long[] EmployeeInformationIds { get; set; }
        public TrainingManagementTypeVM TrainingManagementTypeDto { get; set; }
        public List<TrainingInformationManagementVM> TrainingInformationManagementLists { get; set; }
    }

	public class TrainingSmsVM : BaseModel
	{

		public string MessageBody { get; set; }
		public string MessageSubject { get; set; }
		public DateTime NoticeDate { get; set; }
		public long NoticeBy { get; set; }
		public bool IsEmail { get; set; }
		public bool IsSMS { get; set; }

		public long EmployeeInformationId { get; set; }
		public long TrainingManagementTypeId { get; set; }
	}
}