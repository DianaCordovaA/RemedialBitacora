using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassCapaEntidades
{
    public class EntidadCuatrimestre
    {

        public int id_cuatri { get; set; }
        public string periodo { get; set; }

        public int anio { get; set; }

        public string inicio { get; set; }

        public string fin { get; set; }

        public string extra { get; set; }
    }
}
