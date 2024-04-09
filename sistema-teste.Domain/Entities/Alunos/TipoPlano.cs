namespace sistema_teste.Domain.Entities.Alunos
{
    public class TipoPlano
    {
        public int Id { get; set; }
        public string DescTipoPlano { get; set; }
        public virtual ICollection<EntidadeAlunos> EntidadeAlunos { get; set; }
    }
}
