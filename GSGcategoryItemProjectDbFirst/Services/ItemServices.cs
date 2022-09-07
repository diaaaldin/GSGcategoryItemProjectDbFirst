using GSGcategoryItemProjectDbFirst.Dtos;
using GSGcategoryItemProjectDbFirst.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSGcategoryItemProjectDbFirst.Services
{
    public interface IItemServices
    {
        ItemDto Get(int id);
        List<ItemDto> Getall();
    }
    public class ItemServices : IItemServices
    {
        private readonly CategoryItemDb2Context _db;
        public ItemServices(CategoryItemDb2Context db)
        {
            _db = db;
        }

        public ItemDto Get(int id)
        {
            var items = _db.Items.Include(x => x.SupCategory).Include(x => x.SupCategory.Category).FirstOrDefault(x => x.Id == id);

            var data = new ItemDto
            {
                Id = items.Id,
                Name = items.Name,
                SupCategoryName = items.SupCategory.Name,
                CategoryName = items.SupCategory.Category.Name
            };
            return data;

        }
        public List<ItemDto> Getall()
        {

            var items = _db.Items.Include(x => x.SupCategory).Include(x => x.SupCategory.Category).ToList();
       
            List<ItemDto> list = new List<ItemDto>();

            foreach (var item in items)
            {
                var data = new ItemDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    SupCategoryName = item.SupCategory.Name,
                    CategoryName = item.SupCategory.Category.Name

                };
                list.Add(data);
            }

            return list;

        }
    }
}
