using MtpTeste.Models;

namespace MtpTeste.Service
{
	public interface ITarefasService
	{
		List<Tarefas> GetAllTarefas();
		List<Tarefas> GetAllTarefasByTitulo(string titulo);
		Tarefas GetTarefasById(long id);
		void AddTarefas(Tarefas tarefas);
		void UpdateTarefas(Tarefas tarefas);
		void DeleteTarefas(long id);
	}
}
