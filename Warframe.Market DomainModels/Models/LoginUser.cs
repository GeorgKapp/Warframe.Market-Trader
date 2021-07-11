using Warframe.Market_DomainModels.Abstractions;
using Warframe.Market_DomainModels.Enums;

namespace Warframe.Market_DomainModels.Models
{
    public class LoginUser : ADomainModel
    {
        public LoginUser() { }
        public LoginUser(int id) : base(id) { }

        public string CheckCode { get; set; }
        public bool? Banned { get; set; }
        public bool? Anonymous { get; set; }
        public bool? HasMail { get; set; }
        public bool? Verification { get; set; }
        public byte? UnreadMessages { get; set; }
        public byte? WrittenReviews { get; set; }
        public LinkedAccounts LinkedAccounts { get; private set; }
        public Platform? Platform { get; set; }
        public Role? Role { get; set; }
        public  User User { get; private set; }
    }
}
