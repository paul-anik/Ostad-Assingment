using Microsoft.AspNetCore.Mvc;
using QnAApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace QnAApp.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var questions = await _context.Questions.ToListAsync();
            return View(questions); // Must have Views/Questions/Index.cshtml
        }
    }
}
