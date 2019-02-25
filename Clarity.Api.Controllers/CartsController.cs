﻿namespace Clarity.Api
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Carts;
    using Core;
    using Kendo.Mvc.UI;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CartsController : Controller<Cart, CartModel, Guid>
    {
        public CartsController(IMediator mediator) : base(mediator)
        {
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<Cart>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Index([DataSourceRequest] DataSourceRequest request)
        {
            return await base.Index(
                request: new CartIndexRequest(ModelState, request),
                notification: new CartIndexNotification()).ConfigureAwait(false);
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Cart), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Details([FromQuery] Guid[] ids)
        {
            if (ids.Length != 1) return BadRequest(ids);
            return await base.Details(
                request: new CartDetailsRequest(ids[0], UserId),
                notification: new CartDetailsNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Edit([FromBody] CartModel cart)
        {
            if (!cart.UserId.HasValue && UserId.HasValue) cart.UserId = UserId.Value;
            return await base.Edit(
                request: new CartEditRequest(cart),
                notification: new CartEditNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> EditRange([FromBody] IEnumerable<CartModel> carts)
        {
            return await base.EditRange(
                request: new CartEditRangeRequest(carts),
                notification: new CartEditRangeNotification()).ConfigureAwait(false);
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Cart), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Create([FromBody] CartModel cart)
        {
            if (!cart.UserId.HasValue && UserId.HasValue) cart.UserId = UserId.Value;
            return await base.Create(
                request: new CartCreateRequest(cart),
                notification: new CartCreateNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<Cart>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> CreateRange([FromBody] IEnumerable<CartModel> carts)
        {
            return await base.CreateRange(
                request: new CartCreateRangeRequest(carts),
                notification: new CartCreateRangeNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Delete([FromQuery] Guid[] ids)
        {
            if (ids.Length != 1) return BadRequest(ids);
            return await base.Delete(
                request: new CartDeleteRequest(ids[0]),
                notification: new CartDeleteNotification()).ConfigureAwait(false);
        }
    }
}