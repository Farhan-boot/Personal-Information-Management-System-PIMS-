using PTSL.BdArmy.Web.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.BdArmy.Common.Entity.BdArmy
{
   public class RoutesVM : BaseModel
    {
        public long UserId { get; set; }
        public bool IsArrived { get; set; }
        public string JsonFileName { get; set; }
        public string SessionName { get; set; }
        public string SessionId { get; set; }
        public virtual IList<RoutesDetailsVM> RoutesDetails { get; set; }
        public virtual IList<RoutesLineStringJsonsVM> LineStringJsons { get; set; }
    }
}
