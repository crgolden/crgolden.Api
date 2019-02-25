﻿namespace Clarity.Api.CartProducts
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Core;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;

    public class CartProductIndexRequestHandler : IndexRequestHandler<CartProductIndexRequest, CartProduct, CartProductModel>
    {
        private readonly IStorageService _storageService;
        private readonly StorageOptions _storageOptions;

        public CartProductIndexRequestHandler(
            DbContext context,
            IMapper mapper,
            IStorageService storageService,
            IOptions<StorageOptions> storageOptions) : base(context, mapper)
        {
            _storageService = storageService;
            _storageOptions = storageOptions.Value;
        }

        public override async Task<DataSourceResult> Handle(CartProductIndexRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await Context.Set<CartProduct>()
                .Include(x => x.Product)
                .ThenInclude(x => x.ProductFiles)
                .ThenInclude(x => x.File)
                .AsNoTracking()
                .ToDataSourceResultAsync(request.Request, request.ModelState, cartProduct =>
                {
                    var model = Mapper.Map<CartProductModel>(cartProduct);
                    var productFile = cartProduct.Product.ProductFiles
                        .SingleOrDefault(x => x.File.ContentType.Contains("image") && x.IsPrimary);
                    if (productFile == null) return model;
                    model.ProductImageThumbnailUri = productFile.File.GetImageFileUri(
                        storageService: _storageService,
                        options: _storageOptions,
                        thumbnail: true);
                    return model;
                })
                .ConfigureAwait(false);
        }
    }
}