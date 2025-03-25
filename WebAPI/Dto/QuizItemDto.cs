using ApplicationCore.Commons.Functions;
using ApplicationCore.Models.QuizAggregate;

namespace WebAPI.DTO;

public class QuizItemDto
{
    public int Id { get; set; }
    public string Question { get; set; }
    public List<string> Answers { get; set; } // Wszystkie możliwe odpowiedzi (łącznie z poprawną)

    private QuizItemDto()
    {
    }

    public static QuizItemDto of(QuizItem quizItem)
    {
        // Tworzymy listę odpowiedzi, łącząc poprawną i niepoprawne odpowiedzi
        var allAnswers = new List<string>(quizItem.IncorrectAnswers) { quizItem.CorrectAnswer };

        return new QuizItemDto
        {
            Id = quizItem.Id,
            Question = quizItem.Question,
            Answers = allAnswers
        };
    }
}