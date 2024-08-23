using System;
using System.Text.Json;
namespace AwesomeDotnetMaui.UtilityExtension;
public static class UtilityExtension
{
    public static T ConvertFromByte<T>(this byte[] byteArray) where T : class
    {
        if (byteArray == null || byteArray.Length == 0)
        {
            throw new ArgumentNullException(nameof(byteArray), "Byte array cannot be null or empty.");
        }

        var jsonString = System.Text.Encoding.UTF8.GetString(byteArray);
        return JsonSerializer.Deserialize<T>(jsonString);
    }

    public static byte[] ConvertToByte<T>(this T obj) where T : class
    {
        if (obj == null)
        {
            throw new ArgumentNullException(nameof(obj), "Object cannot be null.");
        }

        var jsonString = JsonSerializer.Serialize(obj);
        return System.Text.Encoding.UTF8.GetBytes(jsonString);
    }
}


