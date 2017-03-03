using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {

        Random rnd = new Random();
        int count = 0;
        Dictionary<string, double> metrica;
        char[] spec_chars = new char[] {'%','*',')','?','#','$','^','&','~' };
        public Form1()
        {
            InitializeComponent();
            rnd = new Random();
            metrica=new Dictionary<string,double>();
            metrica.Add("mm",1);
            metrica.Add("cm", 10);
            metrica.Add("dm", 100);
            metrica.Add("m", 1000);
            metrica.Add("km", 1000000);
            metrica.Add("mile", 1609344);
        
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void butPlus_Click(object sender, EventArgs e)
        {
            count++;
            lblCount.Text = count.ToString(); // +
        }

        private void butMinus_Click(object sender, EventArgs e)
        {
            count--;
            lblCount.Text = count.ToString(); // -
        }

        private void butReset_Click(object sender, EventArgs e)
        {
            count=0;
            lblCount.Text = Convert.ToString(count);
        }

        private void lblCount_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void butRandom_Click(object sender, EventArgs e)
        {
            int n = rnd.Next(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value+1));
            lblRandom.Text = n.ToString();
          //  txtRandom.AppendText(n+"\n");
            if(chRandom.Checked)
            {
                int i = 0;

                while (txtRandom.Text.IndexOf(n.ToString()) != -1)
                {
                    n = rnd.Next(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value + 1));
                                    
                    i++;
                    if(i>1000)break;
                }
                if (i <= 1000) txtRandom.AppendText(n + "\n");
            } else txtRandom.AppendText(n + "\n");

        }

        private void butRandomClear_Click(object sender, EventArgs e)
        {
            //Clear оширеди 
            txtRandom.Clear();
        }

        private void butRandomCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtRandom.Text);
        }

        private void txtRandom_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void tsInsertDate_Click(object sender, EventArgs e)
        {
            //AppendText--> richTextBox1- ка тексти косады 
            // DateTime структура
            //Now -> казирги уакытты береди
            //ToShortDateString строкага айналдырады
            richTextBox1.AppendText(DateTime.Now.ToShortDateString()+"\n");
                
        }

        private void tsInsertTime_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText(DateTime.Now.ToShortTimeString() + "\n");
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            try
            {      //SaveFile файл сактау
                richTextBox1.SaveFile("notepad.rtf");
            }
            catch
            {
                MessageBox.Show("Ошибка при сохранений");
            }                    
         
        }
        void LoadNotepad()
        {
            try
            {      //загружает файл формате rtf
                richTextBox1.LoadFile("notepad.rtf");
            }
            catch
            {
                MessageBox.Show("Ошибка при загрузке");
            }
        }
    

        private void tsLoad_Click(object sender, EventArgs e)
        {
            LoadNotepad();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadNotepad();
            clbPassword.SetItemChecked(0,true);
            clbPassword.SetItemChecked(1, true);
        }

        private void btnPassword_Click(object sender, EventArgs e)
        {
            if (clbPassword.CheckedItems.Count == 0) return;
            string password = "";
            for (int i = 0; i < nudPasLength.Value;i++ )
            {
                int n = rnd.Next(0, clbPassword.CheckedItems.Count);
                string s= clbPassword.CheckedItems[n].ToString();
                switch(s)
                {
                    case "Цифры" : password += rnd.Next(10).ToString();
                        break;
                    case "Прописные буквы": password += Convert.ToChar(rnd.Next(65, 88));
                        break;
                    case "Строчные буквы": password += Convert.ToChar(rnd.Next(97, 122));
                        break;
                    default:
                        password += spec_chars[rnd.Next(spec_chars.Length)];
                        break;                
                }
                tbPassword.Text = password;
                Clipboard.SetText(password);
            
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            double m1 = metrica[cbxFrom.Text];
            double m2 = metrica[cbxTo.Text];
            double n = Convert.ToDouble(tbxFrom.Text);
            tbxTo.Text = (n * m1 / m2).ToString();
        
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            string t = cbxFrom.Text;
            cbxFrom.Text = cbxTo.Text;
            cbxTo.Text = t;
        }
    }
}
