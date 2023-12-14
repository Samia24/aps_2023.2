#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using samiabraga.Models;

    public class ApiDbContext : DbContext
    {
        public ApiDbContext (DbContextOptions<ApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<samiabraga.Models.Produto> Produto { get; set; }

        public DbSet<samiabraga.Models.Marca> Marca { get; set; }

        public DbSet<samiabraga.Models.Item> Item { get; set; }

        public DbSet<samiabraga.Models.NotaDeVenda> NotaDeVenda { get; set; }

        public DbSet<samiabraga.Models.Cliente> Cliente { get; set; }

        public DbSet<samiabraga.Models.Vendedor> Vendedor { get; set; }

        public DbSet<samiabraga.Models.Transportadora> Transportadora { get; set; }

        public DbSet<samiabraga.Models.Pagamento> Pagamento { get; set; }

        public DbSet<samiabraga.Models.TipoDePagamento> TipoDePagamento { get; set; }

        public DbSet<samiabraga.Models.PagamentoComCartao> PagamentoComCartao { get; set; }

        public DbSet<samiabraga.Models.PagamentoComCheque> PagamentoComCheque { get; set; }
    }
