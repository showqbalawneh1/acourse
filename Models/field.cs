using System;
namespace Acourse.Models
{
    public class field
    {
        public int fieldId {get; set; }
        public string fname { get; set;  }
        public string description { get; set;  }
        public string Slug =>
           fname?.Replace(' ', '-').ToLower();
        public field()
        {
        }
    }
}
