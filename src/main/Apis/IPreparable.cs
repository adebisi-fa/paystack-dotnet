using System.Linq;
using System.Web;

namespace PayStack.Net
{
    public interface IPreparable
    {
        void Prepare();
    }

    public static class Extension
    {
        public static string ToQueryString(this object request)
        {
            var properties = from p in request.GetType().GetProperties()
                let v = p.GetValue(request, null)
                where v != null
                select p.Name + "=" + HttpUtility.UrlEncode(v.ToString());

            return string.Join("&", properties.ToArray());
        }
    }
}