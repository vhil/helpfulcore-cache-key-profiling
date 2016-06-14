using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Helpfulcore.CacheKeyProfiling
{
	public class CacheKeyCollection
	{
		public CacheKeyCollection()
		{
			this.CacheKeys = new List<string>();
		}

		public static CacheKeyCollection CurrentRequest
		{
			get
			{
				const string requestKey = "GatheredRenderingCacheKeys";
				var collection = HttpContext.Current.Items[requestKey] as CacheKeyCollection;
				if (collection == null)
				{
					collection = new CacheKeyCollection();
					HttpContext.Current.Items[requestKey] = collection;
				}

				return collection;
			}
		}

		public ICollection<string> CacheKeys { get; protected set; }
	}
}
