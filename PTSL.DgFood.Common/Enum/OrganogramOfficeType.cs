using System.ComponentModel.DataAnnotations;

namespace PTSL.DgFood.Common.Enum
{
    public enum OrganogramOfficeType
    {
        [Display(Name = "DG Of Food (Head Office)")]
        DGOfFood = 1,

        [Display(Name = "Field Office")]
        FieldOffice = 2,
    }
}
