using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace NHP_CHETAS.Utility
{
    public static class MultipleResultset
    {
        private static readonly ConcurrentDictionary<Type, object> _materializers = new ConcurrentDictionary<Type, object>();
        public static IList<T> Translate<T>(this DbDataReader reader) where T : new()
        {
            var materializer = (Func<IDataRecord, T>)_materializers.GetOrAdd(typeof(T), (Func<IDataRecord, T>)Materializer.Materialize<T>);
            return Translate(reader, materializer, out var hasNextResults);
        }
        public static IList<T> Translate<T>(this DbDataReader reader, Func<IDataRecord, T> objectMaterializer)
        {
            return Translate(reader, objectMaterializer, out var hasNextResults);
        }
        public static IList<T> Translate<T>(this DbDataReader reader, Func<IDataRecord, T> objectMaterializer,
            out bool hasNextResult)
        {
            var results = new List<T>();
            while (reader.Read())
            {
                var record = (IDataRecord)reader;
                var obj = objectMaterializer(record);
                results.Add(obj);
            }
            hasNextResult = reader.NextResult();
            return results;
        }



    }



    public static class Materializer
    {
        public static T Materialize<T>(IDataRecord record) where T : new()
        {
            var t = new T();
            foreach (var prop in typeof(T).GetProperties())
            {
                // 1). If entity reference, bypass it.
                if (prop.PropertyType.Namespace == typeof(T).Namespace)
                {
                    continue;
                }
                // 2). If collection, bypass it.
                if (prop.PropertyType != typeof(string) && typeof(IEnumerable).IsAssignableFrom(prop.PropertyType))
                {
                    continue;
                }
                // 3). If property is NotMapped, bypass it.
                if (Attribute.IsDefined(prop, typeof(NotMappedAttribute)))
                {
                    continue;
                }
                var dbValue = record[prop.Name];
                if (dbValue is DBNull) continue;
                if (prop.PropertyType.IsConstructedGenericType &&
                    prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    var baseType = prop.PropertyType.GetGenericArguments()[0];
                    var baseValue = Convert.ChangeType(dbValue, baseType);
                    var value = Activator.CreateInstance(prop.PropertyType, baseValue);
                    prop.SetValue(t, value);
                }
                else
                {
                    var value = Convert.ChangeType(dbValue, prop.PropertyType);
                    prop.SetValue(t, value);
                }
            }
            return t;
        }
    }


    public static class DataTableConverter
    {
        public static DataTable ConvertToDataTable<T>(this IEnumerable<T> dataList) where T : class
        {
            DataTable convertedTable = new DataTable();
            PropertyInfo[] propertyInfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in propertyInfo)
            {
                convertedTable.Columns.Add(prop.Name);
            }
            foreach (T item in dataList)
            {
                var row = convertedTable.NewRow();
                var values = new object[propertyInfo.Length];
                for (int i = 0; i < propertyInfo.Length; i++)
                {
                    var test = propertyInfo[i].GetValue(item, null);
                    row[i] = propertyInfo[i].GetValue(item, null);
                }
                convertedTable.Rows.Add(row);
            }
            return convertedTable;
        }
    }
}
