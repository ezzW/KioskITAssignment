using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels;
using DMBackend.Infrastructure.Services.Helpers;

namespace Services
{
    public class QuestionService : IQuestionService
    {
        public HttpCallingService _httpCallingService;
        public QuestionService(HttpCallingService httpCallingService)
        {
            _httpCallingService = httpCallingService;
        }
        public Question GetQuestion(int question_id)
        {
            Question question = null;
            var URL = "https://api.stackexchange.com/2.2/questions/"+question_id+"?site=stackoverflow";
            question = _httpCallingService.Get<QuestionList>(URL, null).Items.FirstOrDefault();
            return question;
        }

        public IEnumerable<Question> GetQuestionsList()
        {
            List<Question> QuestionsList = null;
            var URL = "https://api.stackexchange.com/2.2/questions?pagesize=50&order=desc&sort=creation&site=stackoverflow";
            QuestionsList = _httpCallingService.Get<QuestionList>(URL, null).Items;
            return QuestionsList;
        }
    }
}
