using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Lr4Win
{
    internal class JSONParser : IConfigurationParser
    {
        private string jsonString = "";
        private List<OptionsForDeserealizing> optionsAfterJsonParsing = new List<OptionsForDeserealizing>();
        public virtual List<OptionsForDeserealizing> Parse()
        {
            using (var jsonStream = new StreamReader(@"C:\Lr4\FileManager\WindowsService\appsettings.json"))
            {
                jsonString = jsonStream.ReadToEnd();
            }
            OptionsForDeserealizing parametrsAfterJsonParsing = JsonSerializer.Deserialize<OptionsForDeserealizing>(jsonString);

            if (parametrsAfterJsonParsing != null)
            {
                optionsAfterJsonParsing.Add(parametrsAfterJsonParsing);
            }
            else
            {
                throw new NullReferenceException();
            }

            return optionsAfterJsonParsing;
        }
    }
}
