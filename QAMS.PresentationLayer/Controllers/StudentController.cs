using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QAMS.DataAccessLayer.DataContext;
using QAMS.ServiceLayer.ClientEntity.question;
using QAMS.ServiceLayer.questionService;

namespace QAMS.PresentationLayer.Controllers
{
    [Authorize(Roles ="student")]
    public class StudentController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly UserManager<ApplicationUser> _userManager;
        public StudentController(IQuestionService questionService, UserManager<ApplicationUser> userManager)
        {
            _questionService = questionService;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Created = false;
            ViewBag.SomethingWrong = false;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(QuestionRequestVm question)
        {
            try
            {
                if (ModelState.IsValid)

                {
                    var userId = HttpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

                    var isSucces = await _questionService.CreateQuestionAsync(question, Convert.ToInt32(userId));

                    if (isSucces)
                    {
                        ModelState.Clear();
                        ViewBag.Created = true;
                        ViewBag.SomethingWrong = false;
                        
                        return View();
                    }
                }
                ViewBag.Created = false;
                ViewBag.SomethingWrong = true;
               
                return View(question);
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber)
        {
            try
            {
                if (pageNumber < 1) pageNumber = 1;
                var pageSize = 1;

                var questions = await _questionService.GetAllQuestionsAsync(pageNumber , pageSize);

                
                return View(questions);
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllById()
        {
            try
            {
                var userId = HttpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

                var questions = await _questionService.GetAllQuestionsByIdAsync(Convert.ToInt32(userId));

                
                return View(questions);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var question = await _questionService.GetQuestionByIdAsync(id);
                if(question is not null)
                {
                   
                    return View(question);
                }
                else
                {
                    return RedirectToAction("GetAll","Student");
                }
               
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

    }
}
