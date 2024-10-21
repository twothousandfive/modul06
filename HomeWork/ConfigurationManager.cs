using System;
using System.Collections.Generic;

public class ConfigurationManager
{
    // Статическое поле для хранения единственного экземпляра класса
    private static ConfigurationManager instance = null;

    // Для обеспечения потокобезопасности
    private static readonly object lockObject = new object();

    // Словарь для хранения настроек
    private Dictionary<string, string> settings;

    // Приватный конструктор, чтобы предотвратить создание объектов вне класса
    private ConfigurationManager()
    {
        settings = new Dictionary<string, string>();
    }

    // Метод для получения единственного экземпляра класса (с ленивой инициализацией)
    public static ConfigurationManager GetInstance()
    {
        // Проверяем, существует ли уже экземпляр
        if (instance == null)
        {
            // Используем блокировку для потокобезопасного доступа
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new ConfigurationManager();
                }
            }
        }
        return instance;
    }

    // Метод для загрузки настроек
    public void LoadSettings(Dictionary<string, string> newSettings)
    {
        foreach (var setting in newSettings)
        {
            settings[setting.Key] = setting.Value;
        }
    }

    // Метод для получения настройки по ключу
    public string GetSetting(string key)
    {
        if (settings.ContainsKey(key))
        {
            return settings[key];
        }
        return null;
    }

    // Метод для изменения настройки
    public void SetSetting(string key, string value)
    {
        settings[key] = value;
    }
    
    public void DisplayAllSettings()
    {
        Console.WriteLine("Настройки приложения:");
        foreach (var setting in settings)
        {
            Console.WriteLine($"{setting.Key}: {setting.Value}");
        }
    }
}
