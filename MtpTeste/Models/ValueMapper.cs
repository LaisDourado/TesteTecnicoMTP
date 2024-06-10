using Omu.ValueInjecter;

namespace MtpTeste.Models
{
	public static class ValueMapper
	{
		public static T To<T, TInjection>(this object from)
			where T : new()
			where TInjection : Omu.ValueInjecter.Injections.IValueInjection, new()
		{
			return (T)new T().InjectFrom<TInjection>(from);
		}

		public static T To<T>(this object from)
		where T : new()
		{
			return (T)new T().InjectFrom(from);
		}
		public static List<T> To<T>(this IEnumerable<object> from)
			where T : new()
		{
			return from.Select(x => new T().InjectFrom(x)).Cast<T>().ToList();
		}
	}
}
