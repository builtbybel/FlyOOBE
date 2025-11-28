# 🐝 FlyOOBE (ex-Flyby11) – Windows Setup Assistant

<img width="1536" height="1024" alt="IllustrationBranding-Visual-FlyOOBE" src="https://github.com/user-attachments/assets/02dff63c-d830-4e08-bdd8-b13ad70f6683" />


---

## 📢 Quick Note for Returning Users
**FlyOOBE is the natural evolution of Flyby11.**  
The classic Flyby11 upgrader still exists and is included inside FlyOOBE,  
plus it's also available as a **separate download** if you only want the minimal upgrade tool.

You can now **choose**:

| Version | Purpose | Features | Download |
|---------|---------|----------|----------|
| **FlyOOBE** (New) | Upgrade + OOBE Toolkit | • Windows 10 → 11 upgrades<br>• OOBE customization<br>• Tweaks & Debloat<br>• Scriptable setup extensions | [⬇ Download FlyOOBE](https://github.com/builtbybel/FlyOOBE/releases/latest) |
| **Flyby11** (Classic) | Upgrade Only | • Win10 → Win11 Inplace upgrade<br>• Hardware check bypass<br>• Minimal footprint | [⬇ Download Flyby11 Classic](https://github.com/builtbybel/FlyOOBE/releases/latest) |
---

## 🐝 Why FlyOOBE?
Originally, **Flyby11** was a simple patcher to remove the restrictions stopping you from installing Windows 11 (24H2) on unsupported hardware.  
Old PC? No TPM, no Secure Boot, unsupported CPU? Flyby11 let you install Windows 11 anyway.

After helping thousands upgrade, one thing became clear:  
**Bypassing checks is only half the battle.**  
We needed a **full setup solution** — one that respects user choices instead of Microsoft's defaults.

**FlyOOBE** was the next step:  
- Skip the fluff  
- Remove the junk  
- Take full control from first boot  

Because your PC should work for you, not the other way around.  
FlyOOBE keeps the original idea alive and pushes it even further.

---

No complicated steps.  
**Just run the tool** (see ["Releases"](https://github.com/builtbybel/FlyOOBE/releases/latest)),  
unpack if needed, and you'll be running Windows 11 on your “unsupported” machine in no time.  
Think of it as sneaking through the back door without anyone noticing.

---

## 🛠 Technical Overview
**FlyOOBE method:**
- Uses Windows Server variant of setup → skips TPM, Secure Boot, CPU checks
- Still installs **normal Windows 11**
- ISO download/mount handled automatically (via [Fido script](https://github.com/pbatard/Fido))
- Matches Microsoft’s own documented workaround for upgrading unsupported devices ([source](https://support.microsoft.com/en-us/windows/ways-to-install-windows-11-e0edbbfb-cfc5-4011-868b-2ce77ac7c70e))

---

## 💡 Why Keep FlyOOBE Alive?
- **Upgrade freedom** – Don’t ditch a perfectly fine PC just because Microsoft says so  
- **Eco-friendly** – Less e-waste from forced upgrades  
- **Save money** – No need for new hardware if yours still works

---

## ⚠ Disclaimer
Flyby11/FlyOOBE uses known, currently working methods to bypass Windows 11 24H2 restrictions.  
**POPCNT requirement** cannot be bypassed — needed for Win11 24H2.  
Introduced a compatibility checker in v2.3 to warn if unsupported.

---

## 📚 FAQ

<details>
<summary>❓ Will my unsupported device still get Windows 11 updates?</summary>

**Short answer:** Yes — for now. But there are no guarantees.

Microsoft says: _"These devices aren't guaranteed to receive updates."_  
📄 [Source – Microsoft Support](https://support.microsoft.com/en-us/windows/windows-11-on-devices-that-don-t-meet-minimum-system-requirements-0b2dc4a2-5933-4ad4-9c09-ef0a331518f1)

Reality: Most still get monthly security updates, but:
- Likely no automatic major version upgrades
- Future updates may fail if new hardware features are required
- Microsoft could block updates anytime

Bottom line: Works today — but unsupported means you accept the risk. 😎

</details>

---

## ❤️ Support Development
If Flyby11 or FlyOOBE has helped you, consider supporting its continued development.  
Every bit helps keep the project alive and improving. 🙏💌☕

👉 [**Donate here**](https://www.paypal.com/donate?hosted_button_id=MY7HX4QLYR4KG)
