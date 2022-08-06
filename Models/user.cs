using System;
using System.ComponentModel.DataAnnotations;

namespace Acourse.Models
{
    public class user
    {
        [Key]
        public int userId { get; set; }
        public string uname { get; set; }
        public string password { get; set; }
        public string email { get; set;  }

    }
}
