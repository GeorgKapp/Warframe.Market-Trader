using System.ComponentModel.DataAnnotations.Schema;

namespace Warframe.Market_Infrastructure.Models.Enums
{
    [Table(nameof(Language))]
    public class Language
    {
        public LanguageEnum Id { get; set; }
        public string Text { get; set; }
    }
}
