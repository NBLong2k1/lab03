
using BusinessObjects.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Access
{
    public class ProductDAO
    {
        public static List<Product> GetProducts()
        {
            var listProducts=new List<Product>();
             
            try
            {

                using (var context = new MyStoreDBContext())
                {
                  
                    // listProducts = context.Products.Include(s=>s.Category).ToList();
                    listProducts = context.Products.ToList();
                      
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
             return listProducts;
     
        }
        public static Product FindProductById(int ProductId)
        {
            Product p = new Product();
            try
            {
                using (var context = new MyStoreDBContext())
                {
                    p = context.Products.Include(s => s.Category).SingleOrDefault(x => x.ProductId == ProductId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return p;
        }


       
        public static void SaveProduct(Product p)
        {
            try
            {
                using (var context = new MyStoreDBContext())
                {
                    context.Products.Add(p);
                    context.SaveChanges();
                }

                Console.WriteLine("check");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
        public static void UpdateProduct(Product p)
        {
            try
            {
                using (var context = new MyStoreDBContext())
                {
                    context.Products.Update(p);
                   // context.Entry<Products>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public static void DeleteProduct(Product p)
        {
            try
            {
                using (var context = new MyStoreDBContext())
                {
                    var p1=context.Products.SingleOrDefault(x=>x.ProductId==p.ProductId);
                    context.Products.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }


    }
}
