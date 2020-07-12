using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IrinaBD.Data;
using IrinaBD.Domain.Entities.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace IrinaBD.Controllers
{
  //[Route("imagemetadatas")]
  public class ImageMetadatasController : Controller
  {
    private readonly ApplicationDbContext _context;

    public ImageMetadatasController(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET: ImageMetadatas
 
    public async Task<IActionResult> Index()
    {
      return View(await _context.imageMetadatas.ToListAsync());
    }

    // GET: ImageMetadatas/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var imageMetadata = await _context.imageMetadatas
          .FirstOrDefaultAsync(m => m.Id == id);
      if (imageMetadata == null)
      {
        return NotFound();
      }

      return View(imageMetadata);
    }

    // GET: ImageMetadatas/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: ImageMetadatas/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,OriginalFileName,FilePath")] ImageMetadata imageMetadata)
    {
      if (ModelState.IsValid)
      {
        imageMetadata.Id = Guid.NewGuid();
        _context.Add(imageMetadata);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(imageMetadata);
    }
    [HttpPost]
    [Route("fileupload")]
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

        // GET: ImageMetadatas/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageMetadata = await _context.imageMetadatas.FindAsync(id);
            if (imageMetadata == null)
            {
                return NotFound();
            }
            return View(imageMetadata);
        }

        // POST: ImageMetadatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,OriginalFileName,FilePath")] ImageMetadata imageMetadata)
        {
            if (id != imageMetadata.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imageMetadata);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageMetadataExists(imageMetadata.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(imageMetadata);
        }

        // GET: ImageMetadatas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageMetadata = await _context.imageMetadatas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imageMetadata == null)
            {
                return NotFound();
            }

            return View(imageMetadata);
        }

        // POST: ImageMetadatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var imageMetadata = await _context.imageMetadatas.FindAsync(id);
            _context.imageMetadatas.Remove(imageMetadata);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImageMetadataExists(Guid id)
        {
            return _context.imageMetadatas.Any(e => e.Id == id);
        }
    [HttpGet]
    [ActionName("getimages")]
    public FileContentResult GetImages(int skip, int take)
    {
      var image = _context.imageMetadatas
          .FirstOrDefault();

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
