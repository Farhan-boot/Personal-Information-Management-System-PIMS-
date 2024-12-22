using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Web.Mvc;

namespace EnglishAndBanglaFeildValidation.Interface
{
    public interface IModelStateValidation
    {
        string ModelStateErrorMessage(ModelStateDictionary value);
    }
}
