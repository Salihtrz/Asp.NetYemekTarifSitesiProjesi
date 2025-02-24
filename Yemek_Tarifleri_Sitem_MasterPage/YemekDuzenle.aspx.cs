using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Yemek_Tarifleri_Sitem_MasterPage
{
    public partial class YemekDuzenle : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();
        string id = "";
        private static string kategoriId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["YemekID"] == null ? string.Empty : Request.QueryString["YemekID"];

            if (Page.IsPostBack == false)
            {
                //Kategori Listesi
                SqlCommand komut2 = new SqlCommand("Select * from Tbl_Kategoriler", bgl.baglanti());
                SqlDataReader oku2 = komut2.ExecuteReader();

                DropDownList1.DataTextField = "KategoriAd"; //DropDown'ın içinde gözükecek olan alan
                DropDownList1.DataValueField = "KategoriID"; //Çalışan kategoriAd ın kategoriID sini arka planda tutar.

                DropDownList1.DataSource = oku2;
                DropDownList1.DataBind();
            }

            if (Page.IsPostBack == false)
            {
                SqlCommand komut = new SqlCommand("Select * from Tbl_Yemekler where YemekID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", id);
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    TextBox1.Text = oku[1].ToString();
                    TextBox2.Text = oku[2].ToString();
                    TextBox3.Text = oku[3].ToString();
                    kategoriId = oku[7].ToString();
                    DropDownList1.Items.FindByValue(kategoriId).Selected = true; //Dropdawn elemanlarından ilgili ID ye sahip elemanı bulur ve seçeli hale getirir.
                }
                bgl.baglanti().Close();


            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue != kategoriId)
            {
                //Kategori sayısını Azaltma
                SqlCommand komut = new SqlCommand("update Tbl_Kategoriler set KategoriAdet=KategoriAdet-1 where KategoriID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", kategoriId);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();

                SqlCommand komut4 = new SqlCommand("update Tbl_Yemekler set KategoriID=@p1 where YemekID=@p2", bgl.baglanti());
                komut4.Parameters.AddWithValue("@p1", DropDownList1.SelectedValue);
                komut4.Parameters.AddWithValue("@p2", id);
                komut4.ExecuteNonQuery();
                bgl.baglanti().Close();
                kategoriId = DropDownList1.SelectedValue;
            }

            //Kategori sayısını Arttırma
            SqlCommand komut3 = new SqlCommand("update Tbl_Kategoriler set KategoriAdet=KategoriAdet+1 where KategoriID=@p1", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", DropDownList1.SelectedValue);
            komut3.ExecuteNonQuery();
            bgl.baglanti().Close();

            //Seçilen resmin nereye kaydedileceği
            FileUpload1.SaveAs(Server.MapPath("/Resimler/" + FileUpload1.FileName));

            SqlCommand komut2 = new SqlCommand("update Tbl_Yemekler set YemekAd=@p1,YemekMalzeme=@p2,YemekTarif=@p3,KategoriID=@p4,YemekResim=@p5 where YemekID=@p6", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", TextBox1.Text);
            komut2.Parameters.AddWithValue("@p2", TextBox2.Text);
            komut2.Parameters.AddWithValue("@p3", TextBox3.Text);
            komut2.Parameters.AddWithValue("@p4", DropDownList1.SelectedValue);
            komut2.Parameters.AddWithValue("@p5", "~/Resimler/" + FileUpload1.FileName);
            komut2.Parameters.AddWithValue("@p6", id);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();


        }

        protected void Button2_Click(object sender, EventArgs e)
        {


            //Tüm Yemeklerin durumunu false yaptık
            SqlCommand komut = new SqlCommand("update Tbl_Yemekler set durum=0", bgl.baglanti());
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();

            //Günün yemeği için id ye göre durumu true yapalım
            SqlCommand komut2 = new SqlCommand("update Tbl_Yemekler set durum=1 where YemekID=@p1", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", id);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();


        }
    }
}