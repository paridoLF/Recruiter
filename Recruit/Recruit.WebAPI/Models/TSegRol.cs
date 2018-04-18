using System;
using System.Collections.Generic;

namespace Recruit.WebAPI.Models 
{
    public partial class TSegRol
    {
        public TSegRol()
        {
            TSegMenu = new HashSet<TSegMenu>();
            TSegUsuario = new HashSet<TSegUsuario>();
        }

        public int Pkrol { get; set; }
        public string Nombrerol { get; set; }

        public ICollection<TSegMenu> TSegMenu { get; set; }
        public ICollection<TSegUsuario> TSegUsuario { get; set; }
    }
}
