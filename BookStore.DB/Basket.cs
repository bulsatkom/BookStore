using System.Collections.Generic;

namespace BookStore.DB
{
    public static class Basket
    {
        public static ICollection<string> bookTitles { get; set; }

         static Basket()
        {
            bookTitles = new List<string>();
        }
    }
}
