using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishAndBanglaFeildValidation.Interface
{
    public interface IEnglishAndBanglaValidation
    {
        (bool success, string Message) ValidateBanglaAndEnglishField(string value, int checkingType);
        //(bool success, string Message) ValidateListOfBanglaAndEnglishField(List<Object> data);
    }
}
