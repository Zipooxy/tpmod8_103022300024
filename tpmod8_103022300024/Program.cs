// See https://aka.ms/new-console-template for more information

using System;
using System.IO;
using System.Text.Json;

class CovidConfig
{
    public string CONFIG1 { get; set; } = "celcius";
    public int CONFIG2 { get; set; } = 14;
    public string CONFIG3 { get; set; } = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
    public string CONFIG4 { get; set; } = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

    public void UbahSatuan()
    {
        CONFIG1 = CONFIG1 == "celcius" ? "fahrenheit" : "celcius";
    }

    public static CovidConfig LoadConfig(string filePath)
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<CovidConfig>(json) ?? new CovidConfig();
        }
        return new CovidConfig();
    }

    public void SaveConfig(string filePath)
    {
        string json = JsonSerializer.Serialize(this);
        File.WriteAllText(filePath, json);
    }
}


