﻿namespace Cef.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Core.Controllers;
    using Core.Interfaces;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Models;
    using Relationships;

    public class OrderProductsController : BaseRelationshipController<OrderProduct, Order, Product>
    {
        public OrderProductsController(IRelationshipService<OrderProduct, Order, Product> service, ILogger<OrderProductsController> logger)
            : base(service, logger)
        {
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<OrderProduct>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Index([DataSourceRequest] DataSourceRequest request = null)
        {
            return await base.Index(request);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("{id1:guid}/{id2:guid}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [ProducesResponseType(typeof(OrderProduct), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Details([FromRoute] Guid id1, [FromRoute] Guid id2)
        {
            return await base.Details(id1, id2);
        }

        [HttpPut("{id1:guid}/{id2:guid}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Edit([FromRoute] Guid id1, [FromRoute] Guid id2, [FromBody] OrderProduct relationship)
        {
            return await base.Edit(id1, id2, relationship);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [ProducesResponseType(typeof(OrderProduct), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Create([FromBody] OrderProduct relationship)
        {
            return await base.Create(relationship);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete("{id1:guid}/{id2:guid}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Delete([FromRoute] Guid id1, [FromRoute] Guid id2)
        {
            return await base.Delete(id1, id2);
        }
    }
}
