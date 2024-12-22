using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PTSL.DgFood.Web.Helper.Enum
{
    public enum PostingDetails
    {
        [Display(Name = "First Joining Details")]
        FirstJoiningDetails = 1,
        [Display(Name = "Present Posting Details")]
        PresentPostingDetails = 2
    }
}
