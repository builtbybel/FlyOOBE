using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Flyoobe
{
    public static class DonationHelper
    {
        // Path to the donation status file
        private static readonly string filePath = Path.Combine("app", "FlyOOBE.txt");

        // Donation flag to be inserted/read from the file
        private const string donationFlag = "#donated=true";

        /// <summary>
        /// Checks if the user has already donated.
        /// Returns true if the donation flag is found in the file.
        /// </summary>
        public static bool HasDonated()
        {
            if (!File.Exists(filePath))
                return false;

            var lines = File.ReadAllLines(filePath);
            return lines.Any(line => line.Trim().Equals(donationFlag));
        }

        /// <summary>
        /// Updates the donation status by writing or removing the flag in the file.
        /// Ensures the "app" directory exists before writing.
        /// </summary>
        /// <param name="donated">True if the user has donated; false otherwise.</param>
        public static void SetDonationStatus(bool donated)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, donated ? donationFlag : string.Empty);
                return;
            }

            var lines = File.ReadAllLines(filePath).ToList();

            // Remove any existing donation flags
            lines.RemoveAll(l => l.Trim().StartsWith("#donated"));

            if (donated)
                lines.Add(donationFlag);

            File.WriteAllLines(filePath, lines);
        }

        /// <summary>
        /// Displays a donation prompt message box.
        /// Opens the PayPal donation page if the user agrees.
        /// </summary>
        public static void ShowDonationPrompt()
        {
            string message = "Thank you for using my app!\n\n" +
           "I developed this application in my free time to help you upgrade from Windows 10 to Windows 11 – even on PCs that, according to Microsoft's hardware requirements, would normally not be supported.\n\n" +
           "My app helps you avoid purchasing a new computer and actively contributes to reducing unnecessary electronic waste.\n\n" +
           "Normally, I do not charge anything for my projects – neither for development nor for support.\n" +
           "Since this app is significantly more comprehensive, offers more features, and requires ongoing maintenance, I would be grateful for any voluntary contribution to support my work – but everything remains free and available to everyone, regardless.\n\n" +
           "Of course, only if you want to and can afford it.\n\n" +
           "Would you like to donate via PayPal now?";


            var result = MessageBox.Show(message, "Support @Belim", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://www.paypal.com/donate?hosted_button_id=MY7HX4QLYR4KG",
                    UseShellExecute = true
                });
            }
        }
    }
}
