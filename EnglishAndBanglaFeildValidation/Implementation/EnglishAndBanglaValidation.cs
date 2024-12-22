using EnglishAndBanglaFeildValidation.Interface;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.ModelBinding;

namespace EnglishAndBanglaFeildValidation.Implementation
{
    public class EnglishAndBanglaValidation : IEnglishAndBanglaValidation
    {
        public (bool success,string Message) ValidateBanglaAndEnglishField(string value, int checkingType) //checkingType = 1 means english, 2 means bangla
        {
            (bool success, string Message) returnResponse; 
            const int MaxAnsiCode = 255;
            value = value.Replace(" ", "");
            value = value.Replace(":", "");
            bool hasEnglishCharacterInBanglaName = value.Any(c => c < MaxAnsiCode);

            bool hasBanglaCharacterInEnglishName = value.Any(c => c > MaxAnsiCode);
            returnResponse.Message = "";
            returnResponse.success = true;


            
            if (hasBanglaCharacterInEnglishName == true && checkingType == 1) //for english field validation
            {
                returnResponse.Message = "English Name is Invalid !";
                returnResponse.success = false;
            }
            else if (hasEnglishCharacterInBanglaName == true && checkingType == 2) //for bagnla field validation
            {
                returnResponse.Message = "Bangla Name is Invalid !";
                returnResponse.success = false;
            }

            return returnResponse;
        }

        

        //public (bool success, string Message) ValidateListOfBanglaAndEnglishField(List<Object> data) //checkingType = 1 means english, 2 means bangla
        //{
        //    (bool success, string Message) returnResponse;
        //    returnResponse.Message = "";
        //    returnResponse.success = true;

        //    const int MaxAnsiCode = 255;
        //    Type type = data.GetType();
        //    //foreach (var value in data.ToList())
        //    //{
        //    foreach (PropertyInfo value in type.GetProperties())
        //    {
        //        string Name = value.Name.Replace(" ", "");
        //        Name = Name.Replace(":", "");
        //        //bool hasEnglishCharacterInBanglaName = value.Any(c => c < MaxAnsiCode);

        //        //bool hasBanglaCharacterInEnglishName = value.Any(c => c > MaxAnsiCode);

        //        //if (hasBanglaCharacterInEnglishName == true && checkingType == 1) //for english field validation
        //        //{
        //        //    returnResponse.Message = "English Name is Invalid !";
        //        //    returnResponse.success = false;
        //        //}
        //        //else if (hasEnglishCharacterInBanglaName == true && checkingType == 2) //for bagnla field validation
        //        //{
        //        //    returnResponse.Message = "Bangla Name is Invalid !";
        //        //    returnResponse.success = false;
        //        //}
        //    }


        //    return returnResponse;
        //}

    }
}
