namespace EmployeeManagment.Services
{
    public interface IDbDepartmentService<TEntity, in TPK> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
    }
}
