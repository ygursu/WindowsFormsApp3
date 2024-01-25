using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    internal static class Program
    {
       
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

 

        SqlConnection baglanti;
    SqlDataReader dr;
    SqlCommand komut;
    Musteri m;
    ObservableCollection<Musteri> musteriler;

    

 public MainWindow()
    {
        InitializeComponent();
        baglanti = new SqlConnection("Data Source=.; Initial Catalog=ticaret; Integrated Security=true");
    }



public void Listele()
    {

        musteriler = new ObservableCollection<Musteri>();
        komut = new SqlCommand();
        komut.Connection = baglanti;
        komut.CommandText = "SELECT *FROM musteri";
        baglanti.Open();
        dr = komut.ExecuteReader();
        while (dr.Read())
        {
            m = new Musteri();
            m.No = (int)dr[0];
            m.Ad = dr[1].ToString();
            m.Soyad = dr[2].ToString();
            m.Tarih = (DateTime)dr[3];
            m.Telefon = dr[4].ToString();
            musteriler.Add(m);
        }
        baglanti.Close();
        lstMusteri.ItemsSource = musteriler;

    }



  private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        Listele();
    }



private void lstMusteri_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Musteri secilen = new Musteri();
        secilen = (Musteri)lstMusteri.SelectedItem;
        grd1.DataContext = secilen;
    }

   



 private void Button_Click(object sender, RoutedEventArgs e)
    {
        komut = new SqlCommand();
        komut.Connection = baglanti;
        komut.CommandText = "INSERT INTO musteri (ad,soyad,dtarih,tel) VALUES (@ad,@soyad,@tarih,@telefon)";
        komut.Parameters.AddWithValue("@ad", txtAd.Text);
        komut.Parameters.AddWithValue("@soyad", txtSoyad.Text);
        komut.Parameters.AddWithValue("@tarih", dp1.SelectedDate.Value);
        komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
        baglanti.Open();
        komut.ExecuteNonQuery();
        baglanti.Close();
        Listele();
    }

   

 
        private void Button_Click_3(object sender, RoutedEventArgs e)
    {
        komut = new SqlCommand();
        komut.Connection = baglanti;
        komut.CommandText = "UPDATE musteri SET ad=@ad,soyad=@soyad,dtarih=@tarih,tel=@telefon WHERE mno=@no";
        komut.Parameters.AddWithValue("@ad", txtAd.Text);
        komut.Parameters.AddWithValue("@soyad", txtSoyad.Text);
        komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
        komut.Parameters.AddWithValue("@tarih", dp1.SelectedDate.Value);
        komut.Parameters.AddWithValue("@no", txtNo.Text);
        baglanti.Open();
        komut.ExecuteNonQuery();
        baglanti.Close();
    }

   

 
        private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        komut = new SqlCommand();
        komut.Connection = baglanti;
        komut.CommandText = "DELETE FROM musteri WHERE mno=@no";
        komut.Parameters.AddWithValue("@no", txtNo.Text);
        baglanti.Open();
        komut.ExecuteNonQuery();
        baglanti.Close();
        Listele();
    }



 private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            List<Musteri> filtre = musteriler.Where(x => x.Ad.ToLower().Contains(txtAra.Text.ToLower())).ToList();
            lstMusteri.ItemsSource = filtre;
        }
        catch
        {

        }



namespace WpfClassVeri
    {
        public partial class MainWindow : Window
        {

            public MainWindow()
            {
                InitializeComponent();
                baglanti = new SqlConnection("Data Source=.; Initial Catalog=ticaret; Integrated Security=true");
            }
            SqlConnection baglanti;
            SqlDataReader dr;
            SqlCommand komut;
            Musteri m;
            ObservableCollection<Musteri> musteriler;

            public void Listele()
            {

                musteriler = new ObservableCollection<Musteri>();
                komut = new SqlCommand();
                komut.Connection = baglanti;
                komut.CommandText = "SELECT *FROM musteri";
                baglanti.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    m = new Musteri();
                    m.No = (int)dr[0];
                    m.Ad = dr[1].ToString();
                    m.Soyad = dr[2].ToString();
                    m.Tarih = (DateTime)dr[3];
                    m.Telefon = dr[4].ToString();
                    musteriler.Add(m);
                }
                baglanti.Close();
                lstMusteri.ItemsSource = musteriler;

            }

            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                Listele();
            }

            private void lstMusteri_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                Musteri secilen = new Musteri();
                secilen = (Musteri)lstMusteri.SelectedItem;
                grd1.DataContext = secilen;
            }

            private void Button_Click(object sender, RoutedEventArgs e)
            {
                komut = new SqlCommand();
                komut.Connection = baglanti;
                komut.CommandText = "INSERT INTO musteri (ad,soyad,dtarih,tel) VALUES (@ad,@soyad,@tarih,@telefon)";
                komut.Parameters.AddWithValue("@ad", txtAd.Text);
                komut.Parameters.AddWithValue("@soyad", txtSoyad.Text);
                komut.Parameters.AddWithValue("@tarih", dp1.SelectedDate.Value);
                komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                Listele();
            }

            private void Button_Click_1(object sender, RoutedEventArgs e)
            {
                Musteri m = new Musteri();
                grd1.DataContext = m;
            }

            private void Button_Click_2(object sender, RoutedEventArgs e)
            {
                komut = new SqlCommand();
                komut.Connection = baglanti;
                komut.CommandText = "DELETE FROM musteri WHERE mno=@no";
                komut.Parameters.AddWithValue("@no", txtNo.Text);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                Listele();

            }

            private void Button_Click_3(object sender, RoutedEventArgs e)
            {
                komut = new SqlCommand();
                komut.Connection = baglanti;
                komut.CommandText = "UPDATE musteri SET ad=@ad,soyad=@soyad,dtarih=@tarih,tel=@telefon WHERE mno=@no";
                komut.Parameters.AddWithValue("@ad", txtAd.Text);
                komut.Parameters.AddWithValue("@soyad", txtSoyad.Text);
                komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
                komut.Parameters.AddWithValue("@tarih", dp1.SelectedDate.Value);
                komut.Parameters.AddWithValue("@no", txtNo.Text);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
            }



            private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
            {
                try
                {
                    List<Musteri> filtre = musteriler.Where(x => x.Ad.ToLower().Contains(txtAra.Text.ToLower())).ToList();
                    lstMusteri.ItemsSource = filtre;
                }
                catch
                {

                }

            }


        }
    }
}
