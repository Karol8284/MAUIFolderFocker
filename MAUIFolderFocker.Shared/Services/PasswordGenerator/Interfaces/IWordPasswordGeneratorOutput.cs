namespace MAUIFolderFocker.Shared.Services.PasswordGenerator.Faces
{
    public interface IWordPasswordGeneratorOutput : IWordPasswordGeneratorInput
    {
        new int NumberOfWords { get; set; }
        new string PasswordSeperator { get; set; }
        public string GeneratedPassword { get; set; }
        public int UppercaseLength { get; set; }
        new public int IncludeLowercaseLength { get; set; }
        public int NumbersLength { get; set; }
        public int SymbolsLength { get; set; }
        public int FirstLetersUpercaseLength { get; set; }
        long GenerationTimeMs { get; set; }
        string ErrorMessage { get; set; }
    }
}
