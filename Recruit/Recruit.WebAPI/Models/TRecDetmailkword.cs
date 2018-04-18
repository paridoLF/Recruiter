using System;
using System.Collections.Generic;

namespace Recruit.WebAPI.Models 
{
    public partial class TRecDetmailkword
    {
        public int Pkdetmailkword { get; set; }
        public int Fkcandmail { get; set; }
        public int Fkkword { get; set; }

        public TRecCandmail FkcandmailNavigation { get; set; }
        public TRecKeyword FkkwordNavigation { get; set; }
    }
}
