using System.Web;
using Sitecore.Diagnostics;
using Sitecore.Mvc.Pipelines.Response.RenderRendering;

namespace Helpfulcore.CacheKeyProfiling.Pipelines.RenderRendering
{
	public class GatherCacheKeys : RenderRenderingProcessor
	{
		public override void Process(RenderRenderingArgs args)
		{
			Assert.ArgumentNotNull(args, "args");
			if (args.Rendered || !args.Cacheable || string.IsNullOrEmpty(args.CacheKey))
			{
				return;
			}

			if (HttpContext.Current != null)
			{
				var collection = CacheKeyCollection.CurrentRequest;

				collection.CacheKeys.Add(args.CacheKey);
			}
		}
	}
}
