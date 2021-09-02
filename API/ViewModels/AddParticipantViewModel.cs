namespace API.ViewModels
{
     //dubplicated code from ParticipantViewModel in the first development-stage, 
     //however in second development-stage more information will be added here such as city and postal code
    public class AddParticipantViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int PhoneNumber { get; set; }

        public string Address { get; set; }
    }
}