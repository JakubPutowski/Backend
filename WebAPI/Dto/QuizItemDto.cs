using ApplicationCore.Models.QuizAggregate;

namespace WebAPI.Dto;

public class QuizItemDto
{
    public int Id { get; set; } 
    public string Question { get; set; } 
    public List<string> Options { get; set; }
    
    public static QuizItemDto of(QuizItem quizItem)
    {
        return new QuizItemDto
        {
            Id = quizItem.Id,
            Question = quizItem.Question,
            Options = quizItem.IncorrectAnswers
                .Append(quizItem.CorrectAnswer) // Dodaj poprawną odpowiedź do listy niepoprawnych
                .OrderBy(x => Guid.NewGuid())  // Losowa kolejność opcji
                .ToList()
        };
    }
    
}