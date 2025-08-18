namespace UC_13_Henrique_Webssite.Models
{
    public class VendaProdutos
    {
        public int VendaProdutosId { get; set; }
        public int VendaId { get; set; }
        public Venda? Venda { get; set; }

        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }
    }
}
