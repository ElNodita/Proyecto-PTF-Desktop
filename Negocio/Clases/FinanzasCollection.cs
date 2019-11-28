using Datos.Entidades;
using System.Collections.Generic;
using System.Data;

namespace Negocio.Clases
{
    public class FinanzasCollection
    {
        //Método que retorna la lista de los montos por región
        public List<Finanza> ListMontoPorRegion()
        {
            return new FinanzaRepo().MontoPorRegion();
        }

        //Método que retorna lista con los ingresos mensuales
        public List<Finanza> IngresoMensual()
        {
            return new FinanzaRepo().IngresoMensual();
        }

        //Método que retorna departamentos por comuna
        public DataTable ListaDepartamentosComuna(int comuna)
        {
            return new FinanzaRepo().ListaDepartamentoPorComuna(comuna);
        }

        //Método que retorna departamento para finanza
        public DataTable DepartamentoFinanza(int departamento,int mes,int anio)
        {
            return new FinanzaRepo().FinanzaDepartamento(departamento,mes,anio);
        }

    }
}
