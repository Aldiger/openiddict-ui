using System.Collections.Generic;

namespace OpenIddict.UI.Identity.Core;

public class ClaimInfo
{
  public string Type { get; set; }
  public string Value { get; set; }
}

public class UserInfo
{
  public string Id { get; set; }

  public string UserName { get; set; }

  public string Email { get; set; }

  public bool LockoutEnabled { get; set; }

  public bool IsLockedOut { get; set; }

  public List<ClaimInfo> Claims { get; set; } = new List<ClaimInfo>();

  public List<string> Roles { get; set; } = new List<string>();
}
