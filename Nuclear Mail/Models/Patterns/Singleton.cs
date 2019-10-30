namespace Nuclear_Mail.Models.Patterns
{
    public class Singleton<T> where T: new()
    {
        private static T _instance = new T();
        private static object _lock = new object();

        public static T Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance != null) return _instance;

                    _instance = new T();
                    return _instance;
                }
            }
        }
    }
}
