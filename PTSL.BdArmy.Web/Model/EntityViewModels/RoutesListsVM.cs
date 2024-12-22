using PTSL.BdArmy.Web.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.BdArmy.Common.Entity.BdArmy
{
   public class RoutesListsVM 
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public bool IsArrived { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserName { get; set; }
        public string SessionName { get; set; }
        public string UserEmail { get; set; }
        public string PlaceName { get; set; }
    }
}
