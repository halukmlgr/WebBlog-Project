using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public string CommentUserName { get; set; }
        public string CommentTitle { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; }
        public int BlogScore { get; set; }
        public bool CommentStatus { get; set; }
        public int BlogID { get; set; }//Blog class ile ilişkilendirildiği için buranın Blog class ıd ismi ile aynı olması gerekiyor.
        public Blog Blog { get; set; }//Entity üzerinden tanımlandığı için class ismi ile birebir aynı olması gerekiyor.
    }
}
