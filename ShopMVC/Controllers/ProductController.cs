using Microsoft.AspNetCore.Mvc;
using ShopMVC.Services;

namespace ShopMVC.Controllers;

public class ProductController : Controller
{
    private readonly ProductService  _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }
    
    public IActionResult Index()
    {
        var products = _productService.GetAll();
        return View(products);
    }
    
    // [HttpGet]
    // public IActionResult Edit(String id)
    // {
    //     var product = _productService.GetById(id);
    //     if (product == null)
    //     {
    //         return NotFound();
    //     }
    //     return View(product);
    // }
}