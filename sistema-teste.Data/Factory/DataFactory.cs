using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using sistema_teste.Data.Context;

namespace sistema_teste.Data.Factory
{
    public class DataFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var connectionstring = "Data Source=localhost,1401;Initial Catalog=DbSistema;User ID=sa;Password=@MLab12366;Trust Server Certificate=True";
            var optionBulder = new DbContextOptionsBuilder<DataContext>();
            optionBulder.UseSqlServer(connectionstring);
            return new DataContext(optionBulder.Options);
        }
    }
}
