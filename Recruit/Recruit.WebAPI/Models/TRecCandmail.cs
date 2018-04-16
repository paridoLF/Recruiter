using System;
using System.Collections.Generic;

namespace Recruit.WebAPI.Models
{
    public partial class TRecCandmail
    {
        public TRecCandmail()
        {
            TRecDetmailkword = new HashSet<TRecDetmailkword>();
        }

        public int Pkcandmail { get; set; }
        public string Correo { get; set; }
        public string Filename { get; set; }

        public ICollection<TRecDetmailkword> TRecDetmailkword { get; set; }
    }
}
