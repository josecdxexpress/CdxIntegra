using System;
using System.Collections.Generic;
using System.Linq;

namespace CDX.NF.Core.Infraestrutura.DependencyInjection
{
    public static class ModuloConfigExtensions
    {
        private static List<Type> configurationModules = new List<Type>();

        internal static bool IsMigrationExecution { get; set; }

        public static string GetDbPrefix(this Type configurationType, bool force = false)
        {
            var staticAttrs = configurationType
                .GetFields()
                .Where(a => a.IsLiteral && a.Name == "MODULO_PREFIXO_DB")
                .ToList();

            if (staticAttrs.Count == 0)
            {
                throw new MissingFieldException(string.Format("Não foi definida a propriedade 'MODULO_PREFIXO_DB' na configuração do módulo ({0}).", configurationType.FullName));
            }

            if (IsMigrationExecution)
            {
                return (staticAttrs.First().GetValue(null) as string) + "_";
            }

            return (staticAttrs.First().GetValue(null) as string) + "_";
        }

        public static string GetDbSchemma(this Type configurationType)
        {
            var staticAttrs = configurationType
                .GetFields()
                .Where(a => a.IsLiteral && a.Name == "MODULO_SCHEMA_DB")
                .ToList();

            if (staticAttrs.Count == 0)
            {
                throw new MissingFieldException(string.Format("Não foi definida a propriedade 'MODULO_SCHEMA_DB' na configuração do módulo ({0}).", configurationType.FullName));
            }

            if (IsMigrationExecution)
            {
                return staticAttrs.First().GetValue(null) as string;
            }

            return staticAttrs.First().GetValue(null) as string;
        }

        internal static string GetTableName(this Type configType, string tableName)
        {
            return string.Format("{0}.{1}{2}", configType.GetDbSchemma(), configType.GetDbPrefix(), tableName);
        }

        internal static Type GetModuleConfigurationType(this Type entityType)
        {
             return null;
        }
    }
}
