using Microsoft.EntityFrameworkCore;
using MtpTeste.Models;
using static MtpTeste.Service.TarefasService;

namespace MtpTeste.Service
{
	public class TarefasService : ITarefasService
	{
		private readonly Db_Context _context;

		public TarefasService(Db_Context context)
		{
			_context = context;
		}
	
		public List<Tarefas> GetAllTarefas()
		{
			return _context.Tarefas.ToList();
		}
		public List<Tarefas> GetAllTarefasByTitulo(string titulo)
		{
			return _context.Tarefas.
				Where(x => x.Titulo.Contains(titulo))
				.ToList();
		}

		public Tarefas GetTarefasById(long id)
		{
			return _context.Tarefas.Find(id);
		}

		public void AddTarefas(Tarefas tarefas)
		{
			_context.Tarefas.Update(tarefas);
			_context.SaveChanges();
		}

		public void UpdateTarefas(Tarefas tarefas)
		{
			_context.Tarefas.Update(tarefas);
			_context.SaveChanges();
		}

		public void DeleteTarefas(long id)
		{
			var item = _context.Tarefas.Find(id);
			if (item != null)
			{
				_context.Tarefas.Remove(item);
				_context.SaveChanges();
			}
		}
	}
}
