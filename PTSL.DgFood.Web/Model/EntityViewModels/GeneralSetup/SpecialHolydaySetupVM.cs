using PTSL.DgFood.Web.Helper.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PTSL.DgFood.Web.Model
{
    public class SpecialHolydaySetupVM : BaseModel
    {
        [MaxLength(100)]
        public string SpecialHolydaySetupName { get; set; }
        public string SpecialHolydaySetupNameBn { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
