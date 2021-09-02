using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using API.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ParticipantRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ParticipantViewModel>> GetParticipantsAsync()
        {
            var result = await _context.Participants.ToListAsync();
            var mapped = _mapper.Map<IEnumerable<ParticipantViewModel>>(result);
            return mapped;
        }

        public async Task<Participant> GetParticipantByIdAsync(int id)
        {
            return await _context.Participants.FindAsync(id);
        }

        public async Task<UpdateParticipantViewModel> GetParticipantByEmailAsync(string email)
        {
            var participantEntity = await _context.Participants.SingleOrDefaultAsync(participant => participant.Email.Equals(email));
            return _mapper.Map<UpdateParticipantViewModel>(participantEntity);
        }
      
        public void Add(AddParticipantViewModel participant)
        {
            var participantToAdd = _mapper.Map<Participant>(participant, opt =>
                 {
                     opt.Items["repo"] = _context;
                 });
            _context.Entry(participantToAdd).State = EntityState.Added;
        }

        public void Update(Participant participant, int id)
        {
            _context.Entry(participant).State = EntityState.Modified;
        }
    }
}