using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Model.EntityViewModels
{
    public class Menu
    {
        public string UserName { get; set; }
        public string GroupName { get; set; }
        public List<MenueViewModel> MenuList { get; set; }
    }

    public class MenueViewModel
    {
        public long ModuleID { get; set; }
        public string ModuleName { get; set; }
        public string ModuleIcon { get; set; }
        public List<CustomerAccessList> AccessList { get; set; }

    }

    public class CustomerAccessList
    {
        public long AccessID { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string Mask { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime CreateTime { get; set; }
        public byte AccessStatus { get; set; }
        public byte IsVisible { get; set; }
        public string CreatedBy { get; set; }
        public byte IsRemoved { get; set; }
        public string IconClass { get; set; }
        public int BaseModule { get; set; }
        public Nullable<int> BaseModuleIndex { get; set; }
    }
}