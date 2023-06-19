using AutoMapper;
using CrudDotNet7.Data;
using CrudDotNet7.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudDotNet7.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CategoryController(ApplicationDbContext db,IMapper mapper)
        {
             _db = db;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var Idx = _db.Categorie.ToList();
            var objCategoryList = _mapper.Map<List<Category>, List<CategoryIndexModel>>(Idx);

            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            var model = new CategoryCreateModel();
            model.IsFavorite = true;
            return View(model);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryCreateModel obj)
        {
          

            try
            {
               

                if (ModelState.IsValid)
                {
                    var model = _mapper.Map<CategoryCreateModel, Category>(obj);
                    _db.Categorie.Add(model);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(obj);
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
        }


        public async Task< IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }
                var goryFromDb = await _db.Categorie.FindAsync(id);
                var model = _mapper.Map<Category, CategoryEditModel>(goryFromDb!);

                if (model is null)
                {
                    return NotFound();
                }
                return View(model);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
           
        }
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryEditModel obj)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    var model = _mapper.Map<CategoryEditModel, Category>(obj);
                    _db.Categorie.Update(model);
                    _db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return View(obj);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IActionResult Delete(int? id)
        {
            try
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }
                var CatDeleteFromDb = _db.Categorie.Find(id);
                var model = _mapper.Map<Category, CategoryDeleteModel>(CatDeleteFromDb!);

                if (CatDeleteFromDb == null)
                {
                    return NotFound();
                }
                return View(model);
            }
            catch (Exception exp) 
            {
                throw new Exception(exp.Message);
            }

        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(CategoryDeleteModel obj)
        {
            try
            {
                var model = _mapper.Map<CategoryDeleteModel, Category>(obj);

                if (ModelState.IsValid)
                {
                    _db.Categorie.Remove(model);
                    _db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return View(obj);
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
        }
    }
}
