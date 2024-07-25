using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; } = null!;
        public string CompanyLocation { get; set; } = null!;
        public string CompanyEmail { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        //public ICollection<Post> Posts { get; set; } = null!;
    }
}
