﻿namespace Clarity.Api
{
    using System;
    using Core;

    public class CartProductModel : Model
    {
        public decimal Quantity { get; set; }

        public decimal ExtendedPrice => Quantity * ProductUnitPrice;

        public Guid CartId { get; set; }

        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductImageThumbnailUri { get; set; }

        public bool ProductIsDownload { get; set; }

        public decimal ProductUnitPrice { get; set; }
    }
}