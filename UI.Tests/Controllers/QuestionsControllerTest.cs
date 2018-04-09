using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UI;
using UI.Controllers;
using DMBackend.Infrastructure.Services.Helpers;
using Services;
using DomainModels;

namespace UI.Tests.Controllers
{
    [TestClass]
    public class QuestionsControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HttpCallingService _httpCallingService = new HttpCallingService();
            IQuestionService _questionService = new QuestionService(_httpCallingService);
            QuestionsController controller = new QuestionsController(_questionService,_httpCallingService);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexData()
        {
            // Arrange
            HttpCallingService _httpCallingService = new HttpCallingService();
            IQuestionService _questionService = new QuestionService(_httpCallingService);
            QuestionsController controller = new QuestionsController(_questionService, _httpCallingService);

            // Act
            ViewResult result = controller.Index() as ViewResult;
            var QuestionsList = (List<Question>)result.ViewData.Model;
            // Assert
            Assert.IsNotNull(QuestionsList);
        }

        [TestMethod]
        public void QuestionsCount()
        {
            // Arrange
            HttpCallingService _httpCallingService = new HttpCallingService();
            IQuestionService _questionService = new QuestionService(_httpCallingService);
            QuestionsController controller = new QuestionsController(_questionService, _httpCallingService);
             

            // Act
            ViewResult result = controller.Index() as ViewResult;
            var QuestionsList = (List<Question>)result.ViewData.Model;
            // Assert
            Assert.AreEqual(50,QuestionsList.Count);
        }

    }
}
