using System;

namespace FluentHtmlExample.Core.Exts
{
    public static class ObjectExts
    {
        public static bool CanBeCastTo<T>(this Type type)
        {
            return typeof(T).CanBeCastTo(type);
        }

        public static bool CanBeCastTo(this Type type1, Type type)
        {
            return type1.IsAssignableFrom(type);
        }

        public static bool CanBeCastTo<T>(this object instance)
        {
            return instance.GetType().CanBeCastTo<T>();
        }

        public static bool CanBeCastTo(this object instance, object baseType)
        {
            return CanBeCastTo(instance.GetType(), baseType.GetType());
        }
    }
}