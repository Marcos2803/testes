namespace sistema_teste.Domain.Entities.Alunos
{
    public class TipoPagamentoPc
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public virtual ICollection<TipoPagamento> TipoPagamentos { get; set; }
    }
}
