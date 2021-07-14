using Application.Core;
using Domain.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<Result<List<ActivityModel>>> { }

        public class Handler : IRequestHandler<Query, Result<List<ActivityModel>>>
        {
            private readonly DataContext _context;

            /// <summary>
            /// Initializes a new instance of the <see cref="Handler"/> class.
            /// </summary>
            /// <param name="context">The context.</param>
            public Handler(DataContext context)
            {
                _context = context;
            }

            /// <summary>
            /// Handles a request
            /// </summary>
            /// <param name="request">The request</param>
            /// <param name="cancellationToken">Cancellation token</param>
            /// <returns>
            /// Response from the request
            /// </returns>
            public async Task<Result<List<ActivityModel>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<ActivityModel>>.Success(await _context.Activities.ToListAsync());
            }
        }

    }
}
