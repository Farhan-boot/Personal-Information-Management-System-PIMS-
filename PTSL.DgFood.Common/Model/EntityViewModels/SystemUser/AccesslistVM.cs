using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Model.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup
{
    public class AccesslistVM : BaseModel
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string Mask { get; set; }
        public byte AccessStatus { get; set; }
        public byte IsVisible { get; set; }
        public string IconClass { get; set; }
        public int BaseModule { get; set; }
        public Nullable<int> BaseModuleIndex { get; set; }
    }
}
