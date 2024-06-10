using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MtpTeste.Models
{
	public class ListaDeTarefasViewModel
	{
		[DisplayName("Título")]
		[Required(ErrorMessage = "{0} é obrigatório.")]
		public string Titulo { get; set; }
		[DisplayName("Descrição")]
		[Required(ErrorMessage = "{0} é obrigatório.")]
		public string Descricao { get; set; }
		public bool Concluido { get; set; }
		public long TarefaId { get; set; }
		public ListaDeTarefasViewModel()
		{
			ListaDeTarefasVM = new List<ListaDeTarefasViewModel>();

		}
		public List<ListaDeTarefasViewModel> ListaDeTarefasVM { get; set; }
	}
}
