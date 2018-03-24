using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicSquare
{
    public partial class Selection : Form
    {
        public Selection()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if(txtValueN.Text == "")
            {
                MessageBox.Show("Lütfen N değerini giriniz.");
            }
            else
            {
                ValueClass.N = Convert.ToInt32(txtValueN.Text);
                ValueClass.expectedValue = ((1 + (ValueClass.N * ValueClass.N)) / 2) * ValueClass.N ;

                if (ValueClass.N % 2 != 0)                      //Tek
                {
                    OddForm of = new OddForm();
                    of.Show();
                    this.Hide();
                }
                else if ((ValueClass.N / 2) % 2 == 0)           //Çift
                {
                    EvenForm ef = new EvenForm();
                    ef.Show();
                    this.Hide();
                }
                else if ((ValueClass.N / 2) % 2 != 0)       
                {
                    MessageBox.Show("Henüz bu sonuç için çözüm kodlanmamıştır.");
                }
            }
        }
    }
}
