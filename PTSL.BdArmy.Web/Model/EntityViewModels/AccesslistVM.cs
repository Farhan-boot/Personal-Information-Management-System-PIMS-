using System;

namespace PTSL.BdArmy.Web.Model
{
    public class AccesslistVM : BaseModel
    {
        public string ModuleName { get; set; }
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
