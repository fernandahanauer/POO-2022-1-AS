namespace Domain.Interfaces
{
    public interface IBaseRepository<Entity>
    where Entity:class
    {
        Task<Entity> GetByIdAsync(int id);
        Task<List<Entity>> GetAllAsync();
        void Save(Entity t);
        bool Delete(int idEntity);
        void Update(Entity t);
    }

}