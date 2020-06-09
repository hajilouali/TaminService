using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Exceptions;
using Data.Repositories;
using Entities.SitePropertys;
using Microsoft.AspNetCore.Mvc;
using TaminWeb.Models;

namespace TaminWeb.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IRepository<SUserQuestions> SUserQuestions;

        public QuestionController(IRepository<SUserQuestions> sUserQuestions)
        {
            SUserQuestions = sUserQuestions;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public  async Task<IActionResult> Create(UserFormGuestionViewModels model,CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var entity = model.ToEntity();
                if (entity!=null)
                {
                    await SUserQuestions.AddAsync(entity, cancellationToken);

                    return  Ok(true);
                }
                return Ok(false);
            }
            return Ok(false);

        }
    }
}