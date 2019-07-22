namespace Infrastructure.Models.Errors
{
    public class FileDoesNotContainInfo : Error
    {
        private string FileName { get; }

        public override string Message
        {
            get
               => $@"'{FileName}' file should contain your email and 
                               password of your dating website in such format:
                                           email=my_email@gmail.com;  
                                           password=my_passwd;";
        }
        public FileDoesNotContainInfo(string fileName)
        {
            FileName = fileName;
        }
    }
}
