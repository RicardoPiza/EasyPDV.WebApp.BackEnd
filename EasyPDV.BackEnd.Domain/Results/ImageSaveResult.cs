using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.BackEnd.Domain.Results
{
    public class ImageSaveResult
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public int Size { get; set; }
        public string Type { get; set; }
    }
}
