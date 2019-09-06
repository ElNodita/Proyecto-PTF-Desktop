using System;
using System.Collections.Generic;
using System.Text;
using Oracle.ManagedDataAccess.Client;

namespace Negocio
{
    class Enlace
    {
        public void conn()
        {
            OracleConnection conexion = new OracleConnection("DATA SOURCE = xe; PASSWORD = ptfBD ; USER ID = ptfBD");
        }
    }
}
