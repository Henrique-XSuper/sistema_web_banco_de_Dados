namespace UC_13_Henrique_Webssite.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? Gmail { get; set; }
        public string? Senha { get; set; }
        public string? CPF { get; set; }
        public DateOnly Nascimento { get; set; }
        public decimal Renda { get; set; }
        public string? Endereco { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? CEP { get; set; }
    }
}
