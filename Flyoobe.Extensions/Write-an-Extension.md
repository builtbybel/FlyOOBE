# 🆕 Setup Extensions — Technical Guide (Host · Options · Input)

The Setup Extensions system lets you drop PowerShell scripts into 
`.\scripts\` and have them show up automatically in the Setup Extensions page. Scripts declare behavior via simple header metadata.

**This doc explains:**
- Which metadata keys are supported
- How options & inputs are passed to your script
- Host modes (embedded/console/log) and per-option overrides
- Categories (Pre/Mid/Post) and filtering

---
# ✅ Supported Script Metadata (header comments)

Add these at the top of your .ps1:

**Description**
`# Description: <string>`
- Short, user-friendly description shown under the title.

**Category**
`# Category: Pre | Mid | Post | All | Tool`
- Used to filter views like Pre-Setup, Post-Setup, etc.
- Omit or use All to show in every category.

**Host**
`# Host: embedded | console | log` (default: embedded)
- `embedded`: runs inside the app; stdout/stderr is captured and shown in UI
- `console`: launches external PowerShell with -NoExit
- `log`: runs embedded and streams to the app’s Live Log window
  
**Options** 
- `# Options: value1; value2; value3; ... `(optional)
- Adds a dropdown to pick an action.
- The selected value is passed to the script as the first positional argument ($Option or $args[0]).

**Per-option host override suffixes (optional):**
- `"Action (console)"` → force external console
- `"Action (silent)"` → force embedded without log
- `"Action (log)"` → force embedded with live log
(The suffix is removed before passing the option text to the script.)

**Textbox**
- `# Input: true | false` (optional)
- Shows a text box below the options if true.
- The entered text is passed as the second positional argument `($ArgsText or $args[1])`.
- `# InputPlaceholder:` <string> (optional, requires `# Input: true`)
- Visual placeholder shown in the input box (e.g., hints like Enter IDs…).

---
## 🎛️ How arguments are passed (important)
To keep maximum compatibility with new and legacy scripts:
- The app uses positional arguments when calling your script:

`powershell.exe -NoProfile -ExecutionPolicy Bypass -File "<script.ps1>" "<Option>" "<ArgsText>"`

- You can read them either as:
- `param([string]$Option, [string]$ArgsText)`
Position 0 → $Option, position 1 → $ArgsText
- or via `$args[0], $args[1]` in scripts without a param block.
- No named `-Option` / `-ArgsText` parameters are required. If you do define them, PowerShell binds the two values by position.

## 🪟 Host modes (how the script runs)
**- embedded (default):**
Runs headless, captures stdout/stderr, shows progress + status in the control.
`# Host: embedded` or no host specified.

**- console:**
Launches external powershell.exe with -NoExit so the user can interact.
`# Host: console` or select an option ending with (console).

**- log:**
Runs headless and opens a live log window that streams output in real-time.
`# Host: log` or select an option ending with (log).

**- silent** (per-option override only):
Use the suffix (silent) to run embedded without opening the live log, even if host default is log.

## 🧭 Extension Categories (ToolHub)

To keep large script collections organized, each extension can declare a **category** in its header
Each extension can declare a **category** to indicate *when* it should be used during the setup flow.

```powershell
# Category: Pre | Post | Mid | Tool | All


| Category                      | When It Runs / Fits                               | What It’s Typically Used For                 | Example Use-Cases                                                  |
|------------------------------|----------------------------------------------------|----------------------------------------------|--------------------------------------------------------------------|
| Pre (Setup Operating System) | Early in the setup process, before personalization | Preparing the system state                   | Debloating, enabling services, network configuration               |
| Mid (Configure Operating System) | During core system configuration               | Adjusting Windows behavior and defaults      | Feature toggles, performance tuning, registry adjustments          |
| Post (Enter Extensions)      | After Windows is installed and configured          | User-facing customization and finishing touches | Explorer/UI tweaks, theme/visual styles, privacy adjustments    |
| Tool (Utility Mode)          | Anytime — independent helper utilities             | External tools not tied to a setup phase     | Ninite installer, Winget multi-installer, Flyby11 Upgrade Helper   |
| All (Universal)              | Always visible in all categories                   | Scripts that can be run at any time          | Generic utilities, backup/restore actions?                         |


## 🔎 Discovery & Display

Scripts are loaded from `.\scripts\ (subfolders allowed).
- `*.ps1` files are parsed for the first ~15 header lines to read the metadata.
- Icon is picked heuristically from the filename (e.g., “update”, “debloat”, “network”).
- The Options dropdown appears only if `# Options:` exists.
- The Input textbox appears only if `# Input: true`.

# 🧪 Minimal examples

1) Simple script, no options, no input
```powershell
# Description: Clears temp files
# Category: Post
# Host: embedded

# No param() needed — runs with zero positional arguments
Write-Output "Cleaning temp..."
# your logic here
```

2) Script with options only

```powershell
# Description: File Explorer tweaks
# Category: Post
# Host: embedded
# Options: Show file extensions; Hide file extensions; Open This PC (console)

param([string]$Option)  # position 0

switch ($Option) {
  'Show file extensions' { Write-Output "Enabling extensions...";  # ... }
  'Hide file extensions' { Write-Output "Disabling extensions..."; # ... }
  'Open This PC'         { Start-Process "explorer.exe" "shell:MyComputerFolder" }
  default { Write-Error "Unknown option: $Option" }
}
```

3) Script with options and input

```powershell
# Description: Manage feature IDs via ViVeTool
# Category: Post
# Host: log
# Options: Enable IDs; Disable IDs; Query IDs; Open GitHub Releases
# Input: true
# InputPlaceholder: Enter comma-separated IDs (e.g., 123,456,789)

param([string]$Option, [string]$ArgsText)  # positions 0 and 1

function Parse-Ids($s) {
  if ([string]::IsNullOrWhiteSpace($s)) { return @() }
  $s.Split(',') | % { $_.Trim() } | ? { $_ -match '^\d+$' } | % { [int]$_ }
}

switch ($Option) {
  'Open GitHub Releases' { Start-Process 'https://github.com/thebookisclosed/ViVe/releases'; break }
  'Enable IDs' {
    $ids = Parse-Ids $ArgsText
    if ($ids.Count -eq 0) { throw "No valid IDs" }
    & "ViVeTool.exe" '/enable' ("/id:{0}" -f ($ids -join ','))
  }
  # ... Disable / Query similar
}
```

4) Script that uses $args (no param block)

```powershell
# Description: Winget bulk install
# Category: Post
# Host: log
# Options: Install packages
# Input: true
# InputPlaceholder: Enter package IDs separated by space/comma/newline

$option = $args.Count -ge 1 ? $args[0] : $null
$text   = $args.Count -ge 2 ? $args[1] : $null

if ($option -ne 'Install packages') { throw "Unknown option: $option" }

$ids = $text -split "[\r\n,; ]+" | ? { $_ } | % { $_.Trim() }
foreach ($id in $ids) {
  Write-Output "Installing: $id"
  winget install $id -e --accept-source-agreements --accept-package-agreements
}
```

# 🛡️ Execution & Logging Notes

- Scripts are launched with:
`powershell.exe -NoProfile -ExecutionPolicy Bypass -File "<script.ps1>" "<Option>" "<ArgsText>"`
- In embedded/log modes, stdout/stderr is captured to the control and optional Live Log window.
- In console mode, an external PowerShell window opens with -NoExit.
- The control shows status (`Running…, Done.`, etc.) and can display a progress bar while the script runs.

# 💡 Best Practices
- Keep **Descriptions** short and action-focused.
- Use **Options** to avoid shipping multiple near-identical scripts.
- Prefer `param([string]$Option,[string]$ArgsText)` for clarity; still compatible with positional calls.
- Validate input early and `Write-Error` on misuse to surface helpful feedback in the UI.
- For safety, avoid destructive defaults; require a clear **Option** selection.
