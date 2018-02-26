using System;
using System.Collections.Generic;
using TaskManager.Shared;
using TasksManager.Domain.Commands.Inputs;
using TasksManager.Domain.Models.Tasks;

namespace TasksManager.Domain.Commands.Handlers
{
    public class UserTaskHandler
    {
        private readonly ITaskRepository _repository;
        private readonly IVerify _verify;

        public UserTaskHandler(ITaskRepository repository, IVerify verify)
        {
            _repository = repository;
            _verify = verify;
        }

        public UserTask GetTask(int id)
        {
            var task = _repository.Get(id);

            if (_verify.IsNull(task))
                throw new Exception("Tarefa não encontrada");

            return task;
        }

        public IEnumerable<UserTask> GetAll()
        {
            return _repository.GetAll();
        }

        public void AddTask(UserTaskAdd taskAdd)
        {
            if (_repository.ExistWithName(taskAdd.Name))
                throw new Exception("Já existe tarefa com o nome informado");

            var task = new UserTask(taskAdd.Name, taskAdd.Description);
            _repository.Add(task);
        }

        public void UpdateTask(UserTaskUpdate taskUpdate)
        {
            var task = _repository.Get(taskUpdate.Id);

            if (_verify.IsNull(task))
                throw new Exception($"Tarefa [{taskUpdate.Name}] não encontrada");

            task.Update(taskUpdate.Name, taskUpdate.Description);

            _repository.Update(task);
        }

        public void DeleteTask(int id)
        {
            var task = _repository.Get(id);

            if (_verify.IsNull(task))
                throw new Exception("Tarefa não encontrada");

            _repository.Remove(task);
        }
    }
}
