using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSofka_Prueba.Clases
{
    public class Player
    {
        private int id;
        private String nombre;
        private DateTime fechaNacimiento;
        private int maximaPuntuacion;

        public Player(int id, string nombre, DateTime fechaNacimiento, int maximaPuntuacion)
        {
            Id = id;
            Nombre = nombre;
            FechaNacimiento = fechaNacimiento;
            MaximaPuntuacion = maximaPuntuacion;
        }

        public int Id { get => id; set => id = value; }
        public String Nombre { get => nombre; set => nombre = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public int MaximaPuntuacion { get => maximaPuntuacion; set => maximaPuntuacion = value; }

    }
}
