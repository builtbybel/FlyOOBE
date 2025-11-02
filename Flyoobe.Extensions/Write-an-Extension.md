# 🆕 Setup Extensions: Host + Options Support

The Setup Extensions system lets you drop PowerShell scripts into .\scripts\ and have them show up automatically in the Setup Extensions page. Scripts declare behavior via simple header metadata.

**This doc explains:**
- Which metadata keys are supported
- How options & inputs are passed to your script
- Host modes (embedded/console/log) and per-option overrides
- Categories (Pre/Mid/Post) and filtering

---
# ✅ Supported Script Metadata (header comments)

Add these at the top of your .ps1:

# Description: <string>
Short, user-friendly description shown under the title.

**Category**
`# Category: Pre | Mid | Post | All | Tool`
- Used to filter views like Pre-Setup, Post-Setup, etc.
- Omit or use All to show in every category.

**Host**
`# Host: embedded | console | log` (default: embedded)
- `embedded`: runs inside the app; stdout/stderr is captured and shown in UI
- `console`: launches external PowerShell with -NoExit
- `log`: runs embedded and streams to the app’s Live Log window
  
**Options** - `# Options: value1; value2; value3; ... `(optional)
- Adds a dropdown to pick an action.
- The selected value is passed to the script as the first positional argument ($Option or $args[0]).

**Per-option host override suffixes (optional):**
- `"Action (console)"` → force external console
- `"Action (silent)"` → force embedded without log
- `"Action (log)"` → force embedded with live log
(The suffix is removed before passing the option text to the script.)
`# Input: true | false` (optional)
- Shows a text box below the options if true.
- The entered text is passed as the second positional argument `($ArgsText or $args[1])`.
`# InputPlaceholder:` <string> (optional, requires # Input: true)
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

## 🗂️ Categories (views)

- Category: Pre → visible in Pre-Setup view
- Category: Mid → visible in Setup view
- Category: Post → visible in Post-Setup / Extensions view
- Category: All/Tool → visible in all views (Extensions)

## 🔎 Discovery & Display

Scripts are loaded from `.\scripts\ (subfolders allowed).
- `*.ps1` files are parsed for the first ~15 header lines to read the metadata.
- Icon is picked heuristically from the filename (e.g., “update”, “debloat”, “network”).
- The Options dropdown appears only if `# Options:`  exists.
- The Input textbox appears only if `# Input: true` .


