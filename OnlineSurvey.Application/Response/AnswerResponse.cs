using OnlineSurvey.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.Application.Response
{
    public class AnswerResponse
    {
        public Guid Id { get; set; }

        public Guid QuestionId { get; set; }

        public string AnswerText { get; set; } = null!;

        public int AnswerOrder { get; set; }
    }
}
