namespace sistema_teste.Domain.Entities.Alunos
{
    public class TipoPagamento
    {
        public int Id { get; set; }
        public int TipoPagamentoPcId { get; set; }
        public TipoPagamentoPc TipoPagamentoPc { get; set; }

        public virtual ICollection<EntidadeAlunos> EntidadeAlunos { get; set; }
    }
}
