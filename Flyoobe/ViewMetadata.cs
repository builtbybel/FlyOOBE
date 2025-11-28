using System;
using System.Collections.Generic;

namespace Flyoobe
{
    /// <summary>
    /// Provides metadata (titles, subtitles, and search tags) for all views.
    /// Used by the Home dashboard and navigation UI without loading each view.
    /// </summary>
    public static class ViewMetadata
    {
        /// <summary>
        /// Maps each view name to a set of search keywords.
        /// Used by the Home dashboard search to find matching tiles.
        /// </summary>
        public static readonly Dictionary<string, string> SearchTags =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
            { "Device", "device name computer" },
            { "Personalization", "theme wallpaper colors transparency taskbar" },
            { "Browser", "edge chrome firefox default browser web" },
            { "AI", "ai privacy recall copilot telemetry" },
            { "Network", "wifi lan ethernet hotspot" },
            { "Account", "local microsoft login password offline" },
            { "Apps", "debloat remove apps store cleanup bloatware" },
            { "Experience", "setup privacy tuning tweak" },
            { "Installer", "install apps packages winget" },
            { "Updates", "windows update patches wu offline" },
            { "Advanced", "clean install repair boot bios rufus ventoy" },
            { "Extensions", "tools hub addons tweaks ninite winget" },
            { "Flyby11", "upgrade migrate windows 11 flyby esu 10" },
            { "Windows 11 25H2 Enablement Package", "enable feature pack 25h2 new features" }
            };

        /// <summary>
        /// Maps each view name to its display title and subtitle.
        /// Used in headers, navigation, and the Home dashboard.
        /// </summary>
        public static readonly Dictionary<string, (string Title, string Subtitle)> Pages =
            new Dictionary<string, (string, string)>(StringComparer.OrdinalIgnoreCase)
            {
                { "Device", ("Device Prep", "Customize your device name, user name, and system language during Windows setup") },
                { "Personalization", ("Personalize Device", "Customize themes, wallpaper, and taskbar settings") },
                { "Browser", ("Default Browser", "Choose and install your preferred web browser") },
                { "AI", ("AI Experiences", "Manage AI-related features and settings") },
                { "Network", ("Network", "Manage your network connections during Windows setup") },
                { "Account", ("Account", "Manage local and online accounts") },
                { "Apps", ("Apps && Bloatware", "Uninstall unwanted apps and bloatware. #Dumputer #Debloater") },
                { "Experience", ("Optimize Experience Settings", "Customize recommended settings for your device during Windows setup #Privacy #CoTweaker #CrapFixer") },
                { "Installer", ("App Installer", "Easily install commonly used applications via Winget") },
                { "Updates", ("Windows Updates", "Patch && enable features") },
                { "Advanced", ("Custom Install && Repair", "Boot, recovery && power tools") },
                { "Settings", ("App-Settings", "") },
                { "Extensions", ("Explore Extensions", "") },
            };

        /// <summary>
        /// Optional user count badges for tiles (e.g., "1M+ users").
        /// </summary>
        public static readonly Dictionary<string, string> UserCounts =
          new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
          {
        { "Flyby11", "1M+ users" },
        { "Windows 11 25H2 Enablement Package", "100k+ users" }
          };

    }
}