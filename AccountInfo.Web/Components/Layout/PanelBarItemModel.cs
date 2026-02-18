// File: AccountInfo.Web/Models/PanelBarItemModel.cs
// Helper model for the PanelBar hierarchical data in AccountPageLayout

namespace AccountInfo.Web.Components.Layout;

/// <summary>
/// Represents a node in the PanelBar tree.
/// Level 1: Location name
/// Level 2: "Internet" or "Phone" category
/// Level 3: Individual account (provider name)
/// </summary>
public class PanelBarItemModel
{
    public string Id { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// "internet" or "phone" — set on level 3 (account) items to identify the type when selected.
    /// </summary>
    public string? AccountType { get; set; }

    /// <summary>
    /// The actual account ID (InternetAccountDto.Id or PhoneAccountDto.Id) — set on level 3 items.
    /// </summary>
    public int? AccountId { get; set; }

    /// <summary>
    /// The LocationId this item belongs to — set on all levels for context.
    /// </summary>
    public int LocationId { get; set; }

    public List<PanelBarItemModel> Items { get; set; } = new();

    public bool HasChildren => Items.Count > 0;
}
