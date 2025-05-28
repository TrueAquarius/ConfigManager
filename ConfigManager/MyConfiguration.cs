using TrueAquarius.ConfigManager;


namespace ConfigManager.Example
{
    public class MyConfiguration : ConfigManager<MyConfiguration>
    {
        public string Name { get; set; } = "Default User";
        public int Number {  get; set; }
        public bool Flag { get; set; }
        public DateTime LastModified { get; set; }
    }
}
