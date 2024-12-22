using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Model.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model
{
    public class ModuleVM : BaseModel
    {
        public string ModuleName { get; set; }
        public string ModuleIcon { get; set; }
        public byte IsVisible { get; set; }
        public Nullable<int> MenueOrder { get; set; }
    }
    
}
