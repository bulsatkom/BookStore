using System.Collections.Generic;

namespace BookStore.Models.ViewModels
{
    public class ViewAllViewModel
    {
        public ViewAllViewModel()
        {
            this.Catalogs = new Dictionary<string, ICollection<ViewAllCatalogViewModel>>();
            this.Discounts = new Dictionary<string, double>();
        }

        public IDictionary<string, ICollection<ViewAllCatalogViewModel>> Catalogs { get; set; }

        public IDictionary<string, double> Discounts { get; set; }

    }
}
