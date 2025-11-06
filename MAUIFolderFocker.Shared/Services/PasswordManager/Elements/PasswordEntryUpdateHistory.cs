using MAUIFolderFocker.Shared.Services.PasswordManager.Valiables;
using MAUIPasswordMenager.Shared.Services.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIFolderFocker.Shared.Services.PasswordManager.Elements
{
    public class PasswordEntryUpdateHistory
    {

        public string ChangeId { get; set; }
        public PasswordEntryEnum ChangedField { get; set; }
        public EnumDatatype OldValueType { get; set; }
        public string OldValue { get; set; }
        public EnumDatatype NewValueType { get; set; }
        public string NewValue { get; set; }
        public DateTime UpdatedAt { get; set; }

        public PasswordEntryUpdateHistory(PasswordEntryEnum entryEnumToChange, object oldValue, object newValue)
        {
            ChangedField = new PasswordEntryEnum();
            OldValue = oldValue.ToString() ?? "null";
            NewValue = oldValue.ToString() ?? "null";
        }
        public T GetChangeType <T>()
        {
            return (T) Convert.ChangeType(OldValue, typeof(T));
        }
        public void  SaveChanges()
        {

        }









    }
}
