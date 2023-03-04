using System.Data;
using ServiceStack.OrmLite;
using WHA.Entity;

namespace WHA.Extensions;

public static class BaseExtensions
{
    public static void Times(this int count, Action action)
    {
        for (var i = 0; i < count; i++)
        {
            action();
        }
    }
    
    public static T GetRandom<T>(this List<T> list) => list[new Random().Next(list.Count)];
    
}