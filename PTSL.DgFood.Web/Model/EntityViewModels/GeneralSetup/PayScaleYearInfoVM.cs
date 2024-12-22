using System;
using System.ComponentModel.DataAnnotations;

namespace PTSL.DgFood.Web.Model
{
    public class PayScaleYearInfoVM : BaseModel
    {
        public int PayScaleYearInfoName { get; set; }
        public DateTime ImplementationDate { get; set; }
    }
}
