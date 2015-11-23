using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
namespace WindowsFormsApplication3
{
    class oracle
    {
         private static  OracleConnection conn;

        //创建oracle连接
        public static void LinkToOracle(String arg_SID, String arg_user, String arg_passward)
        {
            String linkstart = "Data source=" + arg_SID + "; User ID=" + arg_user + "; Password=" + arg_passward;
          
            try
            {
                conn = new OracleConnection(linkstart);
                conn.Open();
                Console.WriteLine("连接成功");
             
            }
            catch (Exception e)
            {
                Console.WriteLine("连接失败" + e.Message);
            }
          
        }

        //关闭连接
        public static  void LinkClose()
        {
            conn.Close();
            Console.WriteLine("关闭连接");
        }

        public static OracleConnection getConnection()
        {
            return conn;
        }
    
    }

    }

