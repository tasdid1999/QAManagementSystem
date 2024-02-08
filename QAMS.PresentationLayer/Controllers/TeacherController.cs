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
    [Authorize(Roles = "teacher")]
    public class TeacherController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly ICommentService _commentService;
        private readonly UserManager<ApplicationUser> _userManager;
        public TeacherController(IQuestionService questionService, ICommentService commentService, UserManager<ApplicationUser> userManager)
        {
            _questionService = questionService;
            _userManager = userManager;
            _commentService = commentService;
        }
       

        [HttpGet("/teacher/questions")]
        public async Task<IActionResult> GetAll(int pageNumber)
        {
            try
            {
                if (pageNumber < 1) pageNumber = 1;
                var pageSize = 1;

                var questions = await _questionService.GetAllQuestionsAsync(pageNumber, pageSize);

               
                return View(questions);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        [HttpGet("/teacher/my-commented-question")]
        public async Task<IActionResult> GetAllById()
        {
            try
            {
                var userId = HttpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

                var question = await _questionService.GetAllQuestionBasedOnTeacherComment(Convert.ToInt32(userId));

               
                return View(question);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        [HttpGet("teacher/questions/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var question = await _questionService.GetQuestionByIdAsync(id);

                if (question is not null)
                {
                    var comments = await _commentService.GetAll(question.Id);

                    var response = new QuestionAndCommentVm(question, comments);

                    return View(response);
                   
                }
                else
                {
                    return RedirectToAction("GetAll", "Teacher");
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
                        return RedirectToAction("GetById", "Teacher", new { id = comment.QuestionId });
                    }
                }


                return View(comment);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }


    }
}

