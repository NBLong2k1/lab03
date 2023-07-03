
using BusinessObjects.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Access
{
    
    public class CategoryDAO
    {
        public static List<Category> GetCategories()
        {
            var listCategory = new List<Category>();
            try
            {
                using (var context = new MyStoreDBContext())
                {
                    listCategory=context.Categories.ToList();
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }return listCategory;
        }
    }
}
