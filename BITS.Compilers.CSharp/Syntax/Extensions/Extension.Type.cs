using System;
using System.Linq;
using System.Text;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    using Type = System.Type;


    public static class ExtensionType
    {
        /// <summary>
        /// Gets the full name of a type, considering generic type arguments.
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static String GetFullName(this Type @this)
        {
            return @this.GetName(withFullName: true, withFullParameterNames: true);
        }

        /// <summary>
        /// http://stackoverflow.com/questions/954791/how-to-get-full-c-sharp-declaration-for-a-type
        /// </summary>
        /// <param name="this"></param>
        /// <param name="withFullName"></param>
        /// <param name="withFullParameterNames"></param>
        /// <returns></returns>
        public static String GetName(this Type @this, Boolean @withFullName = false,
            Boolean @withFullParameterNames = false)
        {
            var sb = new StringBuilder();

            if (@withFullName && !String.IsNullOrEmpty(@this.Namespace))
            {
                sb.Append(@this.Namespace);
                sb.Append(".");
            }

            AppendCSharpTypeName(sb, @this, @withFullParameterNames);

            return sb.ToString();
        }

        /// <summary>
        /// http://stackoverflow.com/questions/954791/how-to-get-full-c-sharp-declaration-for-a-type
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="type"></param>
        /// <param name="withFullParameterNames"></param>
        static void AppendCSharpTypeName(StringBuilder @sb,
            Type @type, Boolean @withFullParameterNames = false)
        {
            var typeName = @type.Name;
            var declaringType = @type.DeclaringType;

            var declaringTypeArgumentCount = 0;

            if (@type.IsNested && declaringType != null)
            {
                if (declaringType.IsGenericTypeDefinition)
                {
                    declaringTypeArgumentCount =
                        declaringType.GetGenericArguments().Length;
                    declaringType = declaringType.MakeGenericType(
                        @type.GetGenericArguments().Take(declaringTypeArgumentCount)
                            .ToArray());
                }

                AppendCSharpTypeName(@sb, declaringType, @withFullParameterNames);
                @sb.Append(".");
            }

            var genericArguments = @type.GetGenericArguments()
                .Skip(declaringTypeArgumentCount).ToArray();

            int stopIndex;

            if ((@type.IsGenericTypeDefinition || @type.IsGenericType) && ((stopIndex = @type.Name.IndexOf('`')) > 0))
            {
                @sb.Append(typeName.Substring(0, stopIndex));

                var genericArgumentNames = genericArguments
                    .Select(t => GetName(t, @withFullParameterNames)).ToArray();

                if (genericArgumentNames.Length > 0)
                {
                    @sb.AppendFormat("<{0}>",
                        String.Join(",", genericArgumentNames));
                }
            }
            else
            {
                @sb.Append(typeName);
            }
        }
    }
}
