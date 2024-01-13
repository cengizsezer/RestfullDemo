namespace RestfullDemo.Repository.Interface
{
    public interface IGenericRepository<T> where T : class, new()
    {
        //CRUD Create Update Read Delete

        T Add(T model);
        T Delete(T model);

        T GetbyId(int id);

        List<T> GetAll();

         void DeleteAll();

        T UpdateById(T model, int id);
    }
}
