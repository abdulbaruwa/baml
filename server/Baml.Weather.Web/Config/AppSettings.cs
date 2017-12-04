namespace Baml.Weather.Web.Config
{
    public class LogLevel
    {
        public string Default { get; set; }
    }

    public class Debug
    {
        public LogLevel LogLevel { get; set; }
    }
    
    public class Console
    {
        public LogLevel LogLevel { get; set; }
    }

    public class Logging
    {
        public bool IncludeScopes { get; set; }
        public Debug Debug { get; set; }
        public Console Console { get; set; }
    }

    public class AppKey
    {
        public string Key { get; set; }
    }

    public class AppSettings
    {
        public Logging Logging { get; set; }
        public AppKey AppKey { get; set; }
    }

}