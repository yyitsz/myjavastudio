using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Context
{
    public class UserContext
    {
        public static readonly String USER_CONTEXT_KEY = "fw.user.context";
        public string UserId { get; set; }
    }
}
