using System;
using System.Windows.Forms;

namespace ErrorProviderTest
{
    /// <summary>
    /// バインドなし
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "必須入力です。");
            }
            if (textBox1.Text.Length > 5)
            {
                errorProvider1.SetError(textBox1, "桁数オーバーです。");
            }
            int x;
            if (int.TryParse(textBox3.Text, out x) == false)
            {
                errorProvider1.SetError(textBox3, "数値項目です。");
            }
            foreach (Control ctl in Controls)
            {
                if (string.IsNullOrEmpty(errorProvider1.GetError(ctl)) == false)
                {
                    MessageBox.Show("エラーあり！");
                    return;
                }
            }
            MessageBox.Show("登録できました。");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
