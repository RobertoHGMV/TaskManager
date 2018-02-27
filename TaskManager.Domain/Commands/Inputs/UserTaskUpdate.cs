namespace TaskManager.Domain.Commands.Inputs
{
    public class UserTaskUpdate
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
