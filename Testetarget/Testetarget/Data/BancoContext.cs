using System;
using Microsoft.EntityFrameworkCore;
using Testetarget.Models;

namespace Testetarget.Data
{
	public class BancoContext : DbContext
	{

		public BancoContext(DbContextOptions<BancoContext> options) : base(options)
		{

		}

		public DbSet<ProdutoModel> Produtos { get; set; }
	}
}
