using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Model.EntityViewModels.EmployeeManagementEntity
{
    public class EmployeeViewModel
    {
        public EmployeeInformationVM EmployeeInformationVM { get; set; }
        public IList<EmployeeInformationVM> EmployeeInfoLists { get; set; }
        public SpouseInformationVM SpouseInformationVM { get; set; }
        public IList<SpouseInformationVM> SpouseInformationLists { get; set; }
        public PermanentAddressVM PermanentAddressVM { get; set; }
        public IList<PermanentAddressVM> PermanentAddressLists { get; set; }
        public PresentAddressVM PresentAddressVM { get; set; }
        public IList<PresentAddressVM> PresentAddressLists { get; set; } 
        public EducationalQualificationVM EducationalQualificationVM { get; set; }
        public IList<EducationalQualificationVM> EducationalQualificationLists { get; set; }
        public TrainingInformationVM TrainingInformationVM { get; set; }
        public IList<TrainingInformationVM> TrainingInformationLists { get; set; }
        public ChildrenInformationVM ChildrenInformationVM { get; set; }
        public IList<ChildrenInformationVM> ChildrenInformationLists { get; set; }
        public ServiceHistoryVM ServiceHistoryVM { get; set; }
        public IList<ServiceHistoryVM> ServiceHistoryLists { get; set; }
        public OfficialInformationVM OfficialInformationVM { get; set; }
        public IList<OfficialInformationVM> OfficialInformationLists { get; set; }
        public DisciplinaryActionsAndCriminalProsecutionVM DisciplinaryActionsAndCriminalProsecutionVM { get; set; }
        public IList<DisciplinaryActionsAndCriminalProsecutionVM> DisciplinaryActionsAndCriminalProsecutionLists { get; set; }
        public PostingRecordsVM PostingRecordsVM { get; set; }
        public IList<PostingRecordsVM> PostingRecordLists { get; set; }
        public EmployeeTransferVM EmployeeTransferVM { get; set; }
        public IList<EmployeeTransferVM> EmployeeTransferLists { get; set; }

        public PromotionPartcularsVM PromotionPartcularsVM { get; set; }
        public IList<PromotionPartcularsVM> PromotionPartcularLists { get; set; }
        public LanguageInformationVM LanguageInformationVM { get; set; }
        public IList<LanguageInformationVM> LanguageInformationLists { get; set; }
        
    }
}