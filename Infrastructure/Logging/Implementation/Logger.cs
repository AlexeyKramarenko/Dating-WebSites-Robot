using System.IO;

namespace Infrastructure.Logging.Implementation
{
    public class Logger : ILogger
    {
        private const string FilePath = @"D:\Logs.txt";

        public void Log(string message)
        {
            using (var streamWriter = new StreamWriter(FilePath))
            {
                streamWriter.WriteLine(message);
                streamWriter.Close();
            }
        }
    }
}
