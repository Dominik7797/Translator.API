using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Translator.API.Auth;
using Translator.API.Services;
using Translator.SharedLibary;

namespace Translator.API.Controllers
{
    public class TranslatorController : Controller
    {
        private readonly ILogger<TranslatorController> _logger;
        private readonly IConfiguration _configuration;

        public TranslatorController(ILogger<TranslatorController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet("/translate/{language}/{sentence}")]
        public async Task<string> Translate(Language language, string sentence) => 
            JsonConvert.SerializeObject(new TranslationService(_configuration["ConnectionString"]).TranslateSenctence(new TranslationRequest { Language = language, Sentence= sentence.ToLower()}));

        [ApiKey]
        [HttpGet("/Healthcheck")]
        public ActionResult<string> Hearthbeat() =>
            Ok();

    };
}