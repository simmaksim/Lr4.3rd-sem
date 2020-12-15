using Lr4Win;
using System.IO;
using System.Collections.Generic;

namespace ConfigurationManager
{
    public class RelocateOfFiles
    {
        private ConfigurationProvider provide = new ConfigurationProvider();
        public List<OptionsForDeserealizing> opt = new List<OptionsForDeserealizing>();
        private string relocatingSt;
        private string relocatingXML;
        private string relocatingJ;
        
        public RelocateOfFiles()
        {
            opt = provide.GetOption();
            relocatingSt = opt[0].start;
            relocatingXML = opt[0].xmlfold;
            relocatingJ = opt[0].jsonfold;
        }
        
        public void Relocate()
        {
             
            string[] Files = new string[100];
            Files = Directory.GetFiles(relocatingSt);
            foreach (string s in Files)
            {

                if (Path.GetExtension(s) == ".json")
                {
                    if (File.Exists(relocatingJ)) 
                    {
                        File.Delete(relocatingJ);
                        File.Move(s, relocatingJ);
                    }
                    else
                    {
                        File.Move(s, relocatingJ);
                    }
                    
                    
                }
                else
                {
                    if(Path.GetExtension(s) == ".xml")
                    {
                        File.Delete(relocatingXML);
                        File.Move(s, relocatingXML);
                    }
                    else
                    {
                        File.Move(s, relocatingXML);
                    }
                }
            }
        }
    }
}
