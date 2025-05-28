using ConfigManager.Example;

Console.WriteLine("Hello, World!");

var config = MyConfiguration.Instance;
config.Name = "Test User";
config.Number = 42;
config.Flag = true;
config.LastModified = DateTime.Now;
config.Save();
