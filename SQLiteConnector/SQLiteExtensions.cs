using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace SQLiteConnector {
    internal static class SQLiteExtensions {
        internal static SQLiteCommand CreateCommand(this System.Data.SQLite.SQLiteConnection connection, String command) {
            return new SQLiteCommand(command, connection);
        }
        internal static SQLiteCommand CreateCommand(this System.Data.SQLite.SQLiteConnection connection, String command, Dictionary<String, Object> parameters) {
            var cmd = connection.CreateCommand(command);
            cmd.Parameters.AddRange((from p in parameters select new SQLiteParameter(p.Key, p.Value)).ToArray());
            return cmd;
        }
        internal static T[] ExecuteQuery<T>(this SQLiteCommand command) {
            var result = new List<T>();
            var reader = command.ExecuteReader();
            while (reader.Read()) {
                var instance = (T)Activator.CreateInstance(typeof(T));
                for (int i = 0; i < reader.FieldCount; i++) {
                    var prop = typeof(T).GetProperty(reader.GetName(i));
                    prop.SetValue(instance, reader[i] == DBNull.Value ? null : reader[i], null);
                }
                result.Add(instance);
            }
            reader.Close();
            return result.ToArray();
        }
    }
}
