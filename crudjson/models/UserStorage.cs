using System.Collections.Generic;
using System.Text.Json;
public class UserStorage
{
    private static string filepath = "users.json";
    public static List<User> Load()
    {
        try
        {
            if (!File.Exists(filepath))
            {
                return new List<User>();
            }

            var json = File.ReadAllText(filepath);
            return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        } catch
        {
            return new List<User>();
        }
    }   

    public static void Save(List<User> users)
    {
        var json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filepath, json);
    }

}