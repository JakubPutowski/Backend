using ApplicationCore.Models.QuizAggregate;

namespace WebAPI.Dto;

public class QuizDto
{
    public int Id { get; set; } // Identyfikator quizu
    public string Title { get; set; } // Tytuł quizu
    public List<QuizItemDto> Items { get; set; } // Lista pytań w quizie

    // Metoda statyczna konwertująca obiekt Quiz na QuizDto
    public static QuizDto of(Quiz quiz)
    {
        return new QuizDto
        {
            Id = quiz.Id,
            Title = quiz.Title,
            Items = quiz.Items.Select(QuizItemDto.of).ToList()
        };
    }
}