using Microsoft.AspNetCore.Mvc;
using QAMS.ServiceLayer.ClientEntity.question;
using QAMS.ServiceLayer.questionService;

namespace QAMS.PresentationLayer.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(QuestionRequestVm question)
        {
            if(ModelState.IsValid)
            {
               var isSucces =  await _questionService.CreateQuestionAsync(question);

                if (isSucces)
                {

                }
            }
            return View(question);
        }

        [HttpGet]
        public  IActionResult GetAll()
        {
            return View();
        }

    }
}
