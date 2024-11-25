using Charge2Go.Data;
using Charge2Go.Models;
using Charge2Go.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MimeKit;
using System.Diagnostics;

namespace Charge2Go.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = new HomePageVM();

            viewModel.HomePageSlider = _context.SliderTop.ToList();
            viewModel.HomePageMiddle = _context.ImageMiddle.ToList();

            return View(viewModel);
        }

        public IActionResult Tarifarios()
        {
            var viewModel = new TariffVM();

            viewModel.TariffTop = _context.TariffTop.ToList();
            viewModel.TariffMiddle = _context.TariffMiddle.ToList();
            viewModel.TariffBottom = _context.TariffBottom.ToList();

            return View(viewModel);
        }

        public IActionResult Rede()
        {
            var viewModel = new RedeVM();

            viewModel.RedeChargingTop = _context.RedeChargingTop.ToList();
            viewModel.RedeChargingPoint = _context.RedeChargingPoints.ToList();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SubmitForm(ContactUsForm model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Create a new MimeMessage
                    var message = new MimeMessage();

                    // Set the From address
                    message.From.Add(new MailboxAddress("Your Name", "your-email@example.com"));

                    // Set the To address
                    message.To.Add(new MailboxAddress("Bernardo Crista", "bernardocrista64@gmail.com"));

                    // Set the Subject
                    message.Subject = "Contact Us Form Submission";

                    // Set the Body (you can use HTML for the email content if you prefer)
                    message.Body = new TextPart("plain")
                    {
                        Text = $"Nome: {model.Nome}\nEmail: {model.Email}\nTelefone: {model.Telefone}\nMensagem: {model.Mensagem}"
                    };

                    // Configure the mail server (you'll need to replace these values with your own mail server settings)
                    using var client = new SmtpClient();
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("bernardocrista64@gmail.com", "oqzs idaz etsj jwrf");

                    // Send the email
                    client.Send(message);

                    // Disconnect from the mail server
                    client.Disconnect(true);

                    // Save the form data to the database
                    _context.ContactUs.Add(model);
                    _context.SaveChanges();

                    // Redirect to the thank-you page
                    return RedirectToAction(nameof(Index));
                }

                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during email sending or database saving
                    // For simplicity, you can log the error and display a generic error message to the user
                    // You can use a logging framework like Serilog or NLog for logging
                    Console.WriteLine("Error sending email: " + ex.Message);
                    ModelState.AddModelError("", "An error occurred while processing your request. Please try again later.");
                    return RedirectToAction(nameof(Index));
                }

            }

            // If the form data is not valid, return the view with validation errors
            return RedirectToAction(nameof(Index)); ;
        }


        public IActionResult FAQs()
        {
            var viewModel = new FAQsVM();

            viewModel.FAQs = _context.FAQs.ToList();
            viewModel.FAQsQuestions = _context.FAQsQuestions.ToList();

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}