using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Kiemtracuoiki
{
    internal class Program
    {
      
       

        public static int nhapso()
        {
            int x;
            while (true)
            {
                try { Console.WriteLine("nhap so : ");
                x=int.Parse(Console.ReadLine());
                    break;
                
                } catch (Exception ex){ Console.WriteLine("ko dung kieu du lieu"); }
                
            }
            return x;
        }
       
        public static Dictionary<string,DieuTraDS> nhapdulieu(int x)
        {
            Dictionary<string ,DieuTraDS> dic1=new Dictionary<string, DieuTraDS> ();
            for (int i = 0; i < x; i++)
            {
                try {
                    Console.WriteLine("nhap id:");
                    string id=Console.ReadLine();
                    if (id=="#")
                    {
                        break;
                    }
                    Console.WriteLine("nhap ten");
                    string ten =Console.ReadLine();
                    Console.WriteLine("nhap cccd");
                    string cccd=Console.ReadLine();
                    Console.WriteLine("nhap gioiitnh");
                    string gioitinh=Console.ReadLine();
                    Console.WriteLine("nhap  ngaysinh");
                    string ngaysinh=Console.ReadLine();

                    var vl = new DieuTraDS(id,ten,cccd,gioitinh,ngaysinh);
                    dic1.Add(id, vl);

                } catch(Exception ex) { Console.WriteLine("Loi "+ex); }
            }
            return dic1;
        }

        //public static void luudb(Dictionary<string, DieuTraDS> dic1)
        //{
        //    string ketnoi = "Data Source=DESKTOP-MI1NE8C\\SQLEXPRESS;Initial Catalog=DieuTraDS;Integrated Security=True;TrustServerCertificate=True";
        //    SqlConnection conn = new SqlConnection();
        //    SqlCommand cmd = new SqlCommand();
        //    using (conn = new SqlConnection(ketnoi))
        //    {
        //        foreach (var cc in dic1)
        //        {
        //            conn.Open();

        //            try
        //            {
        //                cmd = conn.CreateCommand();
        //                cmd.CommandText = "insert into CongDan (MaCD,TenCD,CCCD,GioiTinh,NgaySinh) values(@id,@name,@cccd,@gioitinh,@ngaysinh)";
        //                cmd.Parameters.AddWithValue("@id", +cc.Val);

        //            }
        //            catch { }
        //            finally { }
        //        }


        //    }

       public static   void luudatabase(Dictionary<string ,DieuTraDS> dic)
        {
            string querry = "Data Source=DESKTOP-MI1NE8C\\SQLEXPRESS;Initial Catalog=DieuTraDS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            using (conn=new SqlConnection(querry))
            {
                foreach (var item in dic)
                {
                    try {
                    conn.Open();
                        cmd=conn.CreateCommand();
                        cmd.CommandText = "insert into CongDan (MaCD,TenCD,CCCD,GioiTinh,NgaySinh) values (@id,@name,@cccd,@gioitinh,@ngaysinh) ";
                        cmd.Parameters.AddWithValue("@id",item.Value.macd);
                        cmd.Parameters.AddWithValue("@name",item.Value.tencd);
                        cmd.Parameters.AddWithValue("@cccd",item.Value.cccd);
                        cmd.Parameters.AddWithValue("@gioitinh",item.Value.gioitinh);
                        cmd.Parameters.AddWithValue("@ngaysinh",item.Value.ngaysinh);
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("luu vao database thanh cong ");
                    } catch (Exception ex){ Console.WriteLine("ko luu dc vao database",ex); } finally { if (conn.State==ConnectionState.Open) {
                            conn.Close();                         
} }
                }

            }


        }
  

        static void Main(string[] args)
        {
            int x=nhapso();
            Dictionary<string, DieuTraDS> Congdan1 = nhapdulieu(x);

            luudatabase(Congdan1);


        }
    }
}
