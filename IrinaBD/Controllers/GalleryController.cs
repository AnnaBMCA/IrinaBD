using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IrinaBD.Data;
using Microsoft.AspNetCore.Mvc;

namespace IrinaBD.Controllers
{
    public class GalleryController : Controller
    {
    private readonly ApplicationDbContext _context;

    public GalleryController(ApplicationDbContext context)
    {
      _context = context;
    }
    public IActionResult Index()
        {
             var a = _context.imageMetadatas.Select(x => x.Id).ToList();
          
            return View(a);
        }
    }
}