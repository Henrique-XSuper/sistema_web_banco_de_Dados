using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UC_13_Henrique_Webssite.Data;
using UC_13_Henrique_Webssite.Models;

namespace UC_13_Henrique_Webssite.Controllers
{
    public class ImovelsController : Controller
    {
        private readonly UC_13_Henrique_WebssiteContext _context;

        public ImovelsController(UC_13_Henrique_WebssiteContext context)
        {
            _context = context;
        }

        // LISTA DE IMÓVEIS
        public async Task<IActionResult> Index()
        {
            var imoveis = _context.Produto
                .OfType<Imovel>()
                .Include(i => i.Fornecedor);
            return View(await imoveis.ToListAsync());
        }

        // CATÁLOGO DE IMÓVEIS
        public async Task<IActionResult> Catalogo()
        {
            var imoveis = _context.Produto
                .OfType<Imovel>()
                .Include(i => i.Fornecedor);
            return View(await imoveis.ToListAsync());
        }

        // DETALHES DO IMÓVEL
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var imovel = await _context.Produto
                .OfType<Imovel>()
                .Include(i => i.Fornecedor)
                .FirstOrDefaultAsync(m => m.ProdutoId == id);

            if (imovel == null) return NotFound();

            return View(imovel);
        }

        // CRIAR IMÓVEL
        public IActionResult Create()
        {
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedor, "FornecedorId", "FornecedorId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Endereco,Cidade,Estado,CEP,Area,ImagemUrlimoveis,ProdutoId,Nome,Preco,FornecedorId,ImagemUrl")] Imovel imovel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(imovel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["FornecedorId"] = new SelectList(_context.Fornecedor, "FornecedorId", "FornecedorId", imovel.FornecedorId);
            return View(imovel);
        }

        // EDITAR IMÓVEL
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var imovel = await _context.Produto
                .OfType<Imovel>()
                .FirstOrDefaultAsync(i => i.ProdutoId == id);

            if (imovel == null) return NotFound();

            ViewData["FornecedorId"] = new SelectList(_context.Fornecedor, "FornecedorId", "FornecedorId", imovel.FornecedorId);
            return View(imovel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Endereco,Cidade,Estado,CEP,Area,ImagemUrlimoveis,ProdutoId,Nome,Preco,FornecedorId,ImagemUrl")] Imovel imovel)
        {
            if (id != imovel.ProdutoId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imovel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImovelExists(imovel.ProdutoId)) return NotFound();
                    else throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["FornecedorId"] = new SelectList(_context.Fornecedor, "FornecedorId", "FornecedorId", imovel.FornecedorId);
            return View(imovel);
        }

        // EXCLUIR IMÓVEL
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var imovel = await _context.Produto
                .OfType<Imovel>()
                .Include(i => i.Fornecedor)
                .FirstOrDefaultAsync(m => m.ProdutoId == id);

            if (imovel == null) return NotFound();

            return View(imovel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imovel = await _context.Produto
                .OfType<Imovel>()
                .FirstOrDefaultAsync(i => i.ProdutoId == id);

            if (imovel != null)
            {
                _context.Remove(imovel);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ImovelExists(int id)
        {
            return _context.Produto
                .OfType<Imovel>()
                .Any(e => e.ProdutoId == id);
        }

        // ✅ COMPRAR IMÓVEL
        [HttpPost]
        public async Task<IActionResult> ComprarImovel(int produtoId)
        {
            var imovel = await _context.Produto
                .OfType<Imovel>()
                .FirstOrDefaultAsync(p => p.ProdutoId == produtoId);

            if (imovel == null)
                return NotFound("Imóvel não encontrado.");

            int clienteId = 1;
            int vendedorId = 1;

            var clienteExiste = await _context.Cliente.AnyAsync(c => c.ClienteId == clienteId);
            var vendedorExiste = await _context.Vendedor.AnyAsync(v => v.VendedorId == vendedorId);

            if (!clienteExiste || !vendedorExiste)
                return NotFound("Cliente ou Vendedor não encontrado.");

            var novaVenda = new Venda
            {
                Data = DateTime.Now,
                Parcelas = 1,
                ClienteId = clienteId,
                VendedorId = vendedorId
            };

            _context.Venda.Add(novaVenda);
            await _context.SaveChangesAsync();

            var itemVenda = new VendaProdutos
            {
                VendaId = novaVenda.VendaId,
                ProdutoId = produtoId
            };

            _context.VendaProdutos.Add(itemVenda);
            await _context.SaveChangesAsync();

            TempData["Mensagem"] = "Imóvel comprado com sucesso!";
            return RedirectToAction("Details", "Vendas", new { id = novaVenda.VendaId });
        }
    }
}
