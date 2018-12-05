using PracticalTask.Domain.Interfaces;
using PracticalTask.Infra.Data.Context;

namespace PracticalTask.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PracticalTaskContext _context;

        public UnitOfWork(PracticalTaskContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
