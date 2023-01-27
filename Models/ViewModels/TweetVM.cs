using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaMafiaRS.Models.ViewModels
{
    public class TweetVM
    {
        public Tweet _Tweet { get; set; }
        public IEnumerable<SelectListItem>? CategoriaLista { get; set; }
    }
}
