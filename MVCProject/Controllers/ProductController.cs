using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCProject.Context;
using MVCProject.Models;
using System.Collections.Generic;

namespace MVCProject.Controllers
{
    public class ProductController : Controller
    {
        ProjectContext lab = new ProjectContext();

        [HttpGet]
        public IActionResult Index()
        {
            var product = lab.Products.Include(e => e.Category);
            return View(product);
        }
        //-------------------------------------------------------------------------------------------------------
        [HttpGet]
        public ActionResult Details(int id)                    //2-details

        {
            var product = lab.Products.FirstOrDefault(d => d.ProductId == id);

            return View(product);
        }
        //-------------------------------------------------------------------------------------------------------

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Categories = new SelectList(lab.Categories, "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)            //3-create
        {
            ModelState.Remove("Category");
            // Validate the product model
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Required");
                ViewBag.Categories = new SelectList(lab.Categories, "Id", "name");
                return View();
            }
            lab.Products.Add(product);
            lab.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = lab.Products.Include(e => e.Category).FirstOrDefault(u => u.ProductId == id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(lab.Categories, "CategoryId", "Name");
            return View(product);

        }

        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            if (ModelState.IsValid)
            {
                var existingProduct = lab.Products.Find(id);
                if (existingProduct != null)
                {
                    // Update the existing product
                    existingProduct.Title = product.Title;
                    existingProduct.Description = product.Description;
                    existingProduct.Price = product.Price;
                    existingProduct.Code = product.Code;
                    existingProduct.Quantity = product.Quantity;
                    existingProduct.PathImage = product.PathImage;
                    existingProduct.Category = product.Category;
                    lab.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(product);
        }
        [HttpGet]
        public ActionResult Delete(int id)                 //5-delete
        {
            var product = lab.Products.Find(id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            lab.Products.Remove(product);
            lab.SaveChanges();
            return RedirectToAction("Index");

        }

    }
    }
