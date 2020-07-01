using System;
using System.Collections.Generic;
using System.Text;
using IrinaBD.Domain.Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IrinaBD.Data
{
  public class ApplicationDbContext : IdentityDbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<ImageMetadata> imageMetadatas { get; set; }
  }
}
