using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Domain.Entities
{
    public partial class LocalizeLang
    {
        public int Id { get; set; }
        public string LanguageName { get; set; }
        public string LanguageCode { get; set; }
        public int Sequence { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
