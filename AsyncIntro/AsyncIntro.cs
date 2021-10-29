using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncIntro
{
    public partial class AsyncIntro : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly Label label;
        private readonly Button button;

        public AsyncIntro()
        {
            label = new Label
            {
                Location = new Point(10, 20),
                Text = "Length"
            };

            button = new Button
            {
                Location = new Point(10, 50),
                Text = "Click"
            };

            button.Click += DisplayWebSiteLength;
            AutoSize = true;
            Controls.Add(label);
            Controls.Add(button);
        }

        private async void DisplayWebSiteLength(object sender, EventArgs e)
        {
            label.Text = "Fetching...";
            Task<string> task = client.GetStringAsync("http://csharpindepth.com");
            string text = await task;
            label.Text = text.Length.ToString();
        }
    }
}