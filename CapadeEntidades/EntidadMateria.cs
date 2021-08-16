using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassCapaEntidades
{
    public class EntidadMateria
    {
        public int id_Materia { set; get; }
        public string NombreMateria { set; get; }
        public byte HorasSemana { set; get; }
        public string Extra { set; get; }
    }
}
