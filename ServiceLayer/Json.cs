using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using Models;
using DataAccessLayer;
using System;
using LoggerToDB;

namespace Serv
{
    public class Json : ICfgGen
    {
        private List<Person> list = new List<Person>();
        private ConnectionToDataBase connect = new ConnectionToDataBase();
        private ErrorLogger logger = new ErrorLogger();
        public void Gen()
        {
            try
            {
                list = connect.ConnectAndInteract();

                var json = JsonSerializer.Serialize(list);

                using (var jsonStream = new StreamWriter(new FileStream(@"C:\Lr4\appsettings2.json", FileMode.OpenOrCreate)))
                {
                    jsonStream.WriteLine(json);
                }
            }
            catch(Exception e)
            {
                logger.WriteErrorsToDataBase(e.Message);
            }

                
            

        }
    }
}
