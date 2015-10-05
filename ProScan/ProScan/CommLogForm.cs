using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProScan
{
	public class CommLogForm : Form
	{
		private RichTextBox richTextBox;

		public CommLogForm()
		{
			InitializeComponent();
		}

		public new void Update()
		{
			if (!File.Exists("commlog.txt"))
				return;
			FileStream fileStream = new FileStream("commlog.txt", FileMode.Open, FileAccess.Read);
			richTextBox.LoadFile((Stream)fileStream, RichTextBoxStreamType.PlainText);
			fileStream.Close();
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			richTextBox = new System.Windows.Forms.RichTextBox();
			SuspendLayout();
			// 
			// richTextBox
			// 
			richTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			richTextBox.Location = new System.Drawing.Point(0, 0);
			richTextBox.Name = "richTextBox";
			richTextBox.ReadOnly = true;
			richTextBox.Size = new System.Drawing.Size(668, 482);
			richTextBox.TabIndex = 0;
			richTextBox.Text = "";
			// 
			// CommLogForm
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(672, 486);
			Controls.Add(richTextBox);
			Name = "CommLogForm";
			Text = "Communication Log";
			ResumeLayout(false);

		}
	}
}