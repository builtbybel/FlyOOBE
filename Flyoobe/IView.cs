/// <summary>
/// Represents a UI view that can refresh its displayed content.
/// Every view hosted by the navigator implements this.
/// </summary>
public interface IView
{
    /// <summary>
    /// Refreshes the view. Used when the user clicks refresh or returns to the page.
    /// </summary>
    void RefreshView();
}

/// <summary>
/// Implement this on views that support global search filtering.
/// The MainForm calls this whenever the global search text changes.
/// </summary>
public interface IHasSearch
{
    /// <summary>
    /// Called whenever the user types into the global search box.
    /// The view should filter or highlight content based on the given text.
    /// </summary>
    /// <param name="text">The search query string (may be empty).</param>
    void OnGlobalSearchChanged(string text);
}
