﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace satis_uygulamasi
{
    public partial class navigasyon : Form
    {
        public navigasyon()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=satis_uygulamasi; user Id=postgres; password=031199");
        private void listele_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from navigasyon";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void ekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand ekle1 = new NpgsqlCommand("insert into navigasyon(parcamarka,parcamodel,navboyut,navbellek,navfiyat,uretimtarihi,aracid) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", baglanti);
            ekle1.Parameters.AddWithValue("@p1", navMarka.Text);
            ekle1.Parameters.AddWithValue("@p2", navModel.Text);
            ekle1.Parameters.AddWithValue("@p3", int.Parse(navBoyut.Text));
            ekle1.Parameters.AddWithValue("@p4", int.Parse(navBellek.Text));
            ekle1.Parameters.AddWithValue("@p5", int.Parse(navFiyat.Text));
            ekle1.Parameters.AddWithValue("@p6", int.Parse(navTarih.Text));
            ekle1.Parameters.AddWithValue("@p7", int.Parse(aracID.Text));
            ekle1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ekleme Başarılı");
        }

        private void sil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand sil1 = new NpgsqlCommand("delete from navigasyon where aracparcaid=@p1", baglanti);
            sil1.Parameters.AddWithValue("@p1", int.Parse(aracParca.Text));
            sil1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Parça Silindi");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            satici Satici = new satici();
            Satici.Show();
            this.Close();
        }
    }
}
