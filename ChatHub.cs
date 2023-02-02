using Microsoft.AspNetCore.SignalR;

namespace LaMafiaRS
{
    public class ChatHub : Hub
    {
        public static int UserCount = 0;
        public async Task SendMessage(string room, string user, string message)
        {
            await Clients.Group(room).SendAsync("ReceiveMessage", user, message);
        }

        public async Task AddToGroup(string room)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, room);
            await Clients.Group(room).SendAsync("ShowWho", 
                $"Alguien se conectó "/*{Context.ConnectionId}*/);
        }
        public override async Task OnConnectedAsync()
        {
            UserCount++;
            await Clients.All.SendAsync("UserConnected", UserCount);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            UserCount--;
            await Clients.All.SendAsync("UserDisconnected", UserCount);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
