using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Ebat kucuk = new Ebat
            {
                Adi
                = "Kucuk ",
                Carpan = 1
            };
            Ebat orta = new Ebat { Adi = "Orta", Carpan = 1.25 };
            Ebat buyuk = new Ebat { Adi = "Buyuk", Carpan = 1.75 };
            Ebat maxi = new Ebat { Adi = "Maxi", Carpan = 2 };
            cmbEbat.Items.Add(kucuk);
            cmbEbat.Items.Add(orta);
            cmbEbat.Items.Add(buyuk);
            cmbEbat.Items.Add(maxi);



            Pizza klassik = new Pizza { Adi = "Klasik", Fiyati = 14 };
            Pizza karisik = new Pizza { Adi = "Karisik", Fiyati = 17 };
            Pizza turkish = new Pizza { Adi = "Turkish", Fiyati = 19 };
            Pizza tuna = new Pizza { Adi = "Tuna", Fiyati = 18 };
            Pizza akdeniz = new Pizza { Adi = "Akdeniz", Fiyati = 21 };
            Pizza karadeniz = new Pizza { Adi = "Karadeniz", Fiyati = 22 };
            listPizzalar.Items.Add(klassik);
            listPizzalar.Items.Add(karisik);
            listPizzalar.Items.Add(turkish);
            listPizzalar.Items.Add(tuna);
            listPizzalar.Items.Add(akdeniz);
            listPizzalar.Items.Add(karadeniz);

            KenarTip ince = new KenarTip { Adi = "Ince Kenar", EkFiyat = 0 };
            rdbInceKenar.Tag = ince;
            KenarTip kalin = new KenarTip { Adi = "Kalin Kenar", EkFiyat = 3 };
            rdbKalinKenar.Tag = kalin;
        }
        Siparis s=null;
        private void btnHesapla_Click(object sender, EventArgs e)
        {

            Pizza p = (Pizza)listPizzalar.SelectedItem;
            p.Ebati = (Ebat)cmbEbat.SelectedItem;
            p.KenarTipi = rdbInceKenar.Checked ? (KenarTip)rdbInceKenar.Tag : (KenarTip)rdbKalinKenar.Tag;
            p.Malzemeler = new List<string>();
            foreach (CheckBox ctrl in groupBox1.Controls)
            {
                if (ctrl.Checked)
                {
                    p.Malzemeler.Add(ctrl.Text);
                }
            }
            decimal tutar = nudAdet.Value * p.Tutar;
            txtTutar.Text = tutar.ToString();
            s = new Siparis();
            s.Pizza = p;
            s.Adet = (int)nudAdet.Value;

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {

            ///listSepet.Items.Remove(listSepet.Items[0]);
            if (s != null)
            {
                listSepet.Items.Add(s);
            }

            cmbEbat.SelectedIndex = -1;
            listPizzalar.SelectedIndex = -1;
            rdbInceKenar.Checked = false;
            rdbKalinKenar.Checked = false;
            foreach (CheckBox c in groupBox1.Controls.OfType<CheckBox>())
            {
                c.Checked = false;
            }
        }


        private void btnSiparisiOnay_Click(object sender, EventArgs e)
        {
            decimal toplamTutar = 0;
            int adet = 0;
            foreach (Siparis spr in listSepet.Items)
            {
                toplamTutar += spr.Adet * spr.Pizza.Tutar;
                adet++;

            }
            lblToplamTutar.Text = toplamTutar.ToString();
            MessageBox.Show(string.Format("Toplam siparis adediniz: {0}{1} Toplam siparis tutariniz: {2}", adet, Environment.NewLine, toplamTutar));
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (listSepet.SelectedItems.Count > 0)
            {
                listSepet.Items.Remove(listSepet.SelectedItems[0]);
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (listSepet.Items.Count == 0)
            {
                MessageBox.Show("Lutfen duzenlenecek satri seciniz");
                return;
            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbEbat_SelectedIndexChanged(object sender, EventArgs e)
        {



        }


    }
}
