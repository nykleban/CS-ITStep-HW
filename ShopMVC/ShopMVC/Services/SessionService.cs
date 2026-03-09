using System.Text.Json;

namespace ShopMVC.Services
{
    public static class SessionService
    {
        public static void Set<T>(this ISession session, string key, T data)
        {
            session.SetString(key, JsonSerializer.Serialize(data));
        }

        public static T? Get<T>(this ISession session, string key)
        {
            var json = session.GetString(key);

            if (string.IsNullOrEmpty(json))
                return default;

            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
