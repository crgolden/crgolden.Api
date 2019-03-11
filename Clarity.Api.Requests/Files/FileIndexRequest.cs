﻿namespace Clarity.Api.Files
{
    using Core;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class FileIndexRequest : IndexRequest<Api.File, Api.FileModel>
    {
        public FileIndexRequest(ModelStateDictionary modelState, DataSourceRequest request) : base(modelState, request)
        {
        }
    }
}
