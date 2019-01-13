using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SriSloka.ViewModel
{
  [JsonObject(MemberSerialization.OptOut)]
  public class TokenResponseViewModel
  {
    #region Constructor
    public TokenResponseViewModel()
    {

    }
    #endregion

    #region Properties
    public string token { get; set; }
    public int expiration { get; set; }
    public string refresh_token { get; set; }
    #endregion
  }
}
