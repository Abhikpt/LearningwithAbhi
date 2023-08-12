using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LearningwithAbhi.Shared;

namespace LearningwithAbhi.Server.Controllers
{





    public class BookController : Controller
    {

        private List<BookModel> _bk = new List<BookModel>
        {
        new BookModel { Id = 1, Name = "Book 1", Price = 19.99, Description = "Description for Product 1" },
        new BookModel { Id = 2, Name = "Book 2", Price = 29.99, Description = "Description for Product 2" },
        // Add more products
    };
        public BookModel GetProductById(int productId)
        {
            return _bk.FirstOrDefault(p => p.Id == productId);
        }

    }
}
