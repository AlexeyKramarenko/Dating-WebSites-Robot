namespace Infrastructure.Models.Errors
{
    public class FileNotFound : Error
    {
        private string FileName { get; }

        public override string Message
        {
            get
               => $"'{FileName}' file should be placed where '.exe' file is situated.";
        }
        public FileNotFound(string fileName)
        {
            FileName = fileName;
        }
    }
}
