using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumberingSystemProject
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        enum ensystem
        {
            ebinary, edecimal, eoctal, ehexadecimal
        }
        ensystem system1 = ensystem.ebinary;
        ensystem system2 = ensystem.edecimal;

        int frombtod(string binary)
        {
            int c = 0;
            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[i] == '1' || binary[i] == '0')
                {
                    if (binary[i] == '1')
                        c += 1 * Convert.ToInt32(Math.Pow(2, binary.Length - 1 - i));
                }
                else
                    return 0;

            } return c;
        }
        string frombtoO(string binary)
        {
            int dec = frombtod(binary);
            string oct = fromdtoo(dec.ToString());
            return oct;
        }
        string fromdtob(string d)
        {
            StringBuilder s=new StringBuilder();
            int reminder = 0;
            if (d == "0" || string.IsNullOrWhiteSpace(d))
            {
                return "0";
            }
            else
            {
                int dec = Convert.ToInt32(d);
                while (dec != 0)
                {
                    reminder = (dec % 2);
                    dec /= 2;
                    s.Insert(0, reminder);
                }
            }
            return s.ToString().PadLeft(3, '0');
        }
        string fromdtoo(string dec)
        {
            int reminder = 0;
            StringBuilder s = new StringBuilder();
            
            if (dec == "0"|| string.IsNullOrWhiteSpace(dec))
            {
                return "0";
            }
            else
            {
                int decc = Convert.ToInt32(dec);
                while (decc != 0)
                {
                    reminder = decc % 8;
                    decc /= 8;
                    s.Insert(0, reminder);
                }
            }
           
            return s.ToString();
        }
        string fromdtohex(string dec)
        {
            StringBuilder s = new StringBuilder();
            if (dec == "0" || string.IsNullOrWhiteSpace(dec))
            {
                return "0";
            }
            else
            {
                int d = Convert.ToInt32(dec);
                int reminder = 0;
                char[] hex = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
                while (d > 0)
                {
                    reminder = d % 16;
                    d /= 16;
                    s.Insert(0, hex[reminder]);
                }
            }
            return s.ToString();
        }
        string frombtohex(string binary)
        {
            int dec = frombtod(binary);
            string hex = fromdtohex(dec.ToString());
            return hex;
        }
        string fromotob(string octul)
        {
            string binary = "";
            for(int i = 0; i < octul.Length; i++)
            {
                binary += fromdtob(octul[i].ToString());
            }return binary;
        }
        string fromotod(string octul)
        {
            string binary = fromotob(octul);
            string dec = frombtod(binary).ToString();
            return dec;
        }
        string fromotohex(string octul)
        {
            string dec = fromotod(octul);
            string hex = fromdtohex(dec);
            return hex;
        }
        string fromhextob(string hex) 
        {
            string binary = "";
            for(int i = 0; i < hex.Length; i++)
            {
                binary += fromdtob(hex[i].ToString()).PadLeft(4,'0');
            }return binary;
        }
        string fromhextod(string hex)
        {
            string binary = fromhextob(hex);
            string dec = frombtod(binary).ToString();
            return dec;
        }
        string fromhextoo(string hex)
        {
            string dec = fromhextod(hex);
            string octul = fromdtoo(dec);
            return octul;
        }
        void generateresult()
        {
            if (system1 == ensystem.ebinary) {
                switch (system2)
                {
                    case ensystem.edecimal:
                        textBox2.Text = frombtod(textBox1.Text).ToString();
                        break;
                    case ensystem.eoctal:
                        textBox2.Text = frombtoO(textBox1.Text);
                        break;
                    case ensystem.ehexadecimal:
                        textBox2.Text = frombtohex(textBox1.Text);
                        break;
                    case ensystem.ebinary:
                        textBox2.Text = textBox1.Text;
                        break;
                }

            }
            else if (system1 == ensystem.edecimal)
            {
                switch (system2)
                {
                    case ensystem.ebinary:
                        textBox2.Text = fromdtob(textBox1.Text);
                        break;
                    case ensystem.eoctal:
                        textBox2.Text = fromdtoo(textBox1.Text);
                        break;
                    case ensystem.ehexadecimal:
                        textBox2.Text = fromdtohex(textBox1.Text);
                        break;
                    case ensystem.edecimal:
                        textBox2.Text = textBox1.Text;
                        break;
                }
            }
            else if (system1 == ensystem.eoctal)
            {
                switch (system2)
                {
                    case ensystem.edecimal:
                        textBox2.Text = fromotod(textBox1.Text);
                        break;
                    case ensystem.ebinary:
                        textBox2.Text=fromotob(textBox1.Text);
                        break;
                    case ensystem.ehexadecimal:
                        textBox2.Text = fromotohex(textBox1.Text);
                        break;
                    case ensystem.eoctal:
                        textBox2.Text = textBox1.Text;
                        break;
                }
            }
            else
            {
                switch (system2)
                {
                    case ensystem.edecimal:
                        textBox2.Text = fromhextod(textBox1.Text).ToString();
                        break;
                    case ensystem.eoctal:
                        textBox2.Text = fromhextoo(textBox1.Text).ToString();
                        break;
                    case ensystem.ebinary:
                        textBox2.Text = fromhextob(textBox1.Text).ToString();
                        break;
                    case ensystem.ehexadecimal:
                        textBox2.Text = textBox1.Text;
                        break;
                }
            }
        }
        void genaratesystem1()
        {
            if (from.Text == "Binary")
            {
                system1 = ensystem.ebinary;
            }
            else if (from.Text== "Decimal")
            {
                system1 = ensystem.edecimal;
            }
            else if (from.Text == "Octal")
            {
                system1 = ensystem.eoctal;
            }
            else
            {
                system1 = ensystem.ehexadecimal;
            }
        }
        void genaratesystem2()
        {
            if (to.Text == "Binary")
            {
                system2 = ensystem.ebinary;
            }
            else if (to.Text == "Decimal")
            {
                system2 = ensystem.edecimal;
            }
            else if (to.Text == "Octal")
            {
                system2 = ensystem.eoctal;
            }
            else
            {
                system2 = ensystem.ehexadecimal;
            }
        }
        private void from_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            genaratesystem1();
        }
        private void to_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = "0";
            genaratesystem2();
            generateresult();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            generateresult();
        }
        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            string input = textBox1.Text;
            if (system1 == ensystem.ebinary )
            {
                if (e.KeyChar == '0' || e.KeyChar == '1' || e.KeyChar == '\b')
                {
                    e.Handled = false;
                    errorProvider1.SetError(textBox1, "");
                }
                else
                {
                    e.Handled = true;
                    errorProvider1.SetError(textBox1, "accept only 0/1 ");
                }
            }
            if (system1 == ensystem.ebinary) { 
                 if (input.Length >= 31)
                {
                    e.Handled = true;
                    textBox1.Text = input.Substring(0, 31);
                    errorProvider1.SetError(textBox1, "only accept 32 digits(in binary)");

                }
            }
            else if (system1 == ensystem.ehexadecimal)
            {
                if (input.Length >= 8)
                {
                    e.Handled = true;
                    textBox1.Text = input.Substring(0, 8);
                    errorProvider1.SetError(textBox1, "only accept 9 digits(in hexadecimal)");
                }
            }
            else if(system1 == ensystem.eoctal)
            {
                if (input.Length >= 11)
                {
                    e.Handled = true;
                    textBox1.Text = input.Substring(0, 11);
                    errorProvider1.SetError(textBox1, "only accept 11 digits (in octal)");
                }
            }
        }

        private void btstart_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            from.Enabled = true;
            to.Enabled = true;
        }

        private void from_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void to_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
