using BLL.DAL;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class CategoriesController : Controller
    {
        //private Db _db = new Db();
        //private CategoryService _categoryservice = new CategoryService(_db);
        
        //Bunu yapmmanın artık daha kolay bir yöntemi olduğu için mülakatlarda artık bu şekilde yapmamalıyız.

        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService) //we injected as abstract
        {
            _categoryService = categoryService; //dependency injection, we injected object to the class
        }

        //Artık mülakatlarda dependency injection yapmalıyız.
        //Sürekli obj yaratmak yerine injection yapıyoruz, öteki türlü sürekli obje oluşturup hafızayı doldurur işlemciyi yorarız.

        public IActionResult Index()
        {
            var list = _categoryService.Query().ToList();
            return View(list);
            //return View("CategoryList", list);
            //Index kullanmak istemezsek view adı belirtebiliyoruz.
            //Yalnız views altına oluşturmak gerekir!
        }
    }
}


