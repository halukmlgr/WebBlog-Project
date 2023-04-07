using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string BlogThumbnailImage { get; set; }
        public string BlogImage { get; set; }
        public DateTime CreateDate { get; set; }
        public bool BlogStatus { get; set; }
        public int CategoryID { get; set; }//CategoryID ile ilişkilendirildiği için buranın ismi Category class ile aynı olması gerekiyor.
        public Category Category { get; set; }//Entity üzerinden tanımlanması için ilişkilendirdiğimiz tablo üzerinden tanımlıyoruz.
        public int WriterID { get; set; }
        public Writer Writer { get; set; }
        public List<Comment> Comments { get; set; }//Comment class ile ilişkilendirme yapılıyor bu kısımda Comment primary key olarak atanıyor.

    }
}
