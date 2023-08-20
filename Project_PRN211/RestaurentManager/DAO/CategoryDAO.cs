using RestaurentManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentManager.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return CategoryDAO.instance; }
            private set { CategoryDAO.instance = value; }
        }

        private CategoryDAO() { }

        public List<FoodCategory> GetListCategory()
        {
            using (var context = new QuanLyNhaHangContext()) 
            {
                return context.FoodCategories.ToList();
            }
        }

        public FoodCategory GetCategoryByID(int id)
        {
            using (var context = new QuanLyNhaHangContext()) 
            {
                return context.FoodCategories.FirstOrDefault(c => c.Id == id);
            }
        }

        public bool AddCategory(string name)
        {
            using (var context = new QuanLyNhaHangContext()) 
            {
                context.FoodCategories.Add(new FoodCategory { Name = name });
                int result = context.SaveChanges();
                return result > 0;
            }
        }

        public bool UpdateCategory(int id, string name)
        {
            using (var context = new QuanLyNhaHangContext()) 
            {
                var category = context.FoodCategories.FirstOrDefault(c => c.Id == id);
                if (category != null)
                {
                    category.Name = name;
                    int result = context.SaveChanges();
                    return result > 0;
                }
                return false;
            }
        }

        public bool DeleteCategory(int id)
        {
            using (var context = new QuanLyNhaHangContext()) 
            {
                var category = context.FoodCategories.FirstOrDefault(c => c.Id == id);
                if (category != null)
                {
                    context.FoodCategories.Remove(category);
                    int result = context.SaveChanges();
                    return result > 0;
                }
                return false;
            }
        }

       
    }
}
