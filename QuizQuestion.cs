using System.Collections.Generic;

namespace POE_PROG_YEAR_2.Models
{
    public class QuizQuestion
    {
        public string QuestionText { get; set; } = string.Empty;
        public List<string> Options { get; set; } = new List<string>();
        public string CorrectAnswer { get; set; } = string.Empty;
        public string Explanation { get; set; } = string.Empty;
        public bool IsTrueFalse { get; set; } = false;
    }
}