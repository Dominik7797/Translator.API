using Microsoft.EntityFrameworkCore;

namespace Translator.API.DB
{
    public class DbHandler
    {
        private string _connectionString { get; set; }
        public DbHandler(string connectionString)
        {
            _connectionString = connectionString;
        }

        public TranslatorContext TranslatorContext => new(new DbContextOptionsBuilder<TranslatorContext>().UseSqlServer(_connectionString).Options, _connectionString);
    }
}
