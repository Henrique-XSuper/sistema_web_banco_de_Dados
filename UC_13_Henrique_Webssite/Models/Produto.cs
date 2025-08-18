namespace UC_13_Henrique_Webssite.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string? Nome { get; set; }
        public decimal Preco { get; set; }
        public int FornecedorId { get; set; }
        public Fornecedor? Fornecedor { get; set; }
        public ICollection<VendaProdutos>? VendaProdutos { get; set; }
        public string? ImagemUrl { get; set; }
    }

    public class Imovel : Produto
    {
        public string? Endereco { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? CEP { get; set; }
        public decimal Area { get; set; }
        public string? ImagemUrlimoveis { get; set; }
    }
}
