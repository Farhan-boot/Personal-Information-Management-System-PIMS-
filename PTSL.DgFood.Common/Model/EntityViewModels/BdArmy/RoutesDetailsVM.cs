using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Model.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.BdArmy
{
   public class RoutesDetailsVM : BaseModel
    {
        //public long UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float StartTime { get; set; }
        public float EndTime { get; set; }
        public float Latitude { get; set; }
        //public float? EndLatitude { get; set; }
        public float Longitude { get; set; }
        //public float? EndLongitude { get; set; }
        public float? Radius { get; set; }
        public string PlaceName { get; set; }
        public long RoutesId { get; set; }
        public bool IsArrived { get; set; }
        public virtual RoutesVM Routes { get; set; }
        public virtual IList<RoutesLineStringJsonsVM> LineStringJsons { get; set; }
    }
}
