using ApplicationCore.Models.QuizAggregate;
using BackendLab01;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/v1/quizzes")]
public class QuizController : ControllerBase
{
    private readonly IQuizUserService _service;
    
    public QuizController(IQuizUserService service)
    {
        _service = service;
    }
    [HttpGet("example")]
    public IActionResult GetExampleQuizItem()
    {
        // Tworzenie przykładowego obiektu QuizItem
        var quizItem = new QuizItem(
            id: 4,
            question: "7 - 2",
            incorrectAnswers: new List<string> { "2", "3", "6" },
            correctAnswer: "5"
        );

        // Konwersja na QuizItemDto
        var quizItemDto = QuizItemDto.of(quizItem);

        // Zwracanie danych w formacie JSON
        return Ok(quizItemDto);
    }
    
    [HttpGet]
    [Route("{id}")]
    public ActionResult<QuizDto> FindById(int id)
    {
        // Pobranie obiektu Quiz z serwisu
        var quiz = _service.FindQuizById(id);

        // Jeśli quiz jest null, zwróć 404 Not Found
        if (quiz == null)
        {
            return NotFound();
        }

        // Konwersja obiektu Quiz na QuizDto
        var quizDto = QuizDto.of(quiz);

        // Zwrócenie obiektu QuizDto z kodem 200 OK
        return Ok(quizDto);
    }
    [HttpGet]
    public IEnumerable<QuizDto> FindAll()
    {
        // Pobranie wszystkich quizów z serwisu
        var quizzes = _service.FindAllQuizzes();

        // Konwersja listy Quiz na listę QuizDto
        var quizDtos = quizzes.Select(QuizDto.of).ToList();

        return quizDtos;
    }
    [HttpPost]
    [Route("{quizId}/items/{itemId}")]
    public IActionResult SaveAnswer(int quizId, int itemId, [FromBody] QuizItemAnswerDto dto)
    {
        // Wywołanie metody serwisu do zapisania odpowiedzi użytkownika
        _service.SaveUserAnswerForQuiz(quizId, dto.UserId, itemId, dto.Answer);

        // Zwrócenie statusu 200 OK
        return Ok();
    }
}