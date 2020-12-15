using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using Lr4Win;
using Models;
using LoggerToDB;


namespace DataAccessLayer
{
    public class ConnectionToDataBase
    {
        internal SqlConnection connection;
        private ConfigurationProvider provider = new ConfigurationProvider();
        private List<OptionsForDeserealizing> list = new List<OptionsForDeserealizing>();      
       

        internal string ConnectionString { get; }

        internal ConnectionState info { get; set; }
        public ConnectionToDataBase()
        {
            
            list = provider.GetOption();

            ConnectionString  = list[0].connectionString;
            connection = new SqlConnection(ConnectionString);
        }

        private Person pers = new Person();
        public List<Person> persList = new List<Person>();
        private ErrorLogger logger = new ErrorLogger();

        public List<Person> ConnectAndInteract()
        {
            try
            {
                connection.Open();
                string procedureName = "dbo.TablesConnection";

                
                using (SqlCommand command = new SqlCommand(procedureName, connection))
                {
                    SqlConnection test = command.Connection;
                    using (SqlDataReader reader =  command.ExecuteReader())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                pers.Name = (string)reader[0];
                                persList.Add(pers);
                            }
                        }
                    }
                }

            }
            catch (Exception e)
            {
                logger.WriteErrorsToDataBase(e.Message);
                MessageBox.Show(e.Message, "Connecting", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return persList;
        }
        public string GetDataBaseInfo()
        {
            info = connection.State;
            string DBInfo = info.ToString();
            return DBInfo;
        }
        public void Disconnect()
        {
            try
            {
                connection.Close();
            }
            catch (Exception e)
            {
                logger.WriteErrorsToDataBase(e.Message);
                MessageBox.Show(e.Message, "Connecting", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
