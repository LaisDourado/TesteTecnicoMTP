using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MtpTeste.Models;

namespace MtpTeste.Mapping
{
	public class TarefasMapping : EntityTypeConfiguration<Tarefas>
	{
		public TarefasMapping(string schema = "dbo") 
		{
			ToTable(schema + ".Tarefas");
			HasKey(x => x.TarefaId);

			Property(x => x.TarefaId).HasColumnName("TarefaId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(x => x.Titulo).HasColumnName("Titulo").IsRequired();
			Property(x => x.Descricao).HasColumnName("Descricao").IsRequired();
			Property(x => x.Concluido).HasColumnName("Concluido").IsOptional();
		}
	}
}
