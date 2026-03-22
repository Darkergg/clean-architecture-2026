using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;namespace CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommandHandler : IRequestHandler<UpdateStreamerCommand, int>
    {
        private readonly IStreamerRepository _streamerRepository;

        private readonly IMapper _mapper;

        private readonly ILogger<UpdateStreamerCommandHandler> _logger;

        public UpdateStreamerCommandHandler(IStreamerRepository streamerRepository, IMapper mapper, ILogger<UpdateStreamerCommandHandler> logger)
        {
            _streamerRepository = streamerRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(UpdateStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerToUpdate = await _streamerRepository.GetByIdAsync(request.Id);

            if (streamerToUpdate == null)
            {
                _logger.LogError($"Streamer with id {request.Id} not found.");
                throw new NotFoundException(nameof(Streamer), request.Id);
            }

            //request --->  StreamerToUpdate - id, nombre, url it must replace the data.

            _mapper.Map(request, streamerToUpdate, typeof(UpdateStreamerCommand), typeof(Streamer));

            await _streamerRepository.UpdateAsync(streamerToUpdate);

            _logger.LogInformation($"Streamer with id {request.Id} updated successfully.");

            return streamerToUpdate.Id;
        }
    }
}