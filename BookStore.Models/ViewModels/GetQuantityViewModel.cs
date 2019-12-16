using System.Collections.Generic;
using System.Web.Mvc;

namespace BookStore.Models.ViewModels
{
    public class GetQuantityViewModel
    {
        public GetQuantityViewModel()
        {
            this.Books = new List<SelectListItem>();
        }

        public ICollection<SelectListItem> Books { get; set; }

        public string Book { get; set; }

        public int Quantity { get; set; }
    }
}
