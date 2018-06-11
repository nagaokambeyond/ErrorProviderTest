using System;
using System.Windows.Forms;

namespace ErrorProviderTest
{
    /// <summary>
    /// バインドあり登録時チェック
    /// </summary>
    public partial class Form3 : Form
    {
        /// <summary>
        /// ViewModel
        /// </summary>
        private Form3ViewModel vm;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form3()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form3_Load(object sender, EventArgs e)
        {
            vm = new Form3ViewModel();
            bindingSource1.DataSource = vm;
        }

        /// <summary>
        /// 登録
        /// </summary>
        /// <param name="sender"><see cref="object "/></param>
        /// <param name="e"><see cref="EventArgs "/></param>
        private void button1_Click(object sender, EventArgs e)
        {
            vm.ValidateAll();
            errorProvider1.UpdateBinding();
            if(vm.HasError())
            {
                MessageBox.Show("エラーがあります。");
                return;
            }
            MessageBox.Show("登録できました。");
        }

        /// <summary>
        /// FormClosed
        /// </summary>
        /// <param name="sender"><see cref="object"/></param>
        /// <param name="e"><see cref="FormClosedEventArgs "/></param>
        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            vm.Dispose();
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
