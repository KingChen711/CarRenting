using Microsoft.AspNetCore.Identity;

namespace CarRenting.Models.Entities
{
    public class User : IdentityUser<int>
    {
        public Guid UserId { get; set; }

        //navigator
        public ICollection<Contract> Contracts { get; set; } = new List<Contract>(); //Lưu ý: Chỉ có role customer mới có Contracts
    }
}
