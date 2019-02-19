using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApplication8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            res.p = true;
            res.k = 5;

        }
        private void richTextBox3_KeyPress(//разрешен ввод только цифр
           object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == ' ')
                e.Handled = true;
        }
        
        private void richTextBox2_KeyPress(//запрет пробела
            object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                e.Handled = true;
        }
        private void richTextBox1_KeyPress(//запрет пробела
            object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                e.Handled = true;
        }
        private void button1_Click(object sender, EventArgs e)//добавить строку
        {
            dataGridView1.Rows.Add();
            int i = int.Parse(dataGridView1.RowCount.ToString())-1;
            dataGridView1.Rows[i].Cells[0].Value = richTextBox1.Text;
            dataGridView1.Rows[i].Cells[1].Value = richTextBox2.Text;
            dataGridView1.Rows[i].Cells[2].Value = richTextBox3.Text;
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            res.p = false;

        }

        private void button2_Click(object sender, EventArgs e)//изменить
        {
            try
            {
                res.i = dataGridView1.CurrentRow.Index;
                richTextBox1.Text = dataGridView1.Rows[res.i].Cells[0].Value.ToString();
                richTextBox2.Text = dataGridView1.Rows[res.i].Cells[1].Value.ToString();
                richTextBox3.Text = dataGridView1.Rows[res.i].Cells[2].Value.ToString();
                
                res.p = false;
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    if(j!=res.i)
                    dataGridView1.Rows[j].Visible = false;
                }
                button6.Visible = true;
                button7.Visible = true;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
            }
            catch
            {
                MessageBox.Show("Строка для изменения не выбрана", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
        }

        private void button6_Click(object sender, EventArgs e)//подтвердить и сохранить изменения
        {
            try
            {
                dataGridView1.Rows[res.i].Cells[0].Value = richTextBox1.Text;
                dataGridView1.Rows[res.i].Cells[1].Value = richTextBox2.Text;
                dataGridView1.Rows[res.i].Cells[2].Value = richTextBox3.Text;
                richTextBox1.Clear();
                richTextBox2.Clear();
                richTextBox3.Clear();
                res.p = false;
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    dataGridView1.Rows[j].Visible = true;
                }
                button6.Visible = false;
                button7.Visible = false;
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
            }
            catch
            {
                MessageBox.Show("Стррока для изменения не выбрана", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
        }

        private void button7_Click(object sender, EventArgs e)//отменить изменения
        {
            try
            {
               
                richTextBox1.Clear();
                richTextBox2.Clear();
                richTextBox3.Clear();
                res.p = false;
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    dataGridView1.Rows[j].Visible = true;
                }
                button6.Visible = false;
                button7.Visible = false;
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
            }
            catch
            {
                MessageBox.Show("Стррока для изменения не выбрана", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
        }

        private void button3_Click(object sender, EventArgs e)//удалить
        {
            try
            {
                res.i = dataGridView1.CurrentRow.Index;
                dataGridView1.Rows.RemoveAt(res.i);
                res.p = false;
            }
            catch
            {
                MessageBox.Show("Строка для удаления не выбрана", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
        }

        private void button4_Click(object sender, EventArgs e)//open
        {
            res.i = dataGridView1.RowCount;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                string fileText = System.IO.File.ReadAllText(filename);
                string s = fileText;
                int m=0;

                string s1;
                s1 = "";
                int n1;
                int n = 0;
                while (n < s.Length)
                {
                   
                    if (s[n] == ' ')
                    {
                        m++;
                       
                    }
                    n++;
                }
                n = n1 = 0;
                m = (m + 1) / 3;
                for (int j = 0; j < m; j++)
                {
                    dataGridView1.Rows.Add();
                    for (int i = 0; i < 3; i++)
                    {
                        while ( n < s.Length)
                        {
                            
                            if (s[n] == ' ')
                            {
                                s1 = s.Substring(n1, n - n1);
                                n1 = n + 1;
                                break;
                            }
                            n++;
                        }
                        n++;
                        dataGridView1.Rows[j+res.i].Cells[i].Value = s1;
                    }
                }
            }
            res.p = true;
        }

        private void button5_Click(object sender, EventArgs e)//save
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                
                string s = "";
                for (int j=0;j< dataGridView1.RowCount; j++)
                {
                    for (int i = 0; i<3; i++)
                    {
                        s += dataGridView1.Rows[j].Cells[i].Value.ToString() + " ";
                    }
                }
                System.IO.File.WriteAllText(filename, s);
            }
            res.p = true;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)//подготовка к поиску
        {
            richTextBox1.Clear();
            if (checkBox1.Checked == true)
            {
                richTextBox1.Visible = false;

                richTextBox2.Visible = false;
                richTextBox3.Visible = false;
                label1.Visible = false;

                label2.Visible = false;
                label3.Visible = false;
                
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
                
            }
            if (checkBox1.Checked == false)
            {
                richTextBox1.Visible = true;
                label1.Visible = true;

                richTextBox2.Visible = true;
                richTextBox3.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
               
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    dataGridView1.Rows[j].Visible = true;
                }
            }

        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)//поиск
        {
            
                res.s = richTextBox1.Text;
            string s = "";
            if (Clipboard.GetText().Length > 50)
            { s = Clipboard.GetText().Substring(0, 50); }
            else { s = Clipboard.GetText(); }
            if (s == res.s)
            { res.s = "";richTextBox1.Clear(); }
            if (checkBox1.Checked == true && res.k==0)
            {
                res.s=res.s.ToLower();
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    dataGridView1.Rows[j].Visible = true;
                    
                }
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    
                    string s1 = dataGridView1.Rows[j].Cells[res.k].Value.ToString();
                    if (res.s.Length > s1.Length)
                    { dataGridView1.Rows[j].Visible = false; }
                    else
                    {
                        s1 = s1.ToLower();
                        if (s1.Length >= res.s.Length)
                        {
                            if ((s1.Substring(0, res.s.Length) != res.s))
                                dataGridView1.Rows[j].Visible = false;
                        }
                    }
                }
               
            }
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)//поиск
        {

            res.s = richTextBox2.Text;
            string s = "";
            if (Clipboard.GetText().Length > 50)
            { s = Clipboard.GetText().Substring(0, 50); }
            else { s = Clipboard.GetText(); }
            if (s == res.s)
            { res.s = ""; richTextBox2.Clear(); }
            for (int j = 0; j < dataGridView1.RowCount; j++)
            {
                dataGridView1.Rows[j].Visible = true;
            }
            if (checkBox1.Checked == true && res.k == 1)
            {
                res.s = res.s.ToLower();

                for (int j = 0; j < dataGridView1.RowCount; j++)
                {

                    string s1 = dataGridView1.Rows[j].Cells[res.k].Value.ToString();

                    if (res.s.Length > s1.Length)
                    { dataGridView1.Rows[j].Visible = false; }
                    else
                    {
                        s1 = s1.ToLower();
                        if (s1.Length >= res.s.Length)
                        {
                            if ((s1.Substring(0, res.s.Length) != res.s))
                                dataGridView1.Rows[j].Visible = false;
                        }
                    }
                }
                
            }
        }
        private void richTextBox3_TextChanged(object sender, EventArgs e)//поиск
        {

            res.s = richTextBox3.Text;
            string s = "";
            if(Clipboard.GetText().Length>15)
            { s= Clipboard.GetText().Substring(0, 15); }
            else { s = Clipboard.GetText(); }
            if (s == res.s)
            { res.s = ""; richTextBox3.Clear(); }
            s = "";
            if (checkBox1.Checked == true && res.k == 2)
            {
                res.s = res.s.ToLower();
                 for (int j = 0; j < dataGridView1.RowCount; j++)
                                    {
                                        dataGridView1.Rows[j].Visible = true;
                                    }
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {

                    string s1 = dataGridView1.Rows[j].Cells[res.k].Value.ToString();

                    if (res.s.Length > s1.Length)
                    { dataGridView1.Rows[j].Visible = false; }
                    else
                    {
                        s1 = s1.ToLower();
                        if (s1.Length >= res.s.Length)
                        {
                            if ((s1.Substring(0, res.s.Length) != res.s))
                                dataGridView1.Rows[j].Visible = false;
                        }
                    }
                }
                
                   
                
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (res.p==false)
            {
                DialogResult result = MessageBox.Show("Сохранить изменения?", "Сохранить?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    button5_Click(sender, e);
                }
                else
                {
                    return;
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            res.k = 0;
            label1.Visible = true;
            label2.Visible = false;
            label3.Visible = false;

            richTextBox1.Visible = true;
            richTextBox2.Visible = false;
            richTextBox3.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            res.k = 1;
            label2.Visible = true;
            label1.Visible = false;
            label3.Visible = false;

            richTextBox2.Visible = true;
            richTextBox1.Visible = false;
            richTextBox3.Visible = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            res.k = 2;
            label3.Visible = true;
            label2.Visible = false;
            label1.Visible = false;

            richTextBox3.Visible = true;
            richTextBox2.Visible = false;
            richTextBox1.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
