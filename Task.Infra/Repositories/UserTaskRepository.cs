using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Task.Infra.Contexts;
using TasksManager.Domain.Models.Tasks;

namespace Task.Infra.Repositories
{
    public class UserTaskRepository : IUserTaskRepository
    {
        private readonly TaskDataContext _context;

        public UserTaskRepository(TaskDataContext context)
        {
            _context = context;
        }

        public bool ExistWithName(string name)
        {
            return _context.Tasks.Any(c => c.Name == name);
        }

        public UserTask Get(int id)
        {
            return _context.Tasks.AsNoTracking().FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<UserTask> GetAll()
        {
            return _context.Tasks.AsNoTracking();
        }

        public void Add(UserTask task)
        {
            _context.Tasks.Add(task);
        }

        public void Update(UserTask task)
        {
            _context.Entry(task).State = EntityState.Modified;
        }

        public void Remove(UserTask task)
        {
            _context.Tasks.Remove(task);
        }
    }
}
