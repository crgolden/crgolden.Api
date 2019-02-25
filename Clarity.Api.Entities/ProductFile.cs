﻿namespace Clarity.Api
{
    using System;
    using Core;

    public class ProductFile : Entity
    {
        public bool IsPrimary { get; set; }

        public Guid ProductId { get; private set; }

        public virtual Product Product { get; private set; }

        public Guid FileId { get; private set; }

        public virtual File File { get; private set; }

        public ProductFile(Guid productId, Guid fileId)
        {
            ProductId = productId;
            FileId = fileId;
        }
    }
}