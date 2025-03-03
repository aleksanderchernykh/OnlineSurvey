using OnlineSurvey.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.Application.Response
{
    public class QuestionResponse
    {
        public Guid Id { get; set; }

        public Guid SurveyId { get; set; }

        public string QuestionText { get; set; } = null!;

        public int QuestionOrder { get; set; }

        public virtual ICollection<AnswerResponse> Answers { get; set; } = new List<AnswerResponse>();
    }
}
