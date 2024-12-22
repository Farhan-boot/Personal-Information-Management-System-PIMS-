using EnglishAndBanglaFeildValidation.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EnglishAndBanglaFeildValidation.Implementation
{
    public class ModelStateValidation : IModelStateValidation
    {
        public string ModelStateErrorMessage(ModelStateDictionary value) //checkingType = 1 means english, 2 means bangla
        {
            string Message = ""; 
            foreach (var item in value)
            {
                foreach (var error in item.Value.Errors)
                {
                    // do something with error
                    string[] ErrorMessage = error.ErrorMessage.Split(' ');
                Message = ErrorMessage[2] + " Input Value Is Invalid !";

                return Message;
                }
            }
            return Message;
        }

    }
}
