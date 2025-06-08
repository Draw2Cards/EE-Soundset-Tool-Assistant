using System.Text.Json;

namespace EE_soundset_tool
{
    internal class SettingsManager
    {
        public static void Save(FormData data)
        {
            File.WriteAllText("save.json", JsonSerializer.Serialize(data));
        }

        public static FormData? Load()
        {
            if (File.Exists("save.json"))
            {
                var data = JsonSerializer.Deserialize<FormData>(File.ReadAllText("save.json"));
                if (data != null)
                    return data;
            }

            return null;
        }
    }
}
