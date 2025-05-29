# TrueAquarius.ConfigManager

Use `ConfigManager` for easy access to your configuration files and user preference files in the AppData folder.  This library caters to developers of Desktop and Console Applications.

Find this Library on NuGet.org under the name "TrueAquarius.ConfigManager".

## How to use it ...

Create the class which holds your configuration. An example is shown below.
* It **must** be derived from `ConfigManager` as shown in the example below.
* The properties **must** be `public`. They **must** be true properties with `get;` and `set;`.
* The class itself **can** be either `public` or `internal`.
* It **must** have a namespace (because the namespace defines the subpath under `AppData` and the class name defines the filename). Recommender practice: a namespace with 2 levels: Level 1 is company name, level 2 application name. 
* The class **can** assigne default values to each property (as shown in the example below for the `Name`).

```csharp
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
```
Your configuration class is now a singleton. You an access it anywhere in your code as follows:

```csharp
using MyCompany.MyApp;

var config = MyConfiguration.Instance;
config.Name = "Test User";
config.Number = 42;
config.Flag = true;
config.LastModified = DateTime.Now;
config.Save();
```

## Repository Structure

* **ConfigManager**: The actual Library.
* **ConfigManager.Example**: Sample application which uses the library.


