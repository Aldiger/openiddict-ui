using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenIddict.UI.Tests;

public static class HttpExtensions
{
  public static async Task<T> ReadAsJsonAsync<T>(this HttpContent httpContent)
  {
    var obj = await httpContent.ReadAsStringAsync();

    return JsonSerializer.Deserialize<T>(obj, new JsonSerializerOptions
    {
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    });
  }
}
