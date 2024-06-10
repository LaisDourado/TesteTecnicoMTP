using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using MtpTeste.Models;
namespace MtpTeste
{
	public class Db_Context : DbContext
	{
		public Db_Context(DbContextOptions<Db_Context> options) : base(options) { }
		public DbSet<Tarefas> Tarefas { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Tarefas>(entity =>
			{
				entity.HasKey(x => x.TarefaId);
				entity.Property(x => x.TarefaId).HasColumnName("TarefaId").IsRequired();
				entity.Property(x => x.Titulo).HasColumnName("Titulo").IsRequired().HasMaxLength(50);
				entity.Property(x => x.Descricao).HasColumnName("Descricao").IsRequired().HasMaxLength(100);
				entity.Property(x => x.Concluido).HasColumnName("Concluido");
			});
		}
	}
}
