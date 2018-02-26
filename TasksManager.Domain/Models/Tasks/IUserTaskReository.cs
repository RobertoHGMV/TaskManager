using System.Collections.Generic;

namespace TasksManager.Domain.Models.Tasks
{
    public interface IUserTaskRepository
    {
        bool ExistWithName(string name);

        UserTask Get(int id);

        IEnumerable<UserTask> GetAll();

        void Add(UserTask task);

        void Update(UserTask task);

        void Remove(UserTask task);
    }
}
