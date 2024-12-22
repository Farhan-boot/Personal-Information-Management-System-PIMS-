using System.Web.Mvc;
using System.Linq;

namespace PTSL.DgFood.Web.Helper
{
	public static class ModelStateExtensions
	{
		public static string FirstErrorMessage(this ModelStateDictionary modelState)
		{
			return modelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).FirstOrDefault() ?? string.Empty;
		}
	}
}