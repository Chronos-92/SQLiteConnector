using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace SQLiteConnector
{
    public class SQLiteConnection : IDisposable {

        private System.Data.SQLite.SQLiteConnection conn;

        public SQLiteConnection(String Database) {
            conn = new System.Data.SQLite.SQLiteConnection(string.Format("Data Source={0};Version=3;", Database));
        }
        public void Dispose() {
            conn.Dispose();
        }

        public void Open() {
            conn.Open();
        }
        public void Close() {
            conn.Close();
        }

        public T[] ExecuteQuery<T>(String query) {
            return conn.CreateCommand(query).ExecuteQuery<T>();
        }
        public T[] ExecuteQuery<T>(String query, SQLiteTransaction transaction) {
            return conn.CreateCommand(query, transaction).ExecuteQuery<T>();
        }
        public T[] ExecuteQuery<T>(String query, Dictionary<String, Object> parameters) {
            return conn.CreateCommand(query, parameters).ExecuteQuery<T>();
        }
        public T[] ExecuteQuery<T>(String query, Dictionary<String, Object> parameters, SQLiteTransaction transaction) {
            return conn.CreateCommand(query, parameters, transaction).ExecuteQuery<T>();
        }
        public Int64 ExecuteNonQuery(String query) {
            return conn.CreateCommand(query).ExecuteNonQuery();
        }
        public Int64 ExecuteNonQuery(String query, SQLiteTransaction transaction) {
            return conn.CreateCommand(query, transaction).ExecuteNonQuery();
        }
        public Int64 ExecuteNonQuery(String query, Dictionary<String, Object> parameters) {
            return conn.CreateCommand(query, parameters).ExecuteNonQuery();
        }
        public Int64 ExecuteNonQuery(String query, Dictionary<String, Object> parameters, SQLiteTransaction transaction) {
            return conn.CreateCommand(query, parameters, transaction).ExecuteNonQuery();
        }
        public SQLiteTransaction BeginTransaction() {
            return conn.BeginTransaction();
        }
        public SQLiteTransaction BeginTransaction(IsolationLevel isolationlevel) {
            return conn.BeginTransaction(isolationlevel);
        }
    }
}
