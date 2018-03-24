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
    public partial class EvenForm : Form
    {
        public EvenForm()
        {
            InitializeComponent();
        }

        static DataGridView matris = new DataGridView();

        private void EvenForm_Load(object sender, EventArgs e)
        {
            ValueClass.expectedValue = ValueClass.expectedValue + (ValueClass.N / 2);

            labelExpectedValue.Text += ValueClass.expectedValue;

            createMatrix(ValueClass.N);

            doldur(ValueClass.N);

            int i = 0;
            int j = 0;

            matris.Columns.Add("agirlik", "Ağırlık"); //Ağırlık sütununu ekleme.
            matris.Columns["agirlik"].ReadOnly = true; //Ağırlık sütunu üzerinde değişiklik yapma engellendi.
            matris.Columns["agirlik"].Width = 42; //Ağırlık sütununun genişliği ayarlandı.
            matris.Columns["agirlik"].Resizable = DataGridViewTriState.False; //Ağırlık sütunun genişliği değiştilemez olarak ayarlandi.
            matris.Rows.Add(); //Ağırlık satiri ekleniyor.
            
            timer1.Start();
        }

        private void createMatrix(int n)
        {
            /*Sütunlar oluşturuldu.*/
            for (int i = 0; i < n; i++)
            {
                matris.Columns.Add("x" + (i + 1).ToString() + "", "x" + (i + 1).ToString() + ""); //Sutun ekleme.
                matris.Columns[i].Width = 30; //Eklenen sütunun genisliğini ayarlandı.
                matris.Columns[i].Resizable = DataGridViewTriState.False; //Kolonların genişliği değiştirilemez olarak ayarlandi.
            }

            /*Satırlar oluşturuldu.*/
            for (int j = 0; j < n; j++)
            {
                matris.Rows.Add(); //Satir ekleme.
                matris.Rows[j].Height = 20; //Satirlarin yuksekligi ayarlandi.
                matris.Rows[j].HeaderCell.Value = "y" + (j + 1).ToString(); //Satirlarin basina isim verildi.
                matris.Rows[j].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight; //Satir basindaki yazilar saga dayali hale getirildi.
            }

            matris.RowHeadersWidth = 50;  //Header satirinin genisligi ayarlaniyor. 
            matris.SelectionMode = DataGridViewSelectionMode.CellSelect; //Secimin sadece hücre bazli yapilmasi saglaniyor.
            matris.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing; //Satir basindaki hucrenin yeniden boyutlandirilmasi engelleniyor.
            matris.MultiSelect = false; //Kullanicilarin birden cok secim yapmasi engelleniyor.
            matris.AllowUserToDeleteRows = false; //Kullanicilarin matristen satir silmesi engelleniyor.
            matris.AllowUserToResizeRows = false; //Kullanicillarin matirisin satirlarinin boyutunu degistirmesi engelleniyor.
            matris.AllowUserToAddRows = false; //Matrise kullanicilarin satir eklemesi engelleniyor.
            matris.Size = new Size((30 * n) + 106, (20 * n) + 48);  //Matris'in boyutu belirleniyor.
            matris.Location = new Point(20, 80);            //Matris'in lokasyonu belirleniyor.
            matris.Visible = true;                        //Matris'in görünürlüğü aciliyor.

            matris.ColumnHeadersVisible = false;
            matris.RowHeadersVisible = false;

            this.Controls.Add(matris); //Matris pencereye ekleniyor.
        }

        private void doldur(int n)
        {
            int k = 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matris.Rows[i].Cells[j].Value = k;
                    k++;
                }
            }
        }

        private void agirlikHesapla()
        {
            // Ağırlık hesaplama bölümü
            int toplam = 0;
            for (int satir = 0; satir < ValueClass.N; satir++)
            {
                for (int sutun = 0; sutun < ValueClass.N; sutun++)
                {
                    toplam += Convert.ToInt32(matris.Rows[satir].Cells[sutun].Value);
                }
                matris.Rows[satir].Cells[ValueClass.N].Value = toplam;
                matris.Rows[satir].Cells[ValueClass.N].Style.BackColor = Color.LightSeaGreen;
                toplam = 0;
            }

            toplam = 0;

            for (int sutun = 0; sutun < ValueClass.N; sutun++)
            {
                for (int satir = 0; satir < ValueClass.N; satir++)
                {
                    toplam += Convert.ToInt32(matris.Rows[satir].Cells[sutun].Value);
                }
                matris.Rows[ValueClass.N].Cells[sutun].Value = toplam;
                matris.Rows[ValueClass.N].Cells[sutun].Style.BackColor = Color.LightSeaGreen;
                toplam = 0;
            }

            toplam = 0;

            for (int satir = 0; satir < ValueClass.N; satir++)
            {
                int sutun = satir;
                toplam += Convert.ToInt32(matris.Rows[satir].Cells[sutun].Value);
            }
            matris.Rows[ValueClass.N].Cells[ValueClass.N].Value = toplam;
            matris.Rows[ValueClass.N].Cells[ValueClass.N].Style.BackColor = Color.LightPink;
        }

        private void swap(int a, int b, int x, int y)
        {
            int tmp = Convert.ToInt32(matris.Rows[a].Cells[b].Value);
            matris.Rows[a].Cells[b].Value = matris.Rows[x].Cells[y].Value;
            matris.Rows[x].Cells[y].Value = tmp;

            matris.Rows[a].Cells[b].Style.BackColor = Color.LimeGreen;
            matris.Rows[x].Cells[y].Style.BackColor = Color.LimeGreen;

        }

        int i = 0;
        int j = ValueClass.N / 4;

        int k = 0;
        int m = ValueClass.N / 4;
        private void timer1_Tick(object sender, EventArgs e)
        {
            /*Alt ve üst swapları için*/

            if (m >= 0)
            {
                if (k == ValueClass.N / 2)
                {
                    m--;
                    i++;
                    j = ValueClass.N / 4;
                    k = 0;
                }
                if (m == 0)
                {
                    timer1.Stop();
                    timer2.Start();
                    return;
                }
                swap(i, j, (ValueClass.N - 1) - i, (ValueClass.N - 1) - j);
                j++;
                k++;
             }

            agirlikHesapla();

        }

        int satir = ValueClass.N / 4;
        int sutun = 0;

        int ka = 0;
        int mo = ValueClass.N / 4;
        private void timer2_Tick(object sender, EventArgs e)
        {
            /*Sağ ve sol için*/

            if (mo >= 0)
            {
                if (ka == ValueClass.N / 2)
                {
                    mo--;
                    sutun++;
                    satir = ValueClass.N / 4;
                    ka = 0;
                }
                if (mo == 0)
                {
                    timer2.Stop();
                    lastPulse();
                    return;
                }
                swap(satir, sutun, (ValueClass.N - 1) - satir, (ValueClass.N - 1) - sutun);
                satir++;
                ka++;
            }

            agirlikHesapla();
        }

        private void lastPulse()
        {
            DataGridViewTextBoxColumn vc = new DataGridViewTextBoxColumn();
            vc.ReadOnly = true;
            vc.Width = 42;
            vc.Resizable = DataGridViewTriState.False;
            matris.Columns.Insert(0, vc);


            // Ağırlık hesaplama bölümü
            int toplam = 0;
            for (int satir = 0; satir < ValueClass.N; satir++)
            {
                for (int sutun = 1; sutun <= ValueClass.N; sutun++)
                {
                    toplam += Convert.ToInt32(matris.Rows[satir].Cells[sutun].Value);
                }
                matris.Rows[satir].Cells[0].Value = toplam;
                matris.Rows[satir].Cells[0].Style.BackColor = Color.LightSeaGreen;
                toplam = 0;
            }

            toplam = 0;
            sutun = ValueClass.N;
            for (int satir = 0; satir < ValueClass.N; satir++)
            {
                toplam += Convert.ToInt32(matris.Rows[satir].Cells[sutun].Value);
                sutun--;
            }
            matris.Rows[ValueClass.N].Cells[0].Value = toplam;
            matris.Rows[ValueClass.N].Cells[0].Style.BackColor = Color.LightPink;
        }

        private void EvenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }
    }
}
