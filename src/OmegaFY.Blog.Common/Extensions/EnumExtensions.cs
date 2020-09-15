using System;
using System.Reflection;

namespace OmegaFY.Blog.Common.Extensions
{

    public static class EnumExtensions
    {

        public static T GetAttributeOfType<T>(this Enum enumVal) where T : Attribute
        {
            Type type = enumVal.GetType();
            MemberInfo[] memberInfos = type.GetMember(enumVal.ToString());
            object[] atributos = memberInfos[0].GetCustomAttributes(typeof(T), false);

            return atributos?.Length > 0 ? (T)atributos[0] : null;
        }

    }

}
