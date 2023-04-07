using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        //Erişim Belirleyici türü -Değişken türü isim {get set}
        public  int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool CategoryStatus { get; set; }//Bu kısım ilişkili tablolarda veriyi silmek problem çıkardığı için veriyi aktif yada pasif duruma getiricez.
        public List<Blog> Blogs { get; set; }//Blog class ile ilişkilendirmenin yapıldığı kısım. Blog primary key olarak atanıyor.
    }
}
