﻿namespace SignalRSender
{
    public class ImageMessage
    {
        public byte[] ImageBinary { get; set; }
        public string ImageHeaders { get; set; } = string.Empty;
    }
}
