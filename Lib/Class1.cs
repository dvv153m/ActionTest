using System.Collections.Concurrent;

namespace Lib
{
    public static class IoC2
    {
        private static ThreadLocal<ConcurrentDictionary<string, string>> IoC = new();

        public static void Register(string key, string value)
        {
            if (IoC.Value == null)
                IoC.Value = new ConcurrentDictionary<string, string>();

            IoC.Value.TryAdd(key, value);
        }

        public static string Resolve(string key)
        {
            var res = IoC.Value.TryGetValue(key, out string value);

            return value;
        }
    }
}