using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoomsdayArmadurasMvc.Models
{
    public class Armadura
    {   
        [Key]
        public int ArmaduraId { get; set; }
        [Required, MaxLength(60)]
        public string Nombre { get; set; }
        [Range(1,7)]
        public int Nivel { get; set; }
        public string Portador { get; set; }
        
        public int ReinoId { get; set; }
        public virtual Reino Reino { get; set; }
    }
}