using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Framework.Context;

namespace Framework.Module
{
    public class UserContextModule : IHttpModule
    {
        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += new EventHandler(context_AuthenticateRequest);
            context.PostAuthenticateRequest += new EventHandler(context_PostAuthenticateRequest);
            
        }

        void context_PostAuthenticateRequest(object sender, EventArgs e)
        {
            UserContext ctx = new UserContext();
            if (HttpContext.Current.User != null && String.IsNullOrEmpty(HttpContext.Current.User.Identity.Name) == false)
            {
                ctx.UserId = HttpContext.Current.User.Identity.Name;

            }
            else
            {
                ctx.UserId = "SYSTEM";
            }
            HttpContext.Current.Items[UserContext.USER_CONTEXT_KEY] = ctx;
        }

        void context_AuthenticateRequest(object sender, EventArgs e)
        {
            
        }
    }
}
