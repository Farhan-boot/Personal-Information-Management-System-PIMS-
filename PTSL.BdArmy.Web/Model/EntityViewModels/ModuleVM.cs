using System;

namespace PTSL.BdArmy.Web.Model
{
    public class ModuleVM : BaseModel
    {
        public string ModuleName { get; set; }
        public string ModuleIcon { get; set; }
        public byte IsVisible { get; set; }
        public Nullable<int> MenueOrder { get; set; }
    }
}
