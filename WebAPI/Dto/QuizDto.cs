using ApplicationCore.Models.QuizAggregate;
using WebAPI.DTO;

namespace WebAPI.Dto;

public class QuizDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public List<QuizItemDto> Items { get; set; } // Lista pytań w quizie

    private QuizDto()
    {
    }

    public static QuizDto of(Quiz quiz)
    {
        return new QuizDto
        {
            Id = quiz.Id,
            Title = quiz.Title,
            Items = quiz.Items.Select(QuizItemDto.of).ToList() // Mapowanie pytań na DTO
        };
    }
}