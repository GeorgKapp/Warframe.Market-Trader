using Warframe.Market_DomainModels.Enums;

namespace Warframe.Market_DomainModels.Models
{
    public class LoginUser
    {
        public string CheckCode { get; set; }
        public bool? Banned { get; set; }
        public bool? Anonymous { get; set; }
        public bool? HasMail { get; set; }
        public bool? Verification { get; set; }
        public byte? UnreadMessages { get; set; }
        public byte? WrittenReviews { get; set; }
        public LinkedAccounts LinkedAccounts { get; set; }
        public Platform? Platform { get; set; }
        public Role? Role { get; set; }
        public  User User { get; set; }
    }
}
