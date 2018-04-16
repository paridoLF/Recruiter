using System;
using System.Collections.Generic;

namespace Recruit.WebAPI.Models
{
    public partial class TSegMenu
    {
        public int Pkmenu { get; set; }
        public string Etiquetamenu { get; set; }
        public string Urlmenu { get; set; }
        public bool? Staturegister { get; set; }
        public int Fkrol { get; set; }

        public TSegRol FkrolNavigation { get; set; }
    }
}
