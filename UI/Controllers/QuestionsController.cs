using DMBackend.Infrastructure.Services.Helpers;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class QuestionsController : Controller
    {
        private  IQuestionService _questionService;
        private  HttpCallingService _httpCallingService;
        public QuestionsController(IQuestionService questionService,HttpCallingService httpCallingService )
        {
            this._httpCallingService = httpCallingService;
            this._questionService = questionService;
        }
        // GET: Questions
        public ActionResult Index()
        {  
            return View(_questionService.GetQuestionsList());
        }
        public ActionResult Show(int QId)
        {
            return View(_questionService.GetQuestion(QId));
        }
    }
}