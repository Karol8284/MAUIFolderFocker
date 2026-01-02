using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.PasswordGenerator.Faces
{
    public interface IWordPasswordGeneratorInput
    {
        public int NumberOfWords { get; set; }
        public int IncludeUppercaseLength { get; set; }
        public int IncludeLowercaseLength { get; set; }
        public int IncludeNumbersLength { get; set; }
        public int IncludeSymbolsLength { get; set; }
        public int IncludeFirstLetersUpercaseLength { get; set; }
        string PasswordSeperator { get; set; }

    }
}
