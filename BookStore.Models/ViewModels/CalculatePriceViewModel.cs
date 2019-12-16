using System.Collections.Generic;

namespace BookStore.Models.ViewModels
{
    public class CalculatePriceViewModel
    {
        public CalculatePriceViewModel()
        {
            this.bookArticles = new List<string>();
        }

        public double price { get; set; }

        public ICollection<string> bookArticles { get; set; }
    }
}
