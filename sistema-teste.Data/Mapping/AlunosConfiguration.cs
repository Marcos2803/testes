using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sistema_teste.Domain.Entities.Alunos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_teste.Data.Mapping
{
    public class AlunosConfiguration : IEntityTypeConfiguration<EntidadeAlunos>
    {
        public void Configure(EntityTypeBuilder<EntidadeAlunos> builder)
        {
            builder.ToTable("Alunos");
            builder.HasKey("Id");

            builder.HasOne(x => x.User)
                .WithMany(a => a.Alunos)
                .HasForeignKey(a => a.UserId);

        }
    }
}
