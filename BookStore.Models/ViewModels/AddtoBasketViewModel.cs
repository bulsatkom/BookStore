using System.Collections.Generic;
using System.Web.Mvc;

namespace BookStore.Models.ViewModels
{
    public class AddtoBasketViewModel
    {
        public AddtoBasketViewModel()
        {
            this.Books = new List<SelectListItem>();
        }

        public ICollection<SelectListItem> Books { get; set; }

        public string book { get; set; }
    }
}
