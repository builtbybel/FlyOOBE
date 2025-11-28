using Microsoft.Win32;
using System;
using System.Security.Principal;

namespace Flyoobe
{
    internal static class Utils
    {
        private const string GitHubUrl = "https://github.com/builtbybel/Flyoobe";

        /// <summary>
        /// Checks if a registry value equals a specified integer.
        /// </summary>
        public static bool IntEquals(string keyName, string valueName, int expectedValue)
        {
            try
            {
                object value = Registry.GetValue(keyName, valueName, null);
                return value is int intValue && intValue == expectedValue;
            }
            catch (Exception ex)
            {
                Logger.Log($"Registry check failed for {keyName}\\{valueName}: {ex.Message}", LogLevel.Error);
                return false;
            }
        }

        /// <summary>
        /// Checks if a registry value equals a specified string.
        /// </summary>
        public static bool StringEquals(string keyName, string valueName, string expectedValue)
        {
            try
            {
                object value = Registry.GetValue(keyName, valueName, null);
                return value is string strValue && strValue == expectedValue;
            }
            catch (Exception ex)
            {
                Logger.Log($"Registry check failed for {keyName}\\{valueName}: {ex.Message}", LogLevel.Error);
                return false;
            }
        }

        /// <summary>
        /// Checks if the application is running with administrative privileges.
        /// </summary>
        /// <returns></returns>
        public static bool IsRunningAsAdmin()
        {
            using (var identity = WindowsIdentity.GetCurrent())
            {
                var principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }

        /// <summary>
        /// Detects if the current OS is Windows 11 or newer.
        /// </summary>
        public static bool DetectWindows11()
        {
            object buildObj = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuildNumber", null);
            if (buildObj != null && int.TryParse(buildObj.ToString(), out int build))
            {
                return build >= 22000; // Windows 11 starts at build 22000
            }
            return false; // If unable to detect, assume not Windows 11
        }
    }
}