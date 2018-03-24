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
    public partial class OddForm : Form
    {
        public OddForm()
        {
            InitializeComponent();
        }

        static DataGridView matris = new DataGridView();
        static int i;
        static int j;
        static int k = 2;

        private void OddForm_Load(object sender, EventArgs e)
        {
            labelExpectedValue.Text += ValueClass.expectedValue;

            DialogResult sor = MessageBox.Show("Kendiniz mi başlanıç belirlemek istersiniz ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sor == DialogResult.Yes)
            {
                createMatrix(ValueClass.N);   
            }
            else
            {
                createMatrix(ValueClass.N);

                labelInfo.Enabled = false;
                labelInfo.Visible = false;

                btnStart.Enabled = false;
                btnStart.Visible = false;

                DialogResult sorRandom = MessageBox.Show("Başlangıç değeri random mu seçilsin sabit mi olsun? ", "Random?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (sorRandom == DialogResult.Yes)
                {
                    Random rnd = new Random();
                    while (true)
                    {
                        i = rnd.Next(0, ValueClass.N - 1);
                        j = rnd.Next(0, ValueClass.N - 1);
                        if (isSelectedCellTrue(i, j) == true)
                            break;
                    }

                    matris.Rows[i].Cells[j].Value = 1;
                    matris.Rows[i].Cells[j].Style.BackColor = Color.LimeGreen;

                    matris.Columns.Add("agirlik", "Ağırlık"); //Ağırlık sütununu ekleme.
                    matris.Columns["agirlik"].ReadOnly = true; //Ağırlık sütunu üzerinde değişiklik yapma engellendi.
                    matris.Columns["agirlik"].Width = 42; //Ağırlık sütununun genişliği ayarlandı.
                    matris.Columns["agirlik"].Resizable = DataGridViewTriState.False; //Ağırlık sütunun genişliği değiştilemez olarak ayarlandi.
                    matris.Rows.Add(); //Ağırlık satiri ekleniyor.

                    timer1.Start();

                }
                else
                {
                    i = ValueClass.N / 2;
                    j = ValueClass.N - 1;

                    matris.Rows[i].Cells[j].Value = 1;
                    matris.Rows[i].Cells[j].Style.BackColor = Color.LimeGreen;

                    matris.Columns.Add("agirlik", "Ağırlık"); //Ağırlık sütununu ekleme.
                    matris.Columns["agirlik"].ReadOnly = true; //Ağırlık sütunu üzerinde değişiklik yapma engellendi.
                    matris.Columns["agirlik"].Width = 42; //Ağırlık sütununun genişliği ayarlandı.
                    matris.Columns["agirlik"].Resizable = DataGridViewTriState.False; //Ağırlık sütunun genişliği değiştilemez olarak ayarlandi.
                    matris.Rows.Add(); //Ağırlık satiri ekleniyor.

                    timer1.Start();
                }
            }
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

        private bool isSelectedCellTrue(int a, int b)
        {
            int satir = 0;
            int sutun = ValueClass.N / 2;
            int index = 0;
            while(index < ValueClass.N)
            {
                if (a == satir && b == sutun)
                {
                    return true;
                }

                //if (i + 1 > ValueClass.N - 1) i = 0;
                //else i = i + 1;
                satir = satir + 1;

                if (sutun + 1 > ValueClass.N - 1) sutun = 0;
                else sutun = sutun + 1;

                index++;
            }
            return false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            i = matris.CurrentCell.RowIndex;
            j = matris.CurrentCell.ColumnIndex;

            if(i==j)
            {
                MessageBox.Show("Köşegenlerde seçilen değerler için köşegen toplamları doğru çıkmamaktadır." +
                    "Lütfen yeni bir hücre seçiniz.");
            }
            else if( isSelectedCellTrue(i,j) == true)
            {
                matris.Rows[i].Cells[j].Value = 1;
                matris.Rows[i].Cells[j].Style.BackColor = Color.LimeGreen;

                matris.Columns.Add("agirlik", "Ağırlık"); //Ağırlık sütununu ekleme.
                matris.Columns["agirlik"].ReadOnly = true; //Ağırlık sütunu üzerinde değişiklik yapma engellendi.
                matris.Columns["agirlik"].Width = 42; //Ağırlık sütununun genişliği ayarlandı.
                matris.Columns["agirlik"].Resizable = DataGridViewTriState.False; //Ağırlık sütunun genişliği değiştilemez olarak ayarlandi.
                matris.Rows.Add(); //Ağırlık satiri ekleniyor.

                timer1.Start();
            }
            else
            {
                MessageBox.Show("Malesef Bu algoritma seçilen yerlerde köşegen toplamları için doğru çalışmamaktadır." +
                    "Lüften başka bir başlangıç noktası seçiniz");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (k <= ValueClass.N * ValueClass.N)
            {
                if (i + 1 > ValueClass.N - 1) i = 0;
                else i = i + 1;

                if (j + 1 > ValueClass.N - 1) j = 0;
                else j = j + 1;

                if (matris.Rows[i].Cells[j].Style.BackColor == Color.LimeGreen)
                {
                    if (i - 1 < 0) i = ValueClass.N - 1;
                    else i = i - 1;

                    if (j - 1 < 0) j = ValueClass.N - 2;
                    else if (j - 2 < 0) j = ValueClass.N - 1;
                    else j = j - 2;
                }
                matris.Rows[i].Cells[j].Value = k;
                matris.Rows[i].Cells[j].Style.BackColor = Color.LimeGreen;
                k++;

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
            if(k> ValueClass.N * ValueClass.N)
            {
                timer1.Stop();
                lastPulse();
            }
        }

        private void lastPulse()
        {
            DataGridViewTextBoxColumn vc = new DataGridViewTextBoxColumn();
            vc.ReadOnly = true;
            vc.Width = 42;
            vc.Resizable = DataGridViewTriState.False;
            matris.Columns.Insert(0, vc);

            int sutun = 1;

            // Ağırlık hesaplama bölümü
            int toplam = 0;
            for (int satir = 0; satir < ValueClass.N; satir++)
            {
                for (sutun = 1; sutun <= ValueClass.N; sutun++)
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


        private void buttonRestart_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            Application.Restart();
        }

        private void OddForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }
    }
}
