using sistema_teste.Domain.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_teste.Domain.Entities.Alunos
{
    public class EntidadeAlunos
    {
        public int Id { get; set; }
        public User? User { get; set; }
        public string? UserId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public bool Ativo { get; set; }
        public int TipoPlanoId { get; set; }
        public TipoPlano TipoPlano { get; set; }
        public int TipoPagamentoId { get; set; }
        public TipoPagamento TipoPagamento { get; set; }
        public byte[]? Foto { get; set; }


    }
}
