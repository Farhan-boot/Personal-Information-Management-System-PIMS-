using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Model.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.BdArmy
{
   public class RoutesLineStringJsonsVM : BaseModel
    {
        public long UserId { get; set; }
        public long RoutesId { get; set; }
        public long RoutesDetailsId { get; set; }
        public float StartLatitude { get; set; }
        public float EndLatitude { get; set; }
        public float StartLongitude { get; set; }
        public float EndLongitude { get; set; }
        public string JsonFileName { get; set; }
        //public virtual ICollection<LineStringJsonsDetails> LineStringJsonsDetails { get; set; }
        public virtual RoutesVM Routes { get; set; }
        public virtual RoutesDetailsVM RoutesDetails { get; set; }
    }
}
