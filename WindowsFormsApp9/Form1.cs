using System;
using System.Drawing;
using System.Windows.Forms;

namespace WhatsAppClonePro
{
    public class MainForm : Form
    {
        private ListBox chatList;
        private Panel chatPanel;
        private TextBox messageBox;
        private Button sendButton;

        public MainForm()
        {
            // إعداد الفورم
            this.Text = "WhatsApp Clone";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            // قائمة الدردشات
            chatList = new ListBox();
            chatList.Location = new Point(10, 10);
            chatList.Size = new Size(200, 540);
            chatList.BackColor = Color.FromArgb(230, 230, 230);
            chatList.Font = new Font("Arial", 12, FontStyle.Bold);
            chatList.Items.AddRange(new string[] { "أحمد", "سارة", "محمد" });
            chatList.SelectedIndexChanged += ChatList_SelectedIndexChanged;
            this.Controls.Add(chatList);

            // لوحة عرض الدردشة
            chatPanel = new Panel();
            chatPanel.Location = new Point(220, 10);
            chatPanel.Size = new Size(650, 500);
            chatPanel.AutoScroll = true;
            chatPanel.BackColor = Color.White;
            this.Controls.Add(chatPanel);

            // صندوق الرسائل
            messageBox = new TextBox();
            messageBox.Location = new Point(220, 520);
            messageBox.Size = new Size(540, 30);
            messageBox.Font = new Font("Arial", 12);
            this.Controls.Add(messageBox);

            // زر الإرسال
            sendButton = new Button();
            sendButton.Text = "إرسال";
            sendButton.Location = new Point(770, 520);
            sendButton.Size = new Size(100, 30);
            sendButton.BackColor = Color.FromArgb(37, 211, 102); // لون واتساب الأخضر
            sendButton.ForeColor = Color.White;
            sendButton.Font = new Font("Arial", 12, FontStyle.Bold);
            sendButton.Click += SendButton_Click;
            this.Controls.Add(sendButton);
        }

        private void ChatList_SelectedIndexChanged(object sender, EventArgs e)
        {
            chatPanel.Controls.Clear(); // مسح الرسائل عند تغيير المحادثة
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(messageBox.Text))
            {
                AddMessage(messageBox.Text, true);
                messageBox.Clear();

                // مثال رسالة رد تلقائي
                AddMessage("تم استلام رسالتك!", false);
            }
        }

        private void AddMessage(string text, bool isSender)
        {
            Label messageLabel = new Label();
            messageLabel.AutoSize = true;
            messageLabel.MaximumSize = new Size(400, 0);
            messageLabel.Text = text;
            messageLabel.Font = new Font("Arial", 12);
            messageLabel.Padding = new Padding(10);
            messageLabel.Margin = new Padding(5);

            if (isSender)
            {
                messageLabel.BackColor = Color.FromArgb(37, 211, 102); // أخضر واتساب
                messageLabel.ForeColor = Color.White;
                messageLabel.TextAlign = ContentAlignment.MiddleRight;
                messageLabel.Location = new Point(chatPanel.Width - messageLabel.PreferredWidth - 20, chatPanel.Controls.Count * 50);
            }
            else
            {
                messageLabel.BackColor = Color.FromArgb(240, 240, 240); // رسائل المستقبل باللون الرمادي
                messageLabel.ForeColor = Color.Black;
                messageLabel.TextAlign = ContentAlignment.MiddleLeft;
                messageLabel.Location = new Point(10, chatPanel.Controls.Count * 50);
            }

            chatPanel.Controls.Add(messageLabel);
            chatPanel.ScrollControlIntoView(messageLabel);
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new MainForm());
        }
    }
}