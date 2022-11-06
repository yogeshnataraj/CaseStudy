using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudy.Api.ApiModles
{
    public class RegisterDTO
    {
        internal string LastName;

        public string FirstName { get; internal set; }
        public string Email { get; internal set; }
        public string Password { get; internal set; }
    }
}