using System.Drawing;

namespace Flyoobe.ToolHub
{
    public partial class PostToolHubControlView : ToolHubControlView
    {
        // lets override title shown in navheader
        public override string ViewTitle => "Post-Setup Extensions";

        // this constructor automatically loads only scripts with # Category: Post
        public PostToolHubControlView() : base(ToolHubCategory.Post)
        {
            BackColor = Color.FromArgb(243, 242, 230);
          //  ForeColor = Color.Gainsboro;
           // Font = new Font("Consolas", 9.5f, FontStyle.Regular);
        }
    }
}