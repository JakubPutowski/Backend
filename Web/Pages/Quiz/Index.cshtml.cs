using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackendLab01.Pages.Quiz;

public class Index : PageModel
{
    private readonly IQuizAdminService _admin;

    public Index(IQuizAdminService admin)
    {
        _admin = admin;
    }

    [BindProperty] 
    public List<ApplicationCore.Models.QuizAggregate.Quiz> Quizzes { get; set; }
    
    public void OnGet()
    {
        Quizzes = _admin.FindAllQuizzes();
    }
}