using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IUnitOfWork
    {
        ICourseRepository CourseRepository { get; }
        IParticipantRepository ParticipantRepository { get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}