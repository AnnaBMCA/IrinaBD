using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IrinaBD.Data;
using IrinaBD.Domain.Entities.Models;
using Microsoft.AspNetCore.Http;
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

    [HttpPost]
    [ActionName("fileupload")]
    public async Task<IActionResult> UploadPhoto(IFormFile photo)
    {

      using (var stream = new MemoryStream())
      {
        await photo.CopyToAsync(stream);
        ImageMetadata imageMetadata = new ImageMetadata()
        {
          Id = Guid.NewGuid(),
          OriginalFileName = photo.Name,
          ContentType = photo.ContentType,
          Image = stream.ToArray()
        };
        _context.Add(imageMetadata);
        _context.SaveChanges();
      }
      return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    [ActionName("getimages")]
    public FileContentResult GetImages(Guid id)
    {
      var image = _context.imageMetadatas
          .FirstOrDefault(x=>x.Id == id);

      if (image != null)
      {
        return File(image.Image, image.ContentType);
      }
      else
      {
        return null;
      }
    }
  }

  
}