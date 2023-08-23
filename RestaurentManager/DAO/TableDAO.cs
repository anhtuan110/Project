using RestaurentManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentManager.DAO
{
    public class TableDAO
    {
        public TableDAO() { }

        private static TableDAO instance;

        public static TableDAO Instance 
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }

        public List<TableFood> GetListTable()
        {
            using (var context = new QuanLyNhaHangContext())
            {
                return context.TableFoods.ToList();
            }
        }

        public bool AddTable(string name, string status)
        {
            using (var context = new QuanLyNhaHangContext())
            {
                context.TableFoods.Add(new TableFood { Name = name , Status = status});
                int result = context.SaveChanges();
                return result > 0;
            }
        }

        public bool UpdateTable(int id, string name, string status)
        {
            using (var context = new QuanLyNhaHangContext())
            {
                var table = context.TableFoods.FirstOrDefault(c => c.Id == id);
                if (table != null)
                {
                    table.Name = name;
                    table.Status = status;
                    int result = context.SaveChanges();
                    return result > 0;
                }
                return false;
            }
        }

        public bool DeleteTable(int id)
        {
            using (var context = new QuanLyNhaHangContext())
            {
                var table = context.TableFoods.FirstOrDefault(c => c.Id == id);
                if (table != null)
                {
                    context.TableFoods.Remove(table);
                    int result = context.SaveChanges();
                    return result > 0;
                }
                return false;
            }
        }
    }
}
