using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Lr4Win
{
    internal class XMLParser : IConfigurationParser
    {
        public virtual List<OptionsForDeserealizing> Parse()
        {
            string pathToXmlFile = @"C:\Lr4\FileManager\WindowsService\config.xml";
            List<OptionsForDeserealizing> xmlOptionsAfterParsing = new List<OptionsForDeserealizing>();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(OptionsForDeserealizing));
            OptionsForDeserealizing parametrsAfterXmlParsing = new OptionsForDeserealizing();

            using (var xmlRead = new FileStream(pathToXmlFile, FileMode.OpenOrCreate))
            {
                parametrsAfterXmlParsing = (OptionsForDeserealizing)xmlSerializer.Deserialize(xmlRead);
            }

            if (parametrsAfterXmlParsing != null)
            {
                xmlOptionsAfterParsing.Add(parametrsAfterXmlParsing);
            }
            else
            {
                throw new NullReferenceException();
            }

            return xmlOptionsAfterParsing;
        }

    }
}
