using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.ViewModels;

namespace API.Interfaces
{
    public interface IParticipantRepository
    {
        Task<IEnumerable<ParticipantViewModel>> GetParticipantsAsync();

        Task<Participant> GetParticipantByIdAsync(int id);

        Task<UpdateParticipantViewModel> GetParticipantByEmailAsync(string email);

        void Add(AddParticipantViewModel participant);

        void Update(Participant participant, int id);

    }
}