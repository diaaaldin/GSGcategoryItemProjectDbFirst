using GSGcategoryItemProjectDbFirst.Dtos;
using GSGcategoryItemProjectDbFirst.Models;
using GSGcategoryItemProjectDbFirst.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSGcategoryItemProjectDbFirst.Controllers
{
    [ApiController]
    [Route("[Controller]/[Action]")]
    public class ItemController : Controller
    {
        private readonly IItemServices _itemServices;

        public ItemController(IItemServices itemServices)
        {
            _itemServices = itemServices;
        }
         [HttpGet]
        public IActionResult Index(int id)
        {
            return Ok(_itemServices.Get(id));
        }
        [HttpGet]
        public IActionResult Index2()
        {
            return Ok(_itemServices.Getall());
        }

        [HttpGet]
        public IActionResult SaveFile()
        {

            var builder = new StringBuilder();
            var data = _itemServices.Getall().ToArray();
            builder.AppendLine(data.ToString());
            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "data.csv");

        }
        //[Route("getcsv")]
        //[HttpGet]
        //public IActionResult GetCSV(int id)
        //{
        //    var data = _itemServices.Get(id);

        //    var bytes = System.Text.Encoding.UTF8.GetBytes(WriteTsv(data));
        //    return File(bytes, "application/octet-stream", "RecordExport.csv");
        //}
    }
}
