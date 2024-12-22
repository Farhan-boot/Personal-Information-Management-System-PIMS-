using System.ComponentModel.DataAnnotations;

namespace PTSL.DgFood.Web.Model
{
    public class PayScalePerGradeVM : BaseModel
    {
        public int ScaleYear { get; set; }
        [MaxLength(250)]
        public string ScaleOfPay { get; set; }
        public decimal basic_pay { get; set; }
        public long RankId { get; set; }
        public RankVM RankDTO { get; set; }

    }
}
