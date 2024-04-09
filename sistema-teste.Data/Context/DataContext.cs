using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using sistema_teste.Data.Mapping;
using sistema_teste.Domain.Entities.Account;
using sistema_teste.Domain.Entities.Alunos;


namespace sistema_teste.Data.Context
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        #region Tabelas
        public DbSet<User> Usuarios { get; set; } 
        public DbSet<EntidadeAlunos> Alunos { get; set; }
        public DbSet<TipoPagamento> TipoPagamentos { get; set; }
        public DbSet<TipoPagamentoPc> TipoPagamentoPc { get; set; }
        public DbSet<TipoPlano> TipoPlano { get; set; }
        public DbSet<AlunosPesquisa> AlunosPesquisa { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(new UserConfiguration().Configure);
            builder.Entity<EntidadeAlunos>(new AlunosConfiguration().Configure);
            base.OnModelCreating(builder);
        }
    }
}
