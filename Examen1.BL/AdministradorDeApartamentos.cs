using Examen1.Model;

namespace Examen1.BL
{
    public class AdministradorDeApartamentos: IAdministradorDeApartamentos
    {

        private Examen1.DA.DBContexto ElContextoDB;

        public AdministradorDeApartamentos(Examen1.DA.DBContexto contextoDB)
        {
            ElContextoDB = contextoDB;
        }

        public void AgregueUnApartamento(Model.Apartamento apartamento)
        {
           
            if (string.IsNullOrWhiteSpace(apartamento.Nombre))
                throw new Exception("El nombre es requerido.");
            if (string.IsNullOrWhiteSpace(apartamento.Descripcion))
                throw new Exception("La descripción es requerida.");
            if (apartamento.NumeroDePiso <= 0)
                throw new Exception("El número de piso es requerido.");
            if (apartamento.PrecioPorMes <= 0)
                throw new Exception("El precio por mes es requerido.");


            // Estado por defecto
            apartamento.Estado = Model.TipoDeEstado.Disponible;

           
            apartamento.IdentificacionInquilino = string.Empty;
            apartamento.NombreInquilino = string.Empty;
            apartamento.FechaInicioAlquiler = DateTime.MinValue;
            apartamento.CantidadDeMesesAlquiler = 0;
            apartamento.DepositoDeGarantia = 0;



            ElContextoDB.Apartamentos.Add(apartamento);
            ElContextoDB.SaveChanges();
        }

        public List<Model.Apartamento> ObtenerListaDeApartamentos()
        {
            var resultado = from c in ElContextoDB.Apartamentos
                            select c;
            return ElContextoDB.Apartamentos.ToList();
        }

        public List<Model.Apartamento> ObtenerListaDeApartamentosDisponibles()
        {
            var resultado = from c in ElContextoDB.Apartamentos
                            where c.Estado == Model.TipoDeEstado.Disponible
                            select c;
            return resultado.ToList();
        }

        public List<Model.Apartamento> ObtenerListaApartamentosAlquilados()
        {
            var resultado = from c in ElContextoDB.Apartamentos
                           where c.Estado == Model.TipoDeEstado.Alquilado
                            select c;
            return resultado.ToList();
        }

        public Model.Apartamento ObtenerApartamentoPorId(int id)
        {
            Model.Apartamento resultado;
            resultado = ElContextoDB.Apartamentos.Find(id);
            if (resultado == null)
            {
                throw new Exception("No se encontró el apartamento con el id " + id.ToString());
            }
            return resultado;

        }

        public void EditeElApartamento(Model.Apartamento apartamento)
        {
            Model.Apartamento elApartamentoAModificar;
            elApartamentoAModificar = ObtenerApartamentoPorId(apartamento.Id);

            elApartamentoAModificar.Nombre = apartamento.Nombre;
            elApartamentoAModificar.NumeroDePiso = apartamento.NumeroDePiso;
            elApartamentoAModificar.Descripcion = apartamento.Descripcion;
            elApartamentoAModificar.PrecioPorMes = apartamento.PrecioPorMes;

            ElContextoDB.Apartamentos.Update(elApartamentoAModificar);
            ElContextoDB.SaveChanges();

        }


        public void Alquile(int id, string identificacionInquilino, string nombreInquilino, DateTime fechaInicio, int cantidadMeses)
        {
            if (string.IsNullOrWhiteSpace(identificacionInquilino))
                throw new Exception("La identificación del inquilino es requerida.");
            if (string.IsNullOrWhiteSpace(nombreInquilino))
                throw new Exception("El nombre del inquilino es requerido.");
            if (fechaInicio == DateTime.MinValue)
                throw new Exception("La fecha de inicio es requerida.");
            if (cantidadMeses <= 0)
                throw new Exception("La cantidad de meses debe ser mayor a cero.");

          
            var apartamento = ObtenerApartamentoPorId(id);

            if (apartamento.Estado != Model.TipoDeEstado.Disponible)
                throw new Exception("El apartamento no está disponible para alquilar.");

            apartamento.IdentificacionInquilino = identificacionInquilino;
            apartamento.NombreInquilino = nombreInquilino;
            apartamento.FechaInicioAlquiler = fechaInicio;
            apartamento.CantidadDeMesesAlquiler = cantidadMeses;

            
            if (cantidadMeses < 12)
            {
                apartamento.DepositoDeGarantia = apartamento.PrecioPorMes;
            }
            else if (cantidadMeses >= 12 && cantidadMeses < 24)
            {
                apartamento.DepositoDeGarantia = apartamento.PrecioPorMes * 0.75m;
            }
            else // cantidadMeses >= 24
            {
                apartamento.DepositoDeGarantia = apartamento.PrecioPorMes * 0.5m;
            }

            // Cambiar estado a Alquilado
            apartamento.Estado = Model.TipoDeEstado.Alquilado;

            ElContextoDB.Apartamentos.Update(apartamento);
            ElContextoDB.SaveChanges();
        }


    }
}
