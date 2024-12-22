using PTSL.BdArmy.Web.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.BdArmy.Common.Entity.BdArmy
{
   public class RoutesDataVM : BaseModel
    {
        public RoutesVM RoutesVM { get; set; }
        public virtual ICollection<RoutesVM> Routess { get; set; }
        public RoutesDetailsVM RoutesDetailsVM { get; set; }
        public virtual ICollection<RoutesDetailsVM> RoutesDetails { get; set; }
    }
}
