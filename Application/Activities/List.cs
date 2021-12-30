using Application.Core;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<Result<PagedLists<ActivityDto>>>
        {
            public ActivityParams Params { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<PagedLists<ActivityDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            private readonly IUserAccessor _userAccessor;

            /// <summary>
            /// Initializes a new instance of the <see cref="Handler"/> class.
            /// </summary>
            /// <param name="context">The context.</param>
            public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor)
            {
                _context = context;
                _mapper = mapper;
                _userAccessor = userAccessor;
            }

            /// <summary>
            /// Handles a request
            /// </summary>
            /// <param name="request">The request</param>
            /// <param name="cancellationToken">Cancellation token</param>
            /// <returns>
            /// Response from the request
            /// </returns>
            public async Task<Result<PagedLists<ActivityDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.Activities
                    .Where(d => d.Date >= request.Params.StartDate)
                    .OrderBy(d => d.Date)
                    .ProjectTo<ActivityDto>(_mapper.ConfigurationProvider,
                        new { currentUserName = _userAccessor.GetUserName() })
                    .AsQueryable();

                if (request.Params.IsGoing && !request.Params.IsHost)
                    query = query.Where(x => x.Attendees.Any(a => a.Username == _userAccessor.GetUserNameId()));

                if (request.Params.IsHost && !request.Params.IsGoing)
                    query = query.Where(x => x.HostUsername == _userAccessor.GetUserNameId());

                return Result<PagedLists<ActivityDto>>.Success(
                    await PagedLists<ActivityDto>.CreateAsync(
                        query,
                        request.Params.PageNumber,
                        request.Params.PageSize)
                    );
            }
        }

    }
}
