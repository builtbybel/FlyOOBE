using System;
using System.Drawing;
using System.Windows.Forms;

namespace Flyoobe
{
    public partial class HomeItemControl : UserControl
    {
        public event Action Clicked;

        public string ItemTitle
        {
            get => lblTitle.Text;
            set => lblTitle.Text = value;
        }

        public string ItemDescription
        {
            get => lblSubTitle.Text;
            set => lblSubTitle.Text = value;
        }

        public Image ItemIcon
        {
            get => picIcon.Image;
            set => picIcon.Image = value;
        }
        public string UserCount
        {
            get => lblUserCount.Text;
            set
            {
                lblUserCount.Text = value;
                lblUserCount.Visible = !string.IsNullOrEmpty(value);
            }
        }


        /// <summary>
        /// Hidden searchable keywords (not displayed).
        /// Example: "debloat;cleanup;apps;remove bloatware"
        /// </summary>
        /// 
        public string SearchTags { get; set; } = "";

        public HomeItemControl()
        {
            InitializeComponent();
            btnOpen.Click += (s, e) => Clicked?.Invoke();
        }
    }
}
