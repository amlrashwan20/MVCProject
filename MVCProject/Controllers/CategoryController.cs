using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCProject.Context;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class CategoryController : Controller
    {
        ProjectContext lab = new ProjectContext();
        public IActionResult Index()                     //1-index
        {
            var category = lab.Categories;
            return View(category);
        }
        [HttpGet]
        public ActionResult Details(int id)                    //2-details

        {
            var product = lab.Categories.FirstOrDefault(d => d.CategoryId == id);

            return View(product);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)            //3-create
        {
            
          
            lab.Categories.Add(category);
            lab.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var Category = lab.Categories.FirstOrDefault(u => u.CategoryId == id);
            if (Category == null)
            {
                return RedirectToAction("Index");
            }
           
            return View(Category);

        }

        [HttpPost]
        public ActionResult Edit(int id, Category category)
        {
            if (ModelState.IsValid)
            {
                var existingCategory = lab.Categories.Find(id);
                if (existingCategory != null)
                {
                    // Update the existing product
                    existingCategory.Name = category.Name;
                    existingCategory.Description = category.Description;
                    
                    lab.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(category);
        }
        [HttpGet]
        public ActionResult Delete(int id)                 //5-delete
        {
            var category = lab.Categories.Find(id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            lab.Categories.Remove(category);
            lab.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
