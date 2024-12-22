using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Model.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.BdArmy
{
  public  class RoutesVM : BaseModel
    {
        public long UserId { get; set; }
        public bool IsArrived { get; set; }
        public string JsonFileName { get; set; }
        public string SessionName { get; set; }
        public string SessionId { get; set; }
        public virtual IList<RoutesDetailsVM> RoutesDetails { get; set; }
        public virtual IList<RoutesLineStringJsonsVM> LineStringJsons { get; set; }
    }

    public class RoutesResultVM
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string SessionName { get; set; }
        public bool IsArrived { get; set; }
        //public DateTime StartDate { get; set; }
        //public DateTime EndDate { get; set; }
        //public long StartTime { get; set; }
        //public long EndTime { get; set; }
        //public float StartLatitude { get; set; }
        //public float EndLatitude { get; set; }
        //public float StartLongitude { get; set; }
        //public float EndLongitude { get; set; }
        ////public float? Radius { get; set; }
        ////public string PlaceName { get; set; }
        //public bool IsArrived { get; set; }
        //public string JsonFileName { get; set; }
        //public int status { get; set; }
        public virtual IList<RoutesDetailsDataVM> RoutesDetails { get; set; }
        //public virtual IList<RoutesLineStringJsonsVM> LineStringJsons { get; set; }
    }

    public class RoutesDetailsDataVM
    {
        public long Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float Latitude { get; set; }
        //public float? EndLatitude { get; set; }
        public float Longitude { get; set; }
        //public float? EndLongitude { get; set; }
        public float? Radius { get; set; }
        public string PlaceName { get; set; }
        public long RoutesId { get; set; }
        //public virtual RoutesVM Routes { get; set; }
        //public virtual IList<RoutesLineStringJsonsVM> LineStringJsons { get; set; }
    }

}
