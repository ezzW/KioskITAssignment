using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
  public class Question
    {
        public  string[] tags { get; set; }
        public Owner owner { get; set; }
        [DisplayName("Is Answered")]
        public bool is_answered { get; set; }
        [DisplayName("Views")]
        public int view_count { get; set; }
        [DisplayName("Answers")]
        public int answer_count { get; set; }
        [DisplayName("Score")]
        public int score { get; set; }
        [DisplayName("Last Activity")]
        public int last_activity_date { get; set; }
        [DisplayName("Creation Date")]
        public int creation_date { get; set; }
        public int question_id { get; set; }
        [DisplayName("Link")]
        public string link { get; set; }
        [DisplayName("Title")]
        public string title { get; set; }
    }
}
