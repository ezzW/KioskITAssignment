using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
   public interface IQuestionService
    {
        IEnumerable<Question> GetQuestionsList();
        Question GetQuestion(int question_id);

    }
}
