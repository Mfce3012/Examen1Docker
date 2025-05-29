using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1.BL
{
    public interface IAdministradorDeApartamentos
    {

        void AgregueUnApartamento(Model.Apartamento apartamento);
        List<Model.Apartamento> ObtenerListaDeApartamentosDisponibles();
        List<Model.Apartamento> ObtenerListaApartamentosAlquilados();
        Model.Apartamento ObtenerApartamentoPorId(int id);
        List<Model.Apartamento> ObtenerListaDeApartamentos();

        void EditeElApartamento(Model.Apartamento apartamento);
        void Alquile(int id, string identificacionInquilino, string nombreInquilino, DateTime fechaInicio, int cantidadMeses);



    }
}
