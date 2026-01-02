using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIAdvancePasswordGenerator.Shared.Services.PasswordGenerator.Interfaces
{
    public interface IWordStorageService
    {
        Task<IReadOnlyList<string>> GetWordsAsync();
    }
}
