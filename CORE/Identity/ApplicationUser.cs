using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Identity
{
    //Kullanıcı sınıfı
    public class ApplicationUser: IdentityUser  //Microsoft.AspNetCore.Identity.EntityFramework
    {       
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
