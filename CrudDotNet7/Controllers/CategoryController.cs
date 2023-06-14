using Microsoft.AspNetCore.Mvc;
using CrudDotNet7.Models;
using CrudDotNet7.Data;
using AutoMapper;
using System.Security.Cryptography.Xml;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

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
            IEnumerable < Category > objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            var model = new CategoryCreateModel();
            return View(model);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryCreateModel obj)
        {
          //  var model= _mapper.Map<Category>(obj);

            try
            {
                var model = _mapper.Map<CategoryCreateModel, Category>(obj);

                if (ModelState.IsValid)
                {
                    _db.Categories.Add(model);
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
                var goryFromDb = await _db.Categories.FindAsync(id);
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
        //public IActionResult Edit(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    var CategoryFromDb = _mapper.Map<Category>(id);
        //    if (CategoryFromDb == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(CategoryFromDb);
        //}

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            //var model = _mapper.Map<CategoryCreateModel, Category>(obj);
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Categories.Update(obj);
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
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var CategoryFromDb = _db.Categories.Find(id);
            if (CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDb);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Remove(obj);
                _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
