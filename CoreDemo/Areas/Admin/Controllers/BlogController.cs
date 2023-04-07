using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using Context = DataAccessLayer.Concrete.Context;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
       public IActionResult ExportStaticExcelBlogList()//Excele veri çekmek için oluşturulan yapı static hali.
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";
                int BlogRowCount = 2;
                foreach (var item in GetBlogList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;

                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }

        }
       public List<BlogModel> GetBlogList()//Excele yazdıracağımız veriler aşağıdakiler 3 tane
        {
            List<BlogModel> bm = new List<BlogModel>
            {
                new BlogModel{ID=1, BlogName="C# Programlamaya Giriş" },
                new BlogModel{ID=2,BlogName="Tesla Firmasının Araçları"},
                new BlogModel{ID=3,BlogName="2020 Olimpiyatları"}

            };
            return bm;
        }
       public IActionResult BlogListExcel()//Excele veri yazdırmak için view oluşturduğumuz kısım. 
        {
            return View();
        }
        public IActionResult ExportDynamicExcelBlogList()//Excel veri çekmek için dinamik bir yapının oluşturulması aşağıdaki gibidir.
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";
                int BlogRowCount = 2;
                foreach (var item in BlogTitleList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;

                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma2.xlsx");
                }
            }
        }
        public List<BlogModel2> BlogTitleList()//Blog başlıklarının  excel aktarılması için yazıldı.
        {
            List<BlogModel2> bm = new List<BlogModel2>();
            using(var c = new Context())
            { 
            bm=c.Blogs.Select(x=> new BlogModel2 { 
            
                ID = x.BlogID,
                BlogName=x.BlogTitle
            }).ToList();
            }
            return bm;
        }
        public IActionResult BlogTitleListExcel()//Blog title indirilmesindeki view sayfası
        {
            return View();
        }
    }
}
