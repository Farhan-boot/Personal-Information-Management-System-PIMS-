using System.ComponentModel.DataAnnotations;

namespace PTSL.DgFood.Web.Model
{
    public class CategoryVM : BaseModel
    {
        [MaxLength(100)]
        public string CategoryName { get; set; }
        public string CategoryNameBn { get; set; }
        //public DisciplinaryActionsAndCriminalProsecution DisciplinaryActionsAndCriminalProsecution { get; set; }
    }

    public class DropdownVM 
    {
        public int Id { get; set; }
        public string Name { get; set; }
         
    }

    public class Dropdown2VM
    {
        public string Id { get; set; }
        public string Name { get; set; }

    }
}
