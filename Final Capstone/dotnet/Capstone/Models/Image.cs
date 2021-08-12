using System;

namespace Capstone.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public int PropertyId { get; set; }
        public string Link { get; set; }
        public bool Thumbnail { get; set; }

    }
}
