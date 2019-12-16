using BookStore.Core.Exceptions;
using BookStore.Core.Interfaces;
using BookStore.DB;
using BookStore.Models.ViewModels;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStore store;
        private readonly ICommonService informationService;
        private readonly ICatalogService catalogService;

        public HomeController(IStore store, ICommonService informationService, ICatalogService catalogService)
        {
            this.store = store;
            this.informationService = informationService;
            this.catalogService = catalogService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                string json = (new StreamReader(file.InputStream)).ReadToEnd();

                this.store.Import(json);

                return this.RedirectToAction("ViewAll");
            }

            this.ModelState.AddModelError("", "You can`t upload empty file!!!");

            return View("Index");
        }

        public ActionResult ViewAll()
        {
            var model = this.informationService.GetData();

            return this.View(model);
        }

        [HttpGet]
        public ActionResult GetQuantity()
        {
            var books = this.catalogService.GetAll();
            var model = new GetQuantityViewModel();

            foreach (var book in books)
            {
                model.Books.Add(new SelectListItem()
                {
                    Text = book.Name,
                    Value = book.Name
                });
            }

            return this.View(model);
        }

        [HttpPost]
        public ActionResult GetQuantity(GetQuantityViewModel model)
        {
            var result = this.store.Quantity(model.Book);
            var currentModel = new GetQuantityResultViewModel()
            {
                Name = model.Book,
                Quantity = result
            };

            return this.View("GetQuantityResult", currentModel);
        }

        public ActionResult AddtoBasket()
        {
            var titles = this.catalogService.GetBookTitles();
            var model = new AddtoBasketViewModel();

            foreach (var item in titles)
            {
                model.Books.Add(new SelectListItem()
                {
                    Text = item,
                    Value = item
                });
            }

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddtoBasket(AddtoBasketViewModel model)
        {
            Basket.bookTitles.Add(model.book);

            return this.RedirectToAction("CalculatePrice");
        }

        public ActionResult CalculatePrice()
        {
            var articleTitles = Basket.bookTitles.ToArray();
            double price = 0;
            try
            {
                price = this.store.Buy(articleTitles);
            }
            catch (NotEnoughInventoryException ex)
            {

                this.ModelState.AddModelError("", ex.Message);
            }            

            var model = new CalculatePriceViewModel()
            {
                price = price,
                bookArticles = articleTitles
            };

            return this.View(model);
        }
    }
}