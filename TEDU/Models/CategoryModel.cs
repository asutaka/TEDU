using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CategoryModel
    {
        private OnlineShopDbContext context = null;
        public CategoryModel()
        {
            context = new OnlineShopDbContext();
        }

        public List<Category> ListAll()
        {
            var list = context.Database.SqlQuery<Category>("Sp_Category_ListAll").ToList();
            return list;
        }

        public int Create(Category obj)
        {
            object[] parameters = {
                new SqlParameter("@Name",obj.Name),
                new SqlParameter("@Alias",obj.Alias),
                new SqlParameter("@ParentID",obj.ParentID.HasValue?obj.ParentID:-1),
                new SqlParameter("@Order",obj.Order),
                new SqlParameter("@Status",obj.Status)
            };
            int res = context.Database.ExecuteSqlCommand("Sp_Category_Insert @Name,@Alias,@ParentID,@Order,@Status", parameters);
            return res;
        }
    }
}
