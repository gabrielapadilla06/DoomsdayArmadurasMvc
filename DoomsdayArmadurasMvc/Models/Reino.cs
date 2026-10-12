using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoomsdayArmadurasMvc.Models
{
    public class Reino
    {
        [Key]
        public int ReinoId { get; set; }
        [Required, MaxLength(60)]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }
    }
}