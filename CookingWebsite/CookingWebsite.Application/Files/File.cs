namespace CookingWebsite.Application.Files
{
    public class File
    {
        public byte[] Data { get; private set; }
        public string FileName { get; private set; }
        public string FileExtension { get; private set; }

        public File(
            byte[] data,
            string fileName,
            string fileExtension
            )
        {
            Data = data;
            FileName = fileName;
            FileExtension = fileExtension;
        }
    }
}
