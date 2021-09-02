using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
//For the next step on this project, to make a relation database, many to many. This is not implemented yet in the project as for now.
{
    [Table("CourseParticipant", Schema = "CourseParticipants")]
    public class CourseParticipant
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int ParticipantId { get; set; }
        
        //Navigation Properties
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        [ForeignKey("ParticipantId")]
        public virtual Participant Participant { get; set; }
    }
}