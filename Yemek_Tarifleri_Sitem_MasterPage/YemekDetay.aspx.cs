using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Yemek_Tarifleri_Sitem_MasterPage
{
    public partial class YemekDetay : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();
        string yemekID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            yemekID = Request.QueryString["yemekID"]; /*Sayfa yüklendiği zaman diğer formdan gelen yemekID adlı değişkeni bu değişkenin içine ata. */

            SqlCommand komut = new SqlCommand("Select YemekAd from Tbl_Yemekler where yemekID = @p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", yemekID); /*Değişkeni yemeklerle ilişkilendir. */
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                Label3.Text = oku[0].ToString();
            }
            bgl.baglanti().Close();
            
            //Yorumları Listeleme
            SqlCommand komut2 = new SqlCommand("Select * from Tbl_Yorumlar where yemekID=@p2", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p2", yemekID);
            SqlDataReader oku2 = komut2.ExecuteReader();
            DataList2.DataSource = oku2;
            DataList2.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut3 = new SqlCommand("insert into Tbl_Yorumlar(YorumAdSoyad,YorumMail,Yorumicerik,yemekID) values (@t1,@t2,@t3,@t4)", bgl.baglanti());
            komut3.Parameters.AddWithValue("@t1", TextBox1.Text);
            komut3.Parameters.AddWithValue("@t2", TextBox2.Text);
            komut3.Parameters.AddWithValue("@t3", TextBox3.Text);
            komut3.Parameters.AddWithValue("@t4", yemekID);
            komut3.ExecuteNonQuery();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            Response.Write("<script> alert ('Yorumunuz yapılmıştır.') </script>");
            bgl.baglanti().Close();
        }
    }
}