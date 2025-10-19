/// <summary>
/// Represents a view that can be refreshed and provides a display title.
/// </summary>
public interface IView
{
    /// <summary>
    /// Refreshes the view to update its display or data.
    /// </summary>
    void RefreshView();

    /// <summary>
    /// Gets the title of the view for display in the UI.
    /// </summary>
    string ViewTitle { get; }

}
