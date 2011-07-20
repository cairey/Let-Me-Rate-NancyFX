using System.Web;

namespace LetMeRate.Web.Helpers
{
    public interface IHttpContextAccessor
    {
        HttpContextBase Current { get; }
    }
}