using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PTSL.DgFood.Common.Enum
{
    public enum Grade
    {
        [Display(Name = "Grades 1-9 (Class 1)")]
        Grades_1_9_Class_1 = 1,
        [Display(Name = "Grade 10th (2nd Class)")]
        Grade_10th_2nd_Class = 2,
        [Display(Name = "Grades 11-16 (3rd Class)")]
        Grades_11_16_3rd_Class = 3,
        [Display(Name = "Grades 17-20 (4th Class)")]
        Grades_17_20_4th_Class = 4
    }
}
