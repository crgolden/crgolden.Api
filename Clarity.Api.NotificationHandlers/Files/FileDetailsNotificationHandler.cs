﻿namespace Clarity.Api.Files
{
    using Core;
    using Microsoft.Extensions.Logging;

    public class FileDetailsNotificationHandler : DetailsNotificationHandler<FileDetailsNotification, FileModel>
    {
        public FileDetailsNotificationHandler(ILogger<FileDetailsNotificationHandler> logger) : base(logger)
        {
        }
    }
}