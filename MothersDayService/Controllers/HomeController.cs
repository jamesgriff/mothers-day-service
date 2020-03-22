using System.Collections.Generic;
using System.Diagnostics;
using GovUkDesignSystem.Parsers;
using Microsoft.AspNetCore.Mvc;
using MothersDayService.Models;

namespace MothersDayService.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet("do-you-have-a-child")]
        public IActionResult DoYouHaveAChildQuestionGet()
        {
            var viewModel = new DoYouHaveAChildViewModel();

            return View("DoYouHaveAChild", viewModel);
        }

        [HttpPost("do-you-have-a-child")]
        public IActionResult DoYouHaveAChildQuestionPost(DoYouHaveAChildViewModel viewModel)
        {
            viewModel.ParseAndValidateParameters(Request, m => m.DoYouHaveAChild);

            if (viewModel.HasAnyErrors())
            {
                return View("DoYouHaveAChild", viewModel);
            }

            if (viewModel.DoYouHaveAChild == DoYouHaveAChild.No)
            {
                return View("ServiceNotForYou");
            }

            return RedirectToAction("HaveYouReceivedACardGet", "Home");
        }

        [HttpGet("have-you-received-a-card")]
        public IActionResult HaveYouReceivedACardGet()
        {
            var viewModel = new HaveYouReceivedACardViewModel();

            return View("HaveYouReceivedACard", viewModel);
        }

        [HttpPost("have-you-received-a-card")]
        public IActionResult HaveYouReceivedACardPost(HaveYouReceivedACardViewModel viewModel)
        {
            viewModel.ParseAndValidateParameters(Request, m => m.HaveYouReceivedACard);

            if (viewModel.HasAnyErrors())
            {
                return View("HaveYouReceivedACard", viewModel);
            }

            if (viewModel.HaveYouReceivedACard == HaveYouReceivedACard.CardReceived)
            {
                return View("ServiceNotForYou");
            }

            return RedirectToAction("YourNameGet", "Home");
        }

        [HttpGet("your-name")]
        public IActionResult YourNameGet()
        {
            var viewModel = new YourNameViewModel();

            return View("YourName", viewModel);
        }

        [HttpPost("your-name")]
        public IActionResult YourNamePost(YourNameViewModel viewModel)
        {
            viewModel.ParseAndValidateParameters(Request, m => m.YourFirstName);

            if (viewModel.HasAnyErrors())
            {
                return View("YourName", viewModel);
            }

            return RedirectToAction("ChildNameGet", "Home", new { yourname = viewModel.YourFirstName });
        }

        [HttpGet("child-name")]
        public IActionResult ChildNameGet(string yourname)
        {
            var viewModel = new ChildNameViewModel
            {
                YourFirstName = yourname
            };

            return View("ChildName", viewModel);
        }

        [HttpPost("child-name")]
        public IActionResult ChildNamePost(ChildNameViewModel viewModel)
        {
            viewModel.ParseAndValidateParameters(Request, m => m.ChildFirstName);

            if (viewModel.HasAnyErrors())
            {
                return View("ChildName", viewModel);
            }

            return RedirectToAction("GreetingsGet", "Home",
                new { yourname = viewModel.YourFirstName, childname = viewModel.ChildFirstName });
        }

        [HttpGet("greetings")]
        public IActionResult GreetingsGet(string yourname, string childname)
        {
            var viewModel = new GreetingsViewModel
            {
                YourFirstName = yourname,
                ChildFirstName = childname,
                Greetings = new List<Greetings>
                {
                    Greetings.BestMumInTheWorld,
                    Greetings.HaveARelaxingDay
                }
            };

            return View("Greetings", viewModel);
        }

        [HttpPost("greetings")]
        public IActionResult GreetingsPost(GreetingsViewModel viewModel)
        {
            viewModel.ParseAndValidateParameters(Request, m => m.Greetings);

            if (viewModel.HasAnyErrors())
            {
                return View("Greetings", viewModel);
            }

            return RedirectToAction("HappyMothersDayGet", "Home",
                new
                {
                    yourname = viewModel.YourFirstName,
                    childname = viewModel.ChildFirstName,
                    bestmum = viewModel.Greetings.Contains(Greetings.BestMumInTheWorld),
                    relaxingday = viewModel.Greetings.Contains(Greetings.HaveARelaxingDay)
                });
        }

        [HttpGet("happy-mothers-day")]
        public IActionResult HappyMothersDayGet(
            string yourname,
            string childname,
            bool? bestmum,
            bool? relaxingday)
        {
            var viewModel = new HappyMothersDayViewModel
            {
                YourFirstName = yourname,
                ChildFirstName = childname,
                BestMum = bestmum.HasValue && bestmum.Value,
                RelaxingDay = relaxingday.HasValue && relaxingday.Value
            };

            return View("HappyMothersDay", viewModel);
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
