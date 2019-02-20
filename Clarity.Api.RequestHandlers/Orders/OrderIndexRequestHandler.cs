﻿namespace Clarity.Api.Orders
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Kendo.Mvc;
    using Kendo.Mvc.UI;
    using Microsoft.EntityFrameworkCore;

    public class OrderIndexRequestHandler : IndexRequestHandler<OrderIndexRequest, Order>
    {
        public OrderIndexRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<DataSourceResult> Handle(OrderIndexRequest request, CancellationToken cancellationToken)
        {
            if (!request.UserId.HasValue)
            {
                return await base.Handle(request, cancellationToken).ConfigureAwait(false);
            }

            var userIdFilter = new FilterDescriptor(
                member: "userId",
                filterOperator: FilterOperator.IsEqualTo,
                filterValue: $"{request.UserId.Value}");
            var filter = request.Request.Filters
                .Cast<FilterDescriptor>()
                .SingleOrDefault(x => x.Member == userIdFilter.Member);
            if (filter != null)
            {
                if ($"{filter.Value}" != $"{userIdFilter.Value}")
                {
                    filter.Value = userIdFilter.Value;
                }

                if (filter.Operator != userIdFilter.Operator)
                {
                    filter.Operator = userIdFilter.Operator;
                }
            }
            else
            {
                request.Request.Filters.Add(userIdFilter);
            }

            return await base.Handle(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
