using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Yemek_Tarifleri_Sitem_MasterPage
{
    public partial class TarifOnerDetay : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();
        string id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["TarifID"];

            if (Page.IsPostBack == false)
            {
                SqlCommand komut = new SqlCommand("Select * from Tbl_Tarifler where TarifId=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", id);
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    TextBox1.Text = oku[1].ToString();
                    TextBox2.Text = oku[2].ToString();
                    TextBox3.Text = oku[3].ToString();
                    TextBox4.Text = oku[5].ToString();
                    TextBox5.Text = oku[6].ToString();

                }
                bgl.baglanti().Close();
                                
                    //Kategori Listesi
                    SqlCommand komut2 = new SqlCommand("Select * from Tbl_Kategoriler", bgl.baglanti());
                    SqlDataReader oku2 = komut2.ExecuteReader();

                    DropDownList1.DataTextField = "KategoriAd"; //DropDown'ın içinde gözükecek olan alan
                    DropDownList1.DataValueField = "KategoriID"; //Çalışan kategoriAd ın kategoriID sini arka planda tutar.

                    DropDownList1.DataSource = oku2;
                    DropDownList1.DataBind();              
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            
                //Durum Güncelleme
                SqlCommand komut = new SqlCommand("update Tbl_Tarifler set TarifDurum=1 where TarifID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", id);
                SqlDataReader oku = komut.ExecuteReader();
                bgl.baglanti().Close();

                //Yemeği Ana Sayfaya Ekleme
                SqlCommand komut2 = new SqlCommand("insert into Tbl_Yemekler (YemekAd,YemekMalzeme,YemekTarif,KategoriID) values (@p1,@p2,@p3,@p4)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", TextBox1.Text);
                komut2.Parameters.AddWithValue("@p2", TextBox2.Text);
                komut2.Parameters.AddWithValue("@p3", TextBox3.Text);
                komut2.Parameters.AddWithValue("@p4", DropDownList1.SelectedValue);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
            
        }
    }
}