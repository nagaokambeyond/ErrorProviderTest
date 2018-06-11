using System;
using System.Windows.Forms;

namespace ErrorProviderTest
{
    /// <summary>
    /// バインドあり随時チェック
    /// </summary>
    public partial class Form2 : Form
    {
        /// <summary>
        /// ViewModel
        /// </summary>
        private Form2ViewModel vm;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"><see cref="object"/></param>
        /// <param name="e"><see cref="EventArgs"/></param>
        private void Form2_Load(object sender, EventArgs e)
        {
            vm = new Form2ViewModel();
            bindingSource1.DataSource = vm;
        }

        /// <summary>
        /// 登録
        /// </summary>
        /// <param name="sender"><see cref="object"/></param>
        /// <param name="e"><see cref="EventArgs "/></param>
        private void button1_Click(object sender, EventArgs e)
        {
            foreach(Control ctl in Controls)
            {
                if(string.IsNullOrEmpty(errorProvider1.GetError(ctl))== false){
                    MessageBox.Show("エラーあり！");
                    return;
                }
            }
            MessageBox.Show("登録できました。");
        }

        /// <summary>
        /// 閉じる
        /// </summary>
        /// <param name="sender"><see cref="object"/></param>
        /// <param name="e"><see cref="EventArgs "/></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
