using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Extensions
{
    public static class EnumerableExtensions
    {
        public static async Task ForEachAsync<T>(this IEnumerable<T> enumerable, Func<T, Task> action)
        {
            foreach (var item in enumerable)
            {
                await action(item);
            }
        }

        public static Task ParallelForEachAsync<T>(this IEnumerable<T> enumerable, Func<T, Task> action)
        {
            return Task.WhenAll(enumerable.Select(item => action(item)));
        }

        public static async Task<IEnumerable<TOut>> SelectAsync<TIn, TOut>(this IEnumerable<TIn> enumerable, Func<TIn, Task<TOut>> action)
        {
            var result = new List<TOut>();

            await enumerable.ForEachAsync(async n =>
            {
                result.Add(await action(n));
            });

            return result;
        }

        public static async Task<IEnumerable<TOut>> ParallelSelectAsync<TIn, TOut>(this IEnumerable<TIn> enumerable, Func<TIn, Task<TOut>> action)
        {
            return await Task.WhenAll(enumerable.Select(item => action(item)));
        }
    }
}
