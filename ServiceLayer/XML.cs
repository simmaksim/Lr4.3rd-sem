using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Models;
using System.IO;
using DataAccessLayer;

namespace Serv
{
    public class XML : ICfgGen
    {
        private string pathX = @"C:\Lr4\config2.xml";
        private List<Person> pers = new List<Person>();
        private ConnectionToDataBase connect = new ConnectionToDataBase();
        XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));

        public XML()
        {
            pers = connect.ConnectAndInteract();
        }
        public void Gen() 
        {
            using (var xmlStream = new FileStream(pathX, FileMode.OpenOrCreate))
            {
                serializer.Serialize(xmlStream, pers);
            }
        }
            
    }
}
