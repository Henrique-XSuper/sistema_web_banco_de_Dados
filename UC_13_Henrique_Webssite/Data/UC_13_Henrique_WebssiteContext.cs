using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UC_13_Henrique_Webssite.Models;

namespace UC_13_Henrique_Webssite.Data
{
    public class UC_13_Henrique_WebssiteContext : DbContext
    {
        public UC_13_Henrique_WebssiteContext (DbContextOptions<UC_13_Henrique_WebssiteContext> options)
            : base(options)
        {
        }

        public DbSet<UC_13_Henrique_Webssite.Models.Vendedor> Vendedor { get; set; } = default!;
        public DbSet<UC_13_Henrique_Webssite.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<UC_13_Henrique_Webssite.Models.Fornecedor> Fornecedor { get; set; } = default!;
        public DbSet<UC_13_Henrique_Webssite.Models.Venda> Venda { get; set; } = default!;
        public DbSet<UC_13_Henrique_Webssite.Models.VendaProdutos> VendaProdutos { get; set; } = default!;
        public DbSet<UC_13_Henrique_Webssite.Models.Produto> Produto { get; set; } = default!;
        public DbSet<UC_13_Henrique_Webssite.Models.Imovel> Imovel { get; set; } = default!;
    }
}
