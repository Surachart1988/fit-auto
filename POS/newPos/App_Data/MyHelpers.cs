using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Helpers
{
    public static class MyHelpers
    {
        public static HtmlString PartialResult(this HtmlHelper helper, string path)
        {
            var requestContext = helper.ViewContext.RequestContext;
            UrlHelper url = new UrlHelper(requestContext);
            var client = new WebClient();
            var str = client.DownloadString(new Uri(string.Format("http://{0}{1}", requestContext.HttpContext.Request.Url.Host, url.Content(path))));
            return MvcHtmlString.Create(str);
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }

    public class SHA1
    {
        public static string Encode(string value)
        {
            var hash = System.Security.Cryptography.SHA1.Create();
            var encoder = new System.Text.ASCIIEncoding();
            var combined = encoder.GetBytes(value ?? "");
            return BitConverter.ToString(hash.ComputeHash(combined)).ToLower().Replace("-", "");
        }
    }

    
}