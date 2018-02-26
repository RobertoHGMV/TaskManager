using System;
using Task.Infra.Contexts;

namespace Task.Infra.Transactions
{
    public class Uow : IUow
    {
        private readonly TaskDataContext _context;

        public Uow(TaskDataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
