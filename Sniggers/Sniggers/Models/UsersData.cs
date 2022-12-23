using System.ComponentModel.DataAnnotations;
namespace Sniggers.Models
{
    public class UsersData
    {
        public int ID { get; set; }
        public string CardNumber { get; set; } = string.Empty;
        public string MMYY { get; set; } = string.Empty;
        public int CVC { get; set; }
    }
}
