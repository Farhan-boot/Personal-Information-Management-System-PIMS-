using PTSL.DgFood.Common.Entity.CommonEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.BdArmy
{
   public class Routes :BaseEntity
    {
        public long UserId { get; set; }
        public bool IsArrived { get; set; }
        public string JsonFileName { get; set; }
        public string SessionName { get; set; }
        public string SessionId { get; set; }
        public virtual IList<RoutesDetails> RoutesDetails { get; set; }
        public virtual IList<RoutesLineStringJsons> LineStringJsons { get; set; }
    }
}
