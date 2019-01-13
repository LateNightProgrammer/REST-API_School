using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace SriSloka.Model
{
    public class ApplicationUser:IdentityUser
    {
      public int StaffId { get; set; }

      public DateTime CreatedDate { get; set; }

      public DateTime LastModifiedDate { get; set; }

      public virtual Staff Staff { get; set; }

      /// <summary>
      /// A list of all the refresh tokens issued for this users.
      /// </summary>
      public virtual List<Token> Tokens { get; set; }
  }
}
