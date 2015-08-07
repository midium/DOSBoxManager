using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Web
{
    class CookieAwareWebClient : WebClient
    {
        private CookieContainer cc = new CookieContainer();
        private String lastPage;

        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest r = base.GetWebRequest(address);
            if( r is HttpWebRequest){
                HttpWebRequest req = (HttpWebRequest)r;
                req.CookieContainer = cc;
                req.AllowAutoRedirect = true;
                req.KeepAlive = true;
                req.MaximumAutomaticRedirections = 10;

                req.MaximumResponseHeadersLength = 100;
                req.Referer = address.ToString();
                
                if (lastPage != null)
                {
                    req.Referer = lastPage;
                }
            }

            lastPage = address.ToString();
            return r;
        }
    }
}
