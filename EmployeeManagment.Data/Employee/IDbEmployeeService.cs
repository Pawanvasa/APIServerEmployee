using Microsoft.AspNetCore.JsonPatch;

namespace EmployeeManagment.Services
{
    public interface IDbEmployeeService<Entity, TEntity, in TPK> where TEntity : class where Entity : class
    {
        IEnumerable<Entity> GetAll();
        Entity Get(TPK id);
        Entity Create(TEntity entity);
        Entity Update(TEntity entity);
        Entity Delete(TPK id);
        Entity Patch(JsonPatchDocument entity, TPK id);
    }
}
