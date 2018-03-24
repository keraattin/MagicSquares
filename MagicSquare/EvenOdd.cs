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
    public partial class EvenOdd : Form
    {
        public EvenOdd()
        {
            InitializeComponent();
        }

        static DataGridView matris = new DataGridView();

        private void EvenOdd_Load(object sender, EventArgs e)
        {
            labelExpectedValue.Text += ValueClass.expectedValue;

            createMatrix(ValueClass.N);

            doldur(ValueClass.N);

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

        private void swap(int a, int b, int x, int y)
        {
            int tmp = Convert.ToInt32(matris.Rows[a].Cells[b].Value);
            matris.Rows[a].Cells[b].Value = matris.Rows[x].Cells[y].Value;
            matris.Rows[x].Cells[y].Value = tmp;

            matris.Rows[a].Cells[b].Style.BackColor = Color.LimeGreen;
            matris.Rows[x].Cells[y].Style.BackColor = Color.LimeGreen;

        }

        int m = ((ValueClass.N / 2) / 2 ) - 1;
        int k = 0;
        int i = 0;
        int j = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            /*Alt ve üst swapları için*/

            if (m >= 0)
            {
                if (k == ValueClass.N / 2)
                {
                    m--;
                    j++;
                    i = 0;
                    k = 0;
                }
                if (m == 0)
                {
                    timer1.Stop();
                    return;
                }
                swap(i, j, (ValueClass.N - 1) - i, j);
                i++;
                k++;
            }
        }
    }
}
