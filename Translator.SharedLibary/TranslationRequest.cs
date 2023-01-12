using Translator.API;

namespace Translator.SharedLibary
{
    public class TranslationRequest
    {
        public string? Sentence { get; set; }
        public Language Language { get; set; }
    }

    public enum Language
    {
        English,
        Hungarian,
        Spanish,
        Chinese,
        Portuguese
    }
}