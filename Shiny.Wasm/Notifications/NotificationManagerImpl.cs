using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Shiny.Notifications;


namespace Shiny.Wasm.Notifications
{
    //https://developer.mozilla.org/en-US/docs/Web/API/Notification
    public class NotificationManagerImpl : INotificationManager
    {
        readonly IJSInProcessRuntime interop;
        public NotificationManagerImpl(IJSInProcessRuntime interop) => this.interop = interop;


        public int Badge { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public Task Cancel(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Clear()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Notification>> GetPending()
        {
            throw new System.NotImplementedException();
        }

        public void RegisterCategory(NotificationCategory category)
        {
            throw new System.NotImplementedException();
        }

        public Task<AccessState> RequestAccess()
        {
            
            throw new System.NotImplementedException();
        }

        public Task Send(Notification notification)
        {
            throw new System.NotImplementedException();
        }
    }
}
