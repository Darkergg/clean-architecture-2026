using MediatR;

namespace CleanArchitecture.Application.Features.Streamers.Commands.DeleteStreamer
{
    public class DeleteStreamerCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
