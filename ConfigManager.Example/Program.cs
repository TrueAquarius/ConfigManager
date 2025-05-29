using MyCompany;
using MyCompany.MyApp;

var config = MyConfiguration.Instance;
config.Name = "Test User";
config.Number = 42;
config.Flag = true;
config.LastModified = DateTime.Now;
config.Save();

var otherConfig = MyOtherConfiguration.Instance;
otherConfig.Name = "Other Test User";
otherConfig.Number = 84;
otherConfig.Flag = false;
otherConfig.LastModified = DateTime.Now;
otherConfig.Save();

config.Name = "Test User 2";
config.Number = 11;
config.Flag = true;
config.LastModified = DateTime.Now;
config.Save();