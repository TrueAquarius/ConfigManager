using System.ComponentModel;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace TrueAquarius.ConfigManager;

public abstract class ConfigManager<T> where T : ConfigManager<T>, new()
{
    private static T? _instance;
    private static readonly object _lock = new();
    private static string? _configPath;

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
        if(!string.IsNullOrEmpty(_configPath))
        {
            return _configPath;
        }

        // Get the namespace of the implementing class to create the default su-path anf filename
        var type = typeof(T);
        var namespaceName = type.Namespace ?? throw new InvalidOperationException("The namespace of the class which derives from ConfigManager cannot be null.");
        var className = type.Name;
        var subPath = namespaceName.Replace('.', Path.DirectorySeparatorChar);

        var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), subPath);
        Directory.CreateDirectory(folder);
        _configPath = Path.Combine(folder, className + ".json");

        return _configPath;
    }

    private static T Load()
    {
        var path = GetConfigPath();
        if (!File.Exists(path))
        {
            T t = new T();
            Save(t);
        }

        try
        {
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<T>(json)!;
        }
        catch 
        {
            throw new InvalidOperationException($"Failed to load configuration from {path}. The file may be corrupted or in an invalid format.");
        }
    }

    private static void Save(T t)
    {
        var path = GetConfigPath();
        var json = JsonSerializer.Serialize(t, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, json);
    }
    public void Save()
    {
        Save((T)this);
    }
}
