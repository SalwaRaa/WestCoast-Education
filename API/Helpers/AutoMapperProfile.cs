using API.Entities;
using API.ViewModels;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //course
            CreateMap<Course, CourseViewModel>();
            CreateMap<CourseViewModel, Course>();

            CreateMap<Course, AddCourseViewModel>();
            CreateMap<AddCourseViewModel, Course>();

            CreateMap<Course, UpdateCourseViewModel>();
            CreateMap<UpdateCourseViewModel, Course>();

            //participant
            CreateMap<Participant, ParticipantViewModel>();
            CreateMap<ParticipantViewModel, Participant>();

            CreateMap<AddParticipantViewModel, Participant>();
            CreateMap<Participant, AddParticipantViewModel>();

            CreateMap<UpdateParticipantViewModel, Participant>();
            CreateMap<Participant, UpdateParticipantViewModel>();

        }
    }
}