using Microsoft.EntityFrameworkCore;

namespace Examen1.DA
{
    public class DBContexto : DbContext

    {
        public DBContexto(DbContextOptions<DBContexto> opciones) : base(opciones)
        {

        }
        public DbSet<Examen1.Model.Apartamento> Apartamentos { get; set; }

    }
}
