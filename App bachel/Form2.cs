using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_bachel
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.textBox2.AutoSize = false;
            this.textBox2.Size = new Size(this.textBox2.Size.Width, this.textBox1.Size.Height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String login = textBox1.Text;
            String password = textBox2.Text;

            if (login == "admin" & password == "1234")
            {
                FluentDesignForm1 form2 = new FluentDesignForm1();
                textBox1.Text = "";
                textBox2.Text = "";

                form2.Show();
            }
            else
            {
                MessageBox.Show("Неправильні облікові дані\n(логін і пароль зліва під зображеннями)", "Невірно!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
    }
}
