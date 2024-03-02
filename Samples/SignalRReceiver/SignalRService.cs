﻿using Microsoft.AspNetCore.SignalR.Client;
using System.Diagnostics;

namespace SignalRReceiver
{
    public class SignalRService : BackgroundService
    {
        private static Microsoft.AspNetCore.SignalR.Client.HubConnection? _hubConnection;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _hubConnection = new HubConnectionBuilder()
                 .WithUrl("https://localhost꞉5001/chat")
                 .AddMessagePackProtocol()
                 .ConfigureLogging(factory =>
                 {
                     factory.AddConsole();
                     factory.AddFilter("Console", level => level >= LogLevel.Trace);
                 }).Build();

            _hubConnection.On<ImageMessage>("Upload", OnFileReceived);

            await _hubConnection.StartAsync();
        }

        private void OnFileReceived(ImageMessage message)
        {
            Debug.WriteLine("Received File");
        }
    }

    public class ImageMessage
    {
        public byte[]? ImageBinary { get; set; }
        public string ImageHeaders { get; set; } = string.Empty;
    }
}
