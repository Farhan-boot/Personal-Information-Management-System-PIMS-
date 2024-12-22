using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.EmployeeManagementEntity
{
    public class EmployeeInformationDetailsVM
    { 
        public EmployeeInformation EmployeeInformation { get; set; } 
        public OfficialInformation OfficialInformations { get; set; } 
        public List<PresentAddress> PresentAddresses { get; set; } 
        public List<PermanentAddress> PermanentAddresses { get; set; } 
        public List<ChildrenInformation> ChildrenInformations { get; set; } 
        public List<EducationalQualification> EducationalQualifications { get; set; } 
        public List<TrainingInformation> TrainingInformations { get; set; } 
        public List<PromotionPartculars> PromotionPartculars { get; set; } 
        public List<PostingRecords> PostingRecords { get; set; } 
        public List<LanguageInformation> LanguageInformations { get; set; } 
    }
}
