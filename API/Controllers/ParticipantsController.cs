using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/participants")]
    public class ParticipantsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ParticipantsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParticipantViewModel>>> GetParticipants()
        {
            var result = await _unitOfWork.ParticipantRepository.GetParticipantsAsync();
            if (result == null) return StatusCode(500, "Something went wrong");
            return Ok(result);
        }
        [HttpGet("searchid/{id}")]
        public async Task<ActionResult<Participant>> GetParticipantById(int id)
        {
            var result = await _unitOfWork.ParticipantRepository.GetParticipantByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

         [HttpPost()]
        public async Task<ActionResult> AddParticipant(AddParticipantViewModel participant)
        {
            try
            {
                var result = await _unitOfWork.ParticipantRepository.GetParticipantByEmailAsync(participant.Email);
                if (result != null) return BadRequest("The participant already exists in the system");

                _unitOfWork.ParticipantRepository.Add(participant);
                if (await _unitOfWork.Complete()) return StatusCode(201, participant.Email);

                return StatusCode(500, "Unfortinatly, we were unable to save the participant");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPatch("{id}")]

        public async Task<ActionResult> UpdateParticipant(int id, UpdateParticipantViewModel model)
        {
            try
            {
                var participant = await _unitOfWork.ParticipantRepository.GetParticipantByIdAsync(id);

                participant.FirstName = model.FirstName;
                participant.LastName = model.LastName;
                participant.PhoneNumber = model.PhoneNumber;
                participant.Address = model.Address;

                _unitOfWork.ParticipantRepository.Update(participant, id);

                if (await _unitOfWork.Complete()) return NoContent();

                return StatusCode(500, "We were unable to save the changes");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
