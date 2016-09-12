using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeoplePets.Entities
{    
    public class Pet : IResource
    {
        public string name { get; set; }
        public string type { get; set; }
    }
}