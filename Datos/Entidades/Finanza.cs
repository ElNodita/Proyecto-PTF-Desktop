using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Datos.Entidades
{
    public class Finanza
    {
        //Atributos de clase
        public string Region { get; set; }
        public int Monto { get; set; }

        public string Fecha { get; set; }
        public int Ingreso { get; set; }
        //Constructor
        public Finanza()
        {
            Init();
        }
        //Inicializador vacío
        public void Init()
        {
            Region = string.Empty;
            Monto = 0;
        }
    }
}
