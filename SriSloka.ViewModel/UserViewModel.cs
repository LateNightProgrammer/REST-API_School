﻿using Newtonsoft.Json;

namespace SriSloka.ViewModel
{
  [JsonObject(MemberSerialization.OptOut)]
  public class UserViewModel
  {
    #region Constructor
    public UserViewModel()
    {

    }
    #endregion

    #region Properties
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string DisplayName { get; set; }
    #endregion
  }
}
