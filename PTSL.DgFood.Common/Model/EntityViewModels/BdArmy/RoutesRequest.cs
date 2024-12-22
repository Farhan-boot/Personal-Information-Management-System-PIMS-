using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Common.Entity.BdArmy
{
   
    public class RoutesLineString
    {
        public List<RoutesRequest> Routes { get; set; }
    }
    public class RoutesRequest : BaseFeature
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("geometry")]
        //public RouteGeometry Geometry { get; set; }
        public Geometry geometry { get; set; }

        [JsonProperty("properties")]
        public RoutesProperties properties { get; set; }

        public class RoutesGeometry
        {
            [JsonProperty("type")]
            public string type { get; set; }

            [JsonProperty("coordinates")]
            public List<List<double>> coordinates { get; set; }
        }

        public class RoutesProperties
        {
            [JsonProperty("UserId")]
            public long UserId { get; set; }
            //Route Master
            [JsonProperty("ArrivedDate")]
            public DateTime ArrivedDate { get; set; }

            [JsonProperty("RoutesId")]
            public long RoutesId { get; set; }
            [JsonProperty("RoutesDetailId")]
            public long RoutesDetailId { get; set; }

            [JsonProperty("IsArrived")]
            public bool IsArrived { get; set; }

            

            [JsonProperty("StartLatitude")]
            public float StartLatitude { get; set; }

            [JsonProperty("StartLongitude")]
            public float StartLongitude { get; set; }

            [JsonProperty("EndLatitude")]
            public float EndLatitude { get; set; }

            [JsonProperty("EndLongitude")]
            public float EndLongitude { get; set; }

            
        }
    }

    public class RoutesResponse
    {
        public RoutesVM master { get; set; }
        public long RouteSurveyMasterID { get; set; }
        public RoutesDetailsVM details { get; set; }
        public long RouteSurveyDetailsID { get; set; }
        public long RoutesSurveyAndriodMasterID { get; set; }
        public long RoutesSurveyAndriodDetailsID { get; set; }
    }
    public class RoutesResponseFinal
    {
        public long RouteId { get; set; }
        public long RoutesDetailsId { get; set; }
        public long RoutesSurveyAndriodMasterID { get; set; }
        public long RoutesSurveyAndriodDetailsID { get; set; }
        public long ExecutionState { get; set; }
    }

    public class Geometry
    {
        public string type { get; set; }
        public List<List<double>> coordinates { get; set; }
    }
    public class BaseFeature
    {
        public dynamic geometry { get; set; }
    }
}