namespace UC_13_Henrique_Webssite.Models
{
    public class Venda
    {
        public int VendaId { get; set; }

        public DateTime Data { get; set; }

        public int Parcelas { get; set; }

        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }

        public int VendedorId { get; set; }

        public Vendedor? Vendedor { get; set; }

    }
}
