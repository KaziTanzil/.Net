using DAL.EF.Tables;
using DAL.Interfaces;
using System.Linq;

namespace DAL.Repos
{
    public class CategoryRepo : Repo<Category, int>
    {
        public Category GetByName(string name)
        {
            var query = from c in db.Categories
                        where c.Name == name
                        select c;
            return query.SingleOrDefault();
        }
    }
}
