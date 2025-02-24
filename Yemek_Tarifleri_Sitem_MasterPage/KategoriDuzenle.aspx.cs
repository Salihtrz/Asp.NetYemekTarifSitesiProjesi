using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Yemek_Tarifleri_Sitem_MasterPage
{
    public partial class KategoriAdminDetay : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();
        string kategoriID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            kategoriID = Request.QueryString["kategoriID"];/*Sayfa yüklendiği zaman diğer formdan gelen kategoriID adlı değişkeni bu değişkenin içine ata. */
            if(Page.IsPostBack == false) { //Sayfayı yeniden yükleme, Bir kere yüklediğin zaman o halini al üstüne bir şey yapma demek
            SqlCommand komut = new SqlCommand("Select * from Tbl_Kategoriler where KategoriID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", kategoriID);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read()) 
            {
                TextBox1.Text = oku[1].ToString();
                TextBox2.Text = oku[2].ToString();
            }
            bgl.baglanti().Close();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("update Tbl_Kategoriler set KategoriAd=@p1, KategoriAdet=@p2 where KategoriID = @p3", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", TextBox1.Text);
            komut2.Parameters.AddWithValue("@p2", TextBox2.Text);
            komut2.Parameters.AddWithValue("@p3", kategoriID);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
        }
    }
}