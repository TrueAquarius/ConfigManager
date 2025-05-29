using TrueAquarius.ConfigManager;

namespace MyCompany.MyApp
{
    public class MyConfiguration : ConfigManager<MyConfiguration>
    {
        public string Name { get; set; } = "Default User";
        public int Number {  get; set; }
        public bool Flag { get; set; }
        public DateTime LastModified { get; set; }
    }
}
