using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassCapaEntidades
{
    public class EntidadGrupoCuatrimestre
    {
        public int Id_GrupCuat { set; get; }
        public byte F_ProgEd { set; get; }
        public short F_Grupo { set; get; }
        public short F_Cuatri { set; get; }
        public string Turno { set; get; }
        public string Extra { set; get; }

    }
}
