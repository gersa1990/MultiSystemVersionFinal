using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;

namespace MultiSystem.core.DB
{
	/// <summary>
	/// Database class to perfom querys and get rows.
	/// </summary>
	public class DataBase
	{	
		private 	string 			databaseName;
		private 	Connection 		connection;
        private     MySqlConnection connect;
		private 	MySqlCommand 	command;
		private 	string 			query;
        private     DataTable       table;

        private List<Dictionary<string, string>> result;
		
		public DataBase()
		{
			
		}

        private void connectionDB(string database)
        {
            connection = new Connection(database);
            connect = new MySqlConnection(connection.MyConnectionString);
            
            this.databaseName = database;
        }

        /// <summary>
        ///  Method to execute advanced querys, buth only process select query
        /// </summary>
        /// <param name="database">Database name</param>
        /// <param name="table">Table name</param>
        /// <param name="query">Query formed string</param>
        public DataBase Query(string database, string query) 
        {
            this.connectionDB(database);
            this.query = query;
            this.__executeSelectQuery();
            return this;
        }

		/// <summary>
		/// Method from insert 1 row in a database
		/// </summary>
		/// <param name="database">The database name</param>
		/// <param name="table">The table name</param>
		/// <param name="fields">Array with fields from database</param>
		/// <returns>Return id from field in database</returns>
		public int Insert(string database, string table, Dictionary<string, string> fields)
		{
            this.connectionDB(database);
            this.insertInto(table, fields);
            return this.executeInsertQuery(fields);
		}

        private void insertInto(string table, Dictionary<string, string> fields) 
        {
            this.query = "INSERT INTO " + table + " ";

            //this.query += " WHERE ";
            string auxKeys = " ( "; 
            string auxValues = " VALUES ( ";
            int i = fields.Count;
            foreach (var pair in fields)
            {
                i--;

                if (i == 0)
                {
                    auxKeys += " " + pair.Key + " ) ";
                    auxValues += " @" + pair.Key + ") ";
                }
                else
                {
                    auxKeys += " " + pair.Key + " , ";
                    auxValues += " @" + pair.Key + ", ";
                }
            }

            this.query += " "+auxKeys+" "+auxValues+" ;";

            Console.WriteLine("Query: "+this.query);
        }
		
		public int Delete(string database, string table, Dictionary <string, string> whereParameters)
		{
            this.connectionDB(database);
            this._delete(table, whereParameters);
            return this._executeDeleteQuery();
		}

        private void _delete(string table, Dictionary<string, string> whereParameters) 
        {
            this.query = "DELETE FROM "+table+" WHERE ";
            int i = whereParameters.Count;

            foreach (var pair in whereParameters)
            {
                i--;

                if (i == 0)
                {
                    this.query += " " + pair.Key + " = " + pair.Value+" ";
                }
                else
                {
                    this.query += " " + pair.Key +" = " + pair.Value + " AND ";
                }
            }

            Console.WriteLine("Antes: " + this.query);
            
        }

        private int _executeDeleteQuery() 
        {
            try
            {
                connect.Open();
                command = connect.CreateCommand();
                command.CommandText = this.query;

            }
            catch
            {
                MessageBox.Show("No se puede conectar con la base de datos.");
            }

            try
            {
                return command.ExecuteNonQuery();
            }
            catch
            {
                return 0;
            }
            finally
            {
                connect.Close();
            }
        }
		
        /// <summary>
        ///  Update table
        /// </summary>
        /// <param name="parameters">Parameters to update</param>
        /// <param name="whereParameters">Conditions for update</param>
        /// <returns></returns>
		public int Update(string database, string table, Dictionary<string, string> parameters, Dictionary<string, string> whereParameters)
		{
            this.connectionDB(database);
            this._update(table, parameters);
            this.__where(whereParameters);

            return this._executeUpdateQuery();
		}

        private int _executeUpdateQuery() 
        {
            try
            {
                connect.Open();
                command = connect.CreateCommand();
                command.CommandText = this.query;
                Console.WriteLine("Query: " + this.query);
            }
            catch
            {
                MessageBox.Show("No se puede conectar con la base de datos.");
            }

            try
            {
                return command.ExecuteNonQuery();
            }
            catch
            {
                return 0;
            }
            finally
            {
                connect.Close();
            }
        }

        private void _update(string table, Dictionary<string, string> parameters) 
        {
            this.query = "UPDATE " + table + " SET "; 
            int i = parameters.Count;
            foreach (var pair in parameters)
            {
                i--;

                if (i == 0)
                {
                    this.query += " " + pair.Key + " = " + pair.Value + " ";
                }
                else
                {
                    this.query += " " + pair.Key + " = " + pair.Value + " , ";
                }

            }
        }

		/// <summary>
		/// Method from get items from Database in DataBase class fromat. Read about rowArray OR resultArray
		/// </summary>
		/// <param name="database">Name of Database</param>
		/// <param name="table">Name of Table</param>
		/// <param name="fields">Dictionary with fields</param>
		/// <returns>Return DataBase  object</returns>
		public DataBase Select(string database, string table)
		
        {
            this.connectionDB(database);
            this.__from(table);
            this.__executeSelectQuery();
			return this;
		}

        private void __executeSelectQuery() 
        {
            try
            {
                connect.Open();
                command = connect.CreateCommand();
                command.CommandText = this.query;
                
            }
            catch 
            {
                MessageBox.Show("No se puede conectar con la base de datos.");
            }

            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset,"fields");
                this.table = dataset.Tables["fields"];
            }
            catch(MySqlException e)
            {
                MessageBox.Show("Error mysql: "+e.ToString());
            }
            finally 
            {
                connect.Close();
            }
        }

        public int executeInsertQuery(Dictionary<string, string> whereConditions) 
        {
            int idReturn = 0;
            try
            {
                connect.Open();
                command = connect.CreateCommand();
                command.CommandText = this.query;
            }
            catch
            {
                MessageBox.Show("No se puede conectar con la base de datos.");
                return 0;
            }

            foreach (var pair in whereConditions)
            {
                command.Parameters.AddWithValue("@" + pair.Key, pair.Value);
            }

            try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    connect.Close();

                    connect.Open();
                    command = connect.CreateCommand();
                    command.CommandText = "SELECT LAST_INSERT_ID()";
                    IDataReader reader = command.ExecuteReader();

                    if (reader != null && reader.Read())
                    {
                        idReturn = unchecked((int)reader.GetInt64(0));
                    }
                    connect.Close();

                    return idReturn;
                }
            }
            catch (Exception e) 
            {
                MessageBox.Show("Vaya algo salió mal. Espera y veremos que es."+e.ToString());
                return 0;
            }
            
            

            return 0; 
        }

        private void __from(string table) 
        {
            this.query = "SELECT * FROM " + table+" ";
        }

        private void __where(Dictionary<string, string> whereConditions) 
        {
            this.query += " WHERE ";
            int i = whereConditions.Count;
            foreach (var pair in whereConditions) 
            {
                i--;
         
                if (i == 0)
                {
                    this.query += " " + pair.Key + " = " + pair.Value + " ";
                }
                else 
                {
                    this.query += " " + pair.Key + " = " + pair.Value + " AND ";
                }
                
            }



            System.Console.WriteLine(this.query);
        }
		
		public DataBase Where(Dictionary<string, string> whereFields)
		{
            this.__where(whereFields);
			return this;
		}

        public DataBase Select_where(string database, string table, Dictionary<string, string> whereConditions)
		{
            this.connectionDB(database);
            this.__from(table);
            this.__where(whereConditions);
            this.__executeSelectQuery();
            return this;
		}

        public List<Dictionary<string, string>> rowArray()
		{
            Dictionary<string, string> aux;
            this.result = new List<Dictionary<string, string>>();

            if (this.table.Rows.Count == 0)
                return null;

            foreach (DataRow row in this.table.Rows)
            {
                aux = new Dictionary<string, string>();
                foreach (DataColumn column in this.table.Columns)
                {
                    aux.Add(column.ColumnName, row[column].ToString());
                }
                this.result.Add(aux);

                return this.result;
            }

            if (this.result.Count > 0)
                return this.result.GetRange(0, 1);
            else
                return null;
		}

        public List<Dictionary<string, string>> resultArray() 
        {
            result = new List<Dictionary<string, string>>();

            Dictionary<string, string> aux;

            if (this.table.Rows.Count<0) 
            {
                return null;
            }
            try
            {
                foreach (DataRow row in this.table.Rows)
                {
                    aux = new Dictionary<string, string>();
                    foreach (DataColumn column in this.table.Columns)
                    {
                        aux.Add(column.ColumnName, row[column].ToString());
                    }
                    this.result.Add(aux);
                }
            }
            catch(MySqlException e) 
            {
                MessageBox.Show("Eror en result Array: "+e.ToString());
            }
            
            if (this.result.Count > 0)
                return this.result;
            else
                return null;
        }

        public void description() 
        {
            int i = 0;
            foreach (Dictionary<string, string> item in this.result) 
            {
                i++;
                Console.WriteLine("[" + i + "]");
                
                foreach (var pair in item)
                {
                    Console.WriteLine("\t\t "+pair.Key+" => "+pair.Value);
                }
            }
        }
	}
}