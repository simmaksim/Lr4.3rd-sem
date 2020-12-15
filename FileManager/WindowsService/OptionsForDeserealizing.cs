namespace Lr4Win
{
    public class OptionsForDeserealizing
    {
        public string target { get; set; }

        public string source { get; set; }

        public string extract { get; set; }

        public string start { get; set; }

        public string xmlfold { get; set; }

        public string jsonfold { get; set; }

        public string connectionString { get; set; }

        public string connectionString4Errors { get; set; }

        public OptionsForDeserealizing()
        {
            target = @"C:\Lr4\archive";

            source = @"C:\Lr4\source";

            extract = @"C:\Lr4\Extract";

            start = @"C:\Lr4";

            xmlfold = @"C:\Lr4\source\config2.xml";

            jsonfold = @"C:\Lr4\source\appsettings2.json";

            connectionString = @"Data Source=DESKTOP-JQVP94F\SQLEXPRESS;Initial Catalog=AdventureWorks2019;Integrated Security=True";

            connectionString4Errors = @"Data Source=DESKTOP-JQVP94F\SQLEXPRESS;Initial Catalog=ErrorDB;Integrated Security=True";
        }

    }

}