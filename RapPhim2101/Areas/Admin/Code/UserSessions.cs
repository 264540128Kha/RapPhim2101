using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RapPhim2101.Areas.Admin.Code
{
    [Serializable]
    public class UserSessions
    {
        public string email { get; set; }
        public string UserSessionsPassword { get; set; }
    }
}