using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Helper.Enum
{
    public enum ExecutionState
    {
        Failure = 0,
        Success = 10,
        Created = 20,
        Retrieved = 30,
        Updated = 40,
        Activated = 41,
        Inactivated = 42,
        Deleted = 50,
    }
}