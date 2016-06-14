using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Helpfulcore.CacheKeyProfiling
{
	public static class HtmlHelperExtensions
	{
		public static IHtmlString RenderCacheKeys(this HtmlHelper htmlHelper)
		{
			return htmlHelper.Partial("/Views/Shared/CacheKeyProfiling/CacheKeys.cshtml");
		}
	}
}
