using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace UrmetJournal.Hubs
{
    public class ScheduleHub : Hub
    {
        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }
    }
}