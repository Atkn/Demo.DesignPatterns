using System;

namespace Factory.DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new LoggerFactory());
            ProductManager productManagerx = new ProductManager(new ApiStateLoggerFactory());
            productManagerx.Save();
            productManager.Save();
            Console.ReadLine();
        }
    }

    public class LoggerFactory : ILoggerFactory
    {
        public ILogger CreateLog()
        {
            return new Logger();
        }
    }

    public interface ILogger
    {
        void LogMethod();
        void ApiLogMethod();
    }
    public interface ILoggerFactory
    {
        ILogger CreateLog();
    }

    public class ApiStateLoggerFactory : ILoggerFactory
    {
       

        public ILogger CreateLog()
        {
            return new Logger();
        }
    }

    public interface IApiStateLoggerFactory
    {

    }

    public class Logger : ILogger
    {
        public void ApiLogMethod()
        {
            Console.WriteLine("Logged for api");
        }

        public void LogMethod()
        {
            Console.WriteLine("Logged with edlogger");
        }
    }

    public class ApiLogger : ILogger
    {
        public void ApiLogMethod()
        {
            Console.WriteLine("Logged for API");
        }

        public void LogMethod()
        {
            Console.WriteLine("Log Method");
        }
    }
    public class ProductManager
    {
        private ILoggerFactory _loggerFactory;
        public ProductManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        public void Save()
        {
            Console.WriteLine("saved");
            ILogger logger = _loggerFactory.CreateLog();
            logger.LogMethod();
            logger.ApiLogMethod();
            
        }
    }
}
