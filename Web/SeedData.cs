using ApplicationCore.Commons.Repository;
using ApplicationCore.Models.QuizAggregate;
using BackendLab01;

namespace Infrastructure.Memory;
public static class SeedData
{
    public static void Seed(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;
            var quizRepo = provider.GetService<IGenericRepository<Quiz, int>>();
            var quizItemRepo = provider.GetService<IGenericRepository<QuizItem, int>>();
            
            //TODO Utwórz trzy pytania typu QuizItem
            //TODO Dodaj je do quizItemRepo
            //TODO Utwórz obiekt klasy Quiz z kolekcją pytań dodanych do quizItemRepo
            //TODO Dodaj Quiz do quizRepo
            
            List<QuizItem> quizItems = new List<QuizItem>();
            
            quizItems.Add(quizItemRepo.Add(new QuizItem(id: 1, correctAnswer: "6", question: "2 + 4",
                incorrectAnswers: new List<string>() {"5", "7", "8"})));
            quizItems.Add(quizItemRepo.Add(new QuizItem(id: 2, correctAnswer: "8", question: "2 * 4",
                incorrectAnswers: new List<string>() {"4", "6", "9"})));
            quizItems.Add(quizItemRepo.Add(new QuizItem(id: 3, correctAnswer: "4", question: "8 / 2",
                incorrectAnswers: new List<string>() {"5", "7", "8"})));
            quizRepo.Add(new Quiz(id: 1, items: quizItems, title: "Matematyka"));
            
            List<QuizItem> quizItems1 = new List<QuizItem>();
            quizItems1.Add(quizItemRepo.Add(new QuizItem(id: 1, correctAnswer: "Pies", question: "Które zwierze jest ssakiem?",
                incorrectAnswers: new List<string>() {"Jaszczurka", "Ryba", "Żaba"})));
            quizItems1.Add(quizItemRepo.Add(new QuizItem(id: 2, correctAnswer: "Nietoperz", question: "Który ssak potrafi latać?",
                incorrectAnswers: new List<string>() {"Wiewiórka", "Jeż", "Królik"})));
            quizItems1.Add(quizItemRepo.Add(new QuizItem(id: 3, correctAnswer: "Płetwal błękitny", question: "Który ssak jest najcięższy?",
                incorrectAnswers: new List<string>() {"Słoń afrykański", "Hipopotam", "Nosorożec biały"})));
            quizRepo.Add(new Quiz(id: 2, items: quizItems1, title: "Zwierzęta"));
            
            List<QuizItem> quizItems2 = new List<QuizItem>();
            quizItems2.Add(quizItemRepo.Add(new QuizItem(id: 1, correctAnswer: "12", question: "Ile jest miesięcy w roku?",
                incorrectAnswers: new List<string>() {"13", "11", "10"})));
            quizItems2.Add(quizItemRepo.Add(new QuizItem(id: 2, correctAnswer: "4", question: "Ile jest pór roku?",
                incorrectAnswers: new List<string>() {"2", "3", "5"})));
            quizItems2.Add(quizItemRepo.Add(new QuizItem(id: 3, correctAnswer: "Lipiec", question: "Jaki miesiąc jest po czerwcu?",
                incorrectAnswers: new List<string>() {"Maj", "Luty", "Grudzień"})));
            quizRepo.Add(new Quiz(id: 3, items: quizItems2, title: "Wiedza ogólna"));
            
        }
    }
}