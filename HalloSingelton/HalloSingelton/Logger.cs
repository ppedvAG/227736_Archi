namespace HalloSingelton
{
    public class Logger
    {
        static Logger instance;
        private static object instanceLock = new object();

        public static Logger Instance
        {
            get
            {
                if (instance == null)
                    lock (instanceLock)
                    {
                        if (instance == null)
                            instance = new Logger();
                    }
                return instance;
            }
        }

        private Logger()
        {
            Info("new Logger");
        }

        public void Info(string message)
        {
            Console.WriteLine($"{DateTime.Now:G} [INFO] {message}");
        }
    }
}
