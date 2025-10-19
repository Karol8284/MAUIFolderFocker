namespace MAUIFolderFocker.Shared.IO.Elements
{
    public class FileObject
    {
        public string Path { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Extension { get; set; } = string.Empty;
        public long Size { get; set; }
        public byte[]? Content { get; set; }

        public FileObject()
        {
        }
    }
}
