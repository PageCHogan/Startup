using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Startup.Models
{
    public class TestDataModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public TestDataModel()
        {
            ID = 0;
            Name = "";
            Email = "";
        }
    }
}
