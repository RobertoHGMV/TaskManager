using System;
using TaskManager.Shared;

namespace TasksManager.Domain.Models.Tasks
{
    public class UserTask
    {
        private readonly IVerify _verify;

        protected UserTask() { }

        public UserTask(string name, string description)
        {
            _verify = new Verify();

            Name = name;
            Description = description;
            DateAdd = DateTime.Now;

            Validate();
        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateAdd { get; private set; }

        public void Update(string name, string description)
        {
            Name = name;
            Description = description;

            Validate();
        }

        public void Validate()
        {
            if (_verify.IsNullOrEmpty(Name))
                throw new Exception("Nome não informado");

            if (_verify.IsNullOrEmpty(Description))
                throw new Exception("Descrição não informada");
        }
    }
}
