using Microsoft.EntityFrameworkCore;
using Trade.Repo.Base;

namespace Trade.Repo
{
    public class CategoriesRepo : ICategoriesRepo
    {
        private readonly AppDbContext _appDbContext;
        public CategoriesRepo(AppDbContext appDbContext)
        {
              _appDbContext = appDbContext;
        }

        public int Add(Category category)
        {
          _appDbContext.Categories.Add(category);
          return _appDbContext.SaveChanges();
        }

        public int Delete(Category category)
        {
            _appDbContext.Categories.Remove(category);
            return _appDbContext.SaveChanges();
        }

        public IEnumerable<Category> GetAll()
        {
            return _appDbContext.Categories.ToList();
        }

        public Category GetById(int id)
        {
           var category = _appDbContext.Categories.FirstOrDefault(c => c.Id == id);
            if(category != null)
                return category;
            return null;
        }

        public Category GetByName(string name)
        {
            var cate = _appDbContext.Categories.SingleOrDefault(c => c.Name == name);
            if (cate != null) return cate;
            else return null;
        }

        public int Update(Category category)
        {
            _appDbContext.Categories.Update(category);
            return _appDbContext.SaveChanges();
        }
    }
}
