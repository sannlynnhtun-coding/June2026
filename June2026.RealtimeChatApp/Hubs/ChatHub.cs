using Microsoft.AspNetCore.SignalR;

namespace June2026.RealtimeChatApp.Hubs;

public class ChatHub : Hub
{
    public async Task ServerReceiveMessageEvent(string user, string message)
    {
        await Clients.All.SendAsync("ClientReceiveMessageEvent", user, message);
    }
}
