using TrueAquarius.ConfigManager;

namespace MyCompany;

internal class MyOtherConfiguration : ConfigManager<MyOtherConfiguration>
{
    public string Name { get; set; } = "Other Default User";
    public int Number { get; set; } = 100;
    public bool Flag { get; set; } = false;
    public DateTime LastModified { get; set; } = DateTime.Now;
}
