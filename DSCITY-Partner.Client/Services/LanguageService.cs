namespace DSCITYPartner.Client.Services;

/// <summary>
/// Bilingual (Vietnamese / English) text service for the partner portal.
/// Mirrors the DSCITY Admin LanguageService: inject as <c>Loc</c>, use
/// <see cref="Text"/> for inline strings and <see cref="Translate"/> for dynamic data.
/// </summary>
public sealed class LanguageService
{
    private bool _isEnglish;

    public bool IsEnglish => _isEnglish;
    public string CurrentCode => _isEnglish ? "EN" : "VI";
    public event Action? OnChange;

    public void SetEnglish(bool value)
    {
        if (_isEnglish == value)
        {
            return;
        }

        _isEnglish = value;
        OnChange?.Invoke();
    }

    public string Text(string vietnamese, string english) => _isEnglish ? english : vietnamese;

    public string Translate(string value)
    {
        if (!_isEnglish || string.IsNullOrWhiteSpace(value))
        {
            return value;
        }

        return value switch
        {
            "Đã duyệt" => "Approved",
            "Chờ duyệt" => "Pending",
            "Đã nhận" => "Received",
            "Từ chối" => "Rejected",
            "Hoạt động" => "Active",
            "Tạm dừng" => "Paused",
            "Quản trị viên đối tác" => "Partner Admin",
            "Quản trị viên cấp cao" => "Super Admin",
            "Khách (chưa đăng nhập)" => "Guest (not signed in)",
            _ => value
        };
    }
}
