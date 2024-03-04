using Microsoft.AspNetCore.SignalR;

namespace SignalRSender.Hubs
{
    public class ImagesHub : Hub
    {
        public const string HubUrl = "/images";

        public async Task Upload(ImageMessage message)
        {
            await Clients.Others.SendAsync("Upload", message);
        }

        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"{Context.ConnectionId} connected");
            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception e)
        {
            Console.WriteLine($"Disconnected {e?.Message} {Context.ConnectionId}");
            await base.OnDisconnectedAsync(e);
        }
    }
}
