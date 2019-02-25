﻿namespace Clarity.Api
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Core;
    using Kendo.Mvc.UI;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Payments;

    [Authorize(AuthenticationSchemes = "Bearer")]
    public class PaymentsController : Controller<Payment, PaymentModel, Guid>
    {
        public PaymentsController(IMediator mediator) : base(mediator)
        {
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<Payment>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Index([DataSourceRequest] DataSourceRequest request)
        {
            return await base.Index(
                request: new PaymentIndexRequest(ModelState, request),
                notification: new PaymentIndexNotification()).ConfigureAwait(false);
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(Payment), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Details([FromQuery] Guid[] ids)
        {
            if (ids.Length != 1) return BadRequest(ids);
            return await base.Details(
                request: new PaymentDetailsRequest(ids[0], UserId),
                notification: new PaymentDetailsNotification()).ConfigureAwait(false);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Edit([FromBody] PaymentModel payment)
        {
            return await base.Edit(
                request: new PaymentEditRequest(payment),
                notification: new PaymentEditNotification()).ConfigureAwait(false);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> EditRange([FromBody] IEnumerable<PaymentModel> payments)
        {
            return await base.EditRange(
                request: new PaymentEditRangeRequest(payments),
                notification: new PaymentEditRangeNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(Payment), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Create([FromBody] PaymentModel payment)
        {
            if (User.HasClaim(x => x.Type.Equals("customer_code")))
            {
                payment.CustomerCode = User.FindFirst("customer_code").Value;
            }

            return await base.Create(
                request: new PaymentCreateRequest(payment)
                {
                    Email = UserEmail
                },
                notification: new PaymentCreateNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<Payment>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> CreateRange([FromBody] IEnumerable<PaymentModel> payments)
        {
            return await base.CreateRange(
                request: new PaymentCreateRangeRequest(payments),
                notification: new PaymentCreateRangeNotification()).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Delete([FromQuery] Guid[] ids)
        {
            if (ids.Length != 1) return BadRequest(ids);
            return await base.Delete(
                request: new PaymentDeleteRequest(ids[0]),
                notification: new PaymentDeleteNotification()).ConfigureAwait(false);
        }
    }
}