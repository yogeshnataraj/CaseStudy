using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudy.Api.ApiModles
{
    public class RegisterDTO
    {
        public string LastName { get; internal set; }
        public string FirstName { get; internal set; }
        public string Email { get; internal set; }
        public string Password { get; internal set; }
    }
}