using Microsoft.EntityFrameworkCore;

namespace samiabraga.Models
{
   public class MyDbContext : DbContext
   {
       public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
       {
       }

       public DbSet<Cliente> Clientes { get; set; } = null!;
       public DbSet<Vendedor> Vendedores { get; set; } = null!;
       public DbSet<Transportadora> Transportadoras { get; set; } = null!;
       public DbSet<TipoDePagamento> TiposDePagamento { get; set; } = null!;
       public DbSet<PagamentoComCartao> PagamentosComCartao { get; set; } = null!;
       public DbSet<PagamentoComCheque> PagamentosComCheque { get; set; } = null!;
       public DbSet<Marca> Marcas { get; set; } = null!;
       public DbSet<Produto> Produtos { get; set; } = null!;
       public DbSet<Item> Items { get; set; } = null!;
       public DbSet<NotaDeVenda> NotasDeVendas { get; set; } = null!;
       public DbSet<Pagamento> Pagamento { get; set; }

   }
}
