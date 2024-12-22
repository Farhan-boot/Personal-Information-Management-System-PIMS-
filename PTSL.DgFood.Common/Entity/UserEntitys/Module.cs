using PTSL.DgFood.Common.Entity.CommonEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity
{
    public class Module : BaseEntity
    {
        public string ModuleName { get; set; }
        public string ModuleIcon { get; set; }
        public byte IsVisible { get; set; }
        public Nullable<int> MenueOrder { get; set; }
    }
}
