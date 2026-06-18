namespace DSCITYPartner.Client.Services;

/// <summary>
/// In-memory store of partner data for the DSCITY partner portal.
/// </summary>
public class PartnerPortalService
{
    private readonly List<string> _partners = new()
    {
        "Công ty TNHH ABC",
        "DSCITY Logistics",
        "Nhà phân phối Miền Nam",
        "Đối tác Bán lẻ Hà Nội",
        "Kho vận Đông Dương",
    };

    public IReadOnlyList<string> GetPartners() => _partners;

    public void AddPartner(string name)
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            _partners.Add(name.Trim());
        }
    }
}
