using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindU.Application.Extensions
{
    public static class ListExtensions
    {
	    public static async Task ForEachAsync<T>(this IList<T> enumerable, Action<T> action)
	    {
		    foreach (var item in enumerable)
			    await Task.Run(() => { action(item); }).ConfigureAwait(false);
	    }
	}
}
