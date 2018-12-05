using System.Threading.Tasks;
using PracticalTask.Domain.Core.Commands;
using PracticalTask.Domain.Core.Events;

namespace PracticalTask.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
