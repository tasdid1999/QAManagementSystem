using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QAMS.DataAccessLayer.DataContext;
using QAMS.ServiceLayer.ClientEntity.comment;
using QAMS.ServiceLayer.ClientEntity.common;
using QAMS.ServiceLayer.ClientEntity.question;
using QAMS.ServiceLayer.comment;
using QAMS.ServiceLayer.questionService;

namespace QAMS.PresentationLayer.Controllers
{
    [Authorize(Roles ="student")]
    public class StudentController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly ICommentService _commentService;
        private readonly UserManager<ApplicationUser> _userManager;
        public StudentController(IQuestionService questionService, ICommentService commentService, UserManager<ApplicationUser> userManager)
        {
            _questionService = questionService;
            _commentService = commentService;   
            _userManager = userManager;
        }
        [HttpGet("/student/post-question")]
        public IActionResult Create()
        {
            ViewBag.Created = false;
            ViewBag.SomethingWrong = false;

            return View();
        }
        [HttpPost("/student/post-question")]
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

        [HttpGet("/student/questions")]
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
        [HttpGet("/student/my-questions")]
        public async Task<IActionResult> GetAllById()
        {
            try
            {
                var userId = HttpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

                var questions = await _questionService.GetAllQuestionsByIdAsync(Convert.ToInt32(userId));

                ViewBag.Deleted = false;
                ViewBag.NoTDeleted = false;

                return View(questions);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        [HttpGet("/student/question/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {

                var question = await _questionService.GetQuestionByIdAsync(id);

            
                if(question is not null)
                {
                    var userId = Convert.ToInt32(HttpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);
                   
                    if (question.CreatedBy == userId)
                    {
                        question.IsCommentBoxActivate = false;
                    }
                    var comments = await _commentService.GetAll(question.Id);

                    var response = new QuestionAndCommentVm(question, comments);

                    return View(response);
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
        [HttpPost]
        public async Task<IActionResult> Comment(CommentRequestVm comment)
        {
            try
            {
                if (ModelState.IsValid)

                {
                    var userId = HttpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

                    var isSucces = await _commentService.Create(comment, Convert.ToInt32(userId));

                    if (isSucces)
                    {
                        ModelState.Clear();
                        return RedirectToAction("GetById","Student",new {id = comment.QuestionId});
                    }
                }
            

                return View(comment);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _questionService.DeleteQuestionAsync(id);
            if (isDeleted)
            {
                ViewBag.Deleted = true;
                ViewBag.NoTDeleted = false;
                return RedirectToAction("GetAllById", "Student");
            }
            else
            {
                ViewBag.Deleted = false;
                ViewBag.NoTDeleted = true;
                return RedirectToAction("GetAllById", "Student");
            }
        }
           
            
        }

    }

