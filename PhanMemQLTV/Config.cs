using System;
using System.Text;
using System.Security.Cryptography;
using System.Data;

namespace PhanMemQLTV
{
    class Config
    {
        public static string chuoiKetNoi()
        {
            string chuoiKetNoi = "server =" + @"DESKTOP-2SOF2LM\MSSQLSERVER01; database = MHHDL_DoAnQLTV; integrated security = true";
            return chuoiKetNoi;
        }
        public static string md5_Hash(string text)
        {
            MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(text));
            StringBuilder hashSb = new StringBuilder();
            foreach (byte b in hash)
            {
                hashSb.Append(b.ToString("X2"));
            }
            return hashSb.ToString();
        }
        public static string tangMaTuDong(string role, DataTable myTable)
        {
            string maTuDong;
            if (myTable.Rows.Count <= 0)
            {
                if (role == "tt")
                    maTuDong = "TT000001";
                else if (role == "dg")
                    maTuDong = "DG000001";
                else if (role == "ms")
                    maTuDong = "MS000001";
                else
                    maTuDong = "MP000001";
            }
            else
            {
                int k;
                if (role == "tt")
                    maTuDong = "TT";
                else if (role == "dg")
                    maTuDong = "DG";
                else if (role == "ms")
                    maTuDong = "MS";
                else
                    maTuDong = "MP";
                k = Convert.ToInt32(myTable.Rows[myTable.Rows.Count - 1][0].ToString().Substring(2, 6));
                k = k + 1;
                if (k < 10)
                {
                    maTuDong = maTuDong + "00000";
                }
                else if (k < 100)
                {
                    maTuDong = maTuDong + "0000";
                }
                else if (k < 1000)
                {
                    maTuDong = maTuDong + "000";
                }
                else if (k < 10000)
                {
                    maTuDong = maTuDong + "00";
                }
                else if (k < 100000)
                {
                    maTuDong = maTuDong + "0";
                }
                maTuDong = maTuDong + k.ToString();
            }
            return maTuDong;
        }
    }
}
