namespace UC_13_Henrique_Webssite.Models
{
    public class Fornecedor
    {
        public int FornecedorId { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? CNPJ { get; set; }
        public string? Codigo { get; set; }
        public DateTime Expedicao { get; set; }
        public DateOnly Data_De_Entrega { get; set; }
        public string? Responsavel { get; set; }
        public string? Receptor { get; set; }
        public decimal PrecoBruto { get; set; }
        public string? Tipo { get; set; }
        public int Quantidade { get; set; }
        public string? Estado { get; set; }
        public string? Cidade { get; set; }
        public string? CEP { get; set; }
    }
}
