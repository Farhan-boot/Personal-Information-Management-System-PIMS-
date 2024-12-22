using System.ComponentModel.DataAnnotations;

namespace PTSL.DgFood.Web.Model
{
    public class EventVM : BaseModel
    {
        [MaxLength(100)]
        public string EventName { get; set; }
    }
 
}
