using System;

namespace ArsAfiliados.ExtensionMethod
{
    public static class ObjectExtensionMethod
    {
        public static int ToInt(this object obj) =>
            Convert.ToInt32(obj);

        public static DateTime ToDateTime(this object obj) =>
            Convert.ToDateTime(obj);

        public static char Tochar(this object obj) =>
            Convert.ToChar(obj);

        public static decimal ToDecimal(this object obj) =>
            Convert.ToDecimal(obj);

        public static bool ToBool(this object obj) =>
            Convert.ToBoolean(obj);
    }
}
