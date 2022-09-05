using Microsoft.EntityFrameworkCore;

namespace WebDIMDIM.Models
{
    public class Contexto : DbContext
    {
        public Contexto ( DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<Produto> Produto { get; set; }

        public DbSet<ContaBancaria> ContaBancaria { get; set; }

    }
}
