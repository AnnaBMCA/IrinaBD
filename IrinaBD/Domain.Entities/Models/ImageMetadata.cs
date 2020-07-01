using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IrinaBD.Domain.Entities.Models
{
  public class ImageMetadata
  {
    public Guid Id { get; set; }
    public string OriginalFileName { get; set; }
    public string FilePath { get; set; }
    public byte[] Image { get; set; }
    public string ContentType { get; set; }
  }
}
