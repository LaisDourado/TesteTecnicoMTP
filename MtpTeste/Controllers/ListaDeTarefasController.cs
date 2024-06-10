using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MtpTeste.Models;
using MtpTeste.Service;
using Omu.ValueInjecter;
namespace MtpTeste.Controllers
{
	public class ListaDeTarefasController : Controller
	{		
		private readonly ITarefasService _tarefaService;

		public ListaDeTarefasController(ITarefasService tarefaService)
		{
			_tarefaService = tarefaService;
		}

		#region Lista de Tarefas

		[HttpGet]
		public ActionResult Index()
		{
			var listaDeTarefasVM = new ListaDeTarefasViewModel();

			var tarefas = _tarefaService.GetAllTarefas();

			if (tarefas == null)
			{
				return View(listaDeTarefasVM);
			}			
			listaDeTarefasVM.ListaDeTarefasVM = ValueMapper.To<ListaDeTarefasViewModel>(tarefas);
			return View(listaDeTarefasVM);

		}

		[HttpPost]
		public ActionResult Index(ListaDeTarefasViewModel listaDeTarefasVM)
		{
			if (listaDeTarefasVM?.Titulo != null)
			{
				var listaTarefas = _tarefaService.GetAllTarefasByTitulo(listaDeTarefasVM.Titulo);

				listaDeTarefasVM.ListaDeTarefasVM.InjectFrom(listaTarefas);
			}

			return View(listaDeTarefasVM);
		}

		[HttpGet]
		public ActionResult EditarTarefa(long tarefaId)
		{
			var listaDeTarefasVM = new ListaDeTarefasViewModel();

			if (tarefaId > 0)
			{
				var dadostarefa = _tarefaService.GetTarefasById(tarefaId);

				if (dadostarefa != null)
				{
					listaDeTarefasVM.InjectFrom(dadostarefa);
				}
			}

			return View(listaDeTarefasVM);
		}

		[HttpPost]
		public ActionResult EditarTarefa(ListaDeTarefasViewModel listaDeTarefasVM)
		{
			if (ModelState.IsValid)
			{
				var tarefa = new Tarefas();

				if (listaDeTarefasVM.TarefaId > 0)
				{
					var dadostarefa = _tarefaService.GetTarefasById(listaDeTarefasVM.TarefaId);

					if (dadostarefa != null)
					{
						dadostarefa.InjectFrom(listaDeTarefasVM);
						_tarefaService.UpdateTarefas(dadostarefa);
						listaDeTarefasVM.InjectFrom(dadostarefa);
					}
				}
				else
				{
					tarefa.InjectFrom(listaDeTarefasVM);
					_tarefaService.AddTarefas(tarefa);
					listaDeTarefasVM.InjectFrom(tarefa);

				}

				TempData["message"] = "A tarefa foi salva com sucesso!";

				return RedirectToAction("Index", "ListaDeTarefas");
			}
			else
			{
				TempData["message"] = "Não foi possível salvar a tarefa. Por favor, verifique se todos os campos estão preenchidos.";
			}
			return View(listaDeTarefasVM);
		}

		public ActionResult ExcluirTarefa(long tarefaId)
		{
			var retorno = string.Empty;
			if (tarefaId > 0)
			{
				var dadostarefa = _tarefaService.GetTarefasById(tarefaId);
				if (dadostarefa != null)
				{
					_tarefaService.DeleteTarefas(tarefaId);
					retorno = "A tarefa foi excluída com sucesso!";
				}
			}
			else
			{
				retorno = "A tarefa não foi encontrada";
			}
			return RedirectToAction("Index", "ListaDeTarefas");
		}
		#endregion

	}
}
