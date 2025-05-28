using System.ComponentModel;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TrueAquarius.ConfigManager;

public abstract class ConfigManager<T> where T : ConfigManager<T>, new()
{
    private static T? _instance;
    private static readonly object _lock = new();

    
    [JsonIgnore]
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    _instance ??= Load();
                }
            }
            return _instance!;
        }
    }

    private static string GetConfigPath()
    {
        var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MyCliApp");
        Directory.CreateDirectory(folder);
        return Path.Combine(folder, "Configuration.json");
    }

    private static T Load()
    {
        var path = GetConfigPath();
        if (File.Exists(path))
        {
            try
            {
                var json = File.ReadAllText(path);
                return JsonSerializer.Deserialize<T>(json)!;
            }
            catch { }
        }

        return new T();
    }

    public void Save()
    {
        var path = GetConfigPath();
        var json = JsonSerializer.Serialize((T)this, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, json);
    }
}
