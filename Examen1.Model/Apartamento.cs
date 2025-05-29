using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace Examen1.Model
{
    public class Apartamento
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo no puede quedar vacío ")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo no puede quedar vacío ")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo  no puede quedar vacío ")]

        public TipoDeEstado Estado { get; set; }
        [Required(ErrorMessage = "El campo no puede quedar vacío ")]
        public int NumeroDePiso { get; set; }
        [Required(ErrorMessage = "El campo no puede quedar vacío ")]

        public decimal PrecioPorMes { get; set; }
        [Required(ErrorMessage = "El campo no puede quedar vacío ")]
        public string IdentificacionInquilino { get; set; }
        [Required(ErrorMessage = "El campo no puede quedar vacío ")]
      

        public string NombreInquilino { get; set; }

        

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de inicio de alquiler")]

        [Required(ErrorMessage = "El campo no puede quedar vacío ")]
        public DateTime FechaInicioAlquiler { get; set; }
        [Required(ErrorMessage = "El campo no puede quedar vacío ")]

        public DateTime FechaFinalAlquiler
        {
            get
            {
                if (FechaInicioAlquiler == DateTime.MinValue || CantidadDeMesesAlquiler <= 0)
                    return DateTime.MinValue;
                return FechaInicioAlquiler.AddMonths(CantidadDeMesesAlquiler);
            }
        }


        public int CantidadDeMesesAlquiler { get; set; }
        [Required(ErrorMessage = "El campo no puede quedar vacío ")]
        public decimal DepositoDeGarantia { get; set; }
        






    }
}
