namespace Trade.Repo.Base
{
    public interface ICategoriesRepo
    {
       IEnumerable<Category> GetAll();
       Category GetById(int id);
       Category GetByName(string name);
       int Add(Category category);
       int Update(Category category);

    }
}
