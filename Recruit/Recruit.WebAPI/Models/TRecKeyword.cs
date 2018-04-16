using System;
using System.Collections.Generic;

namespace Recruit.WebAPI.Models
{
    public partial class TRecKeyword
    {
        public TRecKeyword()
        {
            TRecDetmailkword = new HashSet<TRecDetmailkword>();
        }

        public int Pkkword { get; set; }
        public string Keyword { get; set; }

        public ICollection<TRecDetmailkword> TRecDetmailkword { get; set; }
    }
}
