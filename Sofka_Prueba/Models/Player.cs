using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sofka_Prueba.Models
{
    public class Player
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int MaxPoints { get; set; }
    }
}