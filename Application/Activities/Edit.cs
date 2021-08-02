using Application.Core;
using AutoMapper;
using Domain.Model;
using FluentValidation;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities
{
    public class Edit
    {
        /// <summary>
        /// Command class
        /// </summary>
        /// <seealso cref="MediatR.IRequest" />
        public class Command : IRequest<Result<Unit>>
        {
            /// <summary>
            /// Gets or sets the activity model.
            /// </summary>
            /// <value>
            /// The activity model.
            /// </value>
            public ActivityModel ActivityModel { get; set; }
        }

        /// <summary>
        /// Command Validator
        /// </summary>
        /// <seealso cref="FluentValidation.AbstractValidator{Domain.Model.ActivityModel}" />
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.ActivityModel).SetValidator(new ActivityValidator());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <seealso cref="MediatR.IRequestHandler{Application.Activities.Edit.Command}" />
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            /// <summary>
            /// Initializes a new instance of the <see cref="Handler"/> class.
            /// </summary>
            /// <param name="context">The context.</param>
            /// <param name="mapper">The mapper.</param>
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            /// <summary>
            /// Handles the specified request.
            /// </summary>
            /// <param name="request">The request.</param>
            /// <param name="cancellationToken">The cancellation token.</param>
            /// <returns></returns>
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.ActivityModel.Id);

                if (activity is null) return null;

                _mapper.Map(request.ActivityModel, activity);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result)
                    return Result<Unit>.Failure("Activity to edit not found");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
