using System.ComponentModel.DataAnnotations;

namespace OnlineSurvey.Application.DTO
{
    public class ResultDTO
    {
        [Required(ErrorMessage = "Interviewid is required.")]
        public Guid InterviewId { get; set; }

        [Required(ErrorMessage = "Questionid is required.")]
        public Guid QuestionId { get; set; }

        [Required(ErrorMessage = "Answerid is required.")]
        public Guid AnswerId { get; set; }
    }
}
