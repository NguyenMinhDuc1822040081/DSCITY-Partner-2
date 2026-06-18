namespace DSCITYPartner.Client.Services;

/// <summary>
/// In-memory account store for the partner portal. Mirrors the Admin
/// <c>AccountDirectory</c>: validate credentials and register new accounts.
/// Seeded with the demo account 0123456789 / 123456.
/// </summary>
public sealed class AccountDirectory
{
    private readonly List<PortalUser> _users =
    [
        new()
        {
            FullName = "Trần Minh Quân",
            Phone = "0123456789",
            Password = "123456",
            Role = "Quản trị viên đối tác"
        }
    ];

    public bool ValidateCredentials(string phone, string password, out PortalUser? user)
    {
        user = _users.FirstOrDefault(x => x.Phone == phone && x.Password == password);
        return user is not null;
    }

    public bool Register(string fullName, string phone, string password, out string? error)
    {
        if (_users.Any(x => x.Phone == phone))
        {
            error = "Số điện thoại đã tồn tại.";
            return false;
        }

        _users.Add(new PortalUser
        {
            FullName = fullName,
            Phone = phone,
            Password = password,
            Role = "Quản trị viên đối tác"
        });

        error = null;
        return true;
    }
}

/// <summary>
/// Tracks the current partner session. Mirrors the Admin <c>AuthSession</c>:
/// raises <see cref="OnChange"/> so components can re-render on sign in/out.
/// </summary>
public sealed class PartnerAuthService
{
    public event Action? OnChange;

    public PortalUser? CurrentUser { get; private set; }

    public bool IsAuthenticated => CurrentUser is not null;

    public void SignIn(PortalUser user)
    {
        CurrentUser = user;
        OnChange?.Invoke();
    }

    public void SignOut()
    {
        CurrentUser = null;
        OnChange?.Invoke();
    }
}

public sealed class PortalUser
{
    public string FullName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}
