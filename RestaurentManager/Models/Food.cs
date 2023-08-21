using System;
using System.Collections.Generic;

namespace RestaurentManager.Models
{
    public partial class Food
    {
        public Food()
        {
            BillInfos = new HashSet<BillInfo>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int IdCategory { get; set; }
        public double Price { get; set; }

        public virtual FoodCategory IdCategoryNavigation { get; set; } = null!;
        public virtual ICollection<BillInfo> BillInfos { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
