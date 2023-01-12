using Translator.API.DB;
using Translator.SharedLibary;

namespace Translator.API.Services
{
    public class TranslationService
    {
        private readonly string _connectionString;

        public TranslationService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string TranslateSenctence(TranslationRequest request)
        {
            var db = new DbHandler(_connectionString);
            var queryResult = db.TranslatorContext.Translations.FirstOrDefault(t => t.English.ToLower() == request.Sentence || t.Hungarian.ToLower() == request.Sentence ||
                t.Spanish.ToLower() == request.Sentence || t.Chinese.ToLower() == request.Sentence || t.Portuguese.ToLower() == request.Sentence);
            if (queryResult == null || IsObjectEmpty(queryResult))
                return string.Empty;

            if (request.Language == Language.English)
                return queryResult.English;
            if (request.Language == Language.Hungarian)
                return queryResult.Hungarian;
            if (request.Language == Language.Spanish)
                return queryResult.Spanish;
            if (request.Language == Language.Portuguese)
                return queryResult.Portuguese;
            if (request.Language == Language.Chinese)
                return queryResult.Chinese;

            return string.Empty;
        }

        private static bool IsObjectEmpty(object obj) =>
            obj.GetType().GetProperties()
                .Where(pi => pi.PropertyType == typeof(string))
                .Select(pi => (string)pi.GetValue(obj))
                .Any(value => string.IsNullOrEmpty(value));
    }
}
