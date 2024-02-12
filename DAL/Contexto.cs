using Microsoft.EntityFrameworkCore;
using Parcial1_Ap1_JosePolanco.Model;

namespace Parcial1_Ap1_JosePolanco.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        public DbSet<Metas> Metas { get; set; }

    }
}
