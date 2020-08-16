using System;
using System.IO;
using System.Net;
using System.Text;

namespace AsOne
{
    class Program
    {
        public static void Main()
        {
            WebClient wctd = new WebClient();
            wctd.DownloadFile(
              "https://www.data.jma.go.jp/obd/stats/data/mdrr/pre_rct/alltable/pre1h00_rct.csv",
              "pre01.csv");

            string filePath = @"pre01.csv";
            StreamReader reader = new StreamReader(filePath, Encoding.GetEncoding("shift_jis"));

            while (reader.Peek() >= 0)
            {
                StreamWriter sw = new StreamWriter(
                "tenki.txt",
                true,
                Encoding.UTF8);

                Console.SetOut(sw);
                string[] cols = reader.ReadLine().Split(',');
                for (int n = 0; n < cols.Length; n++)
                    Console.Write(cols[n] + "\t");
                Console.WriteLine("");
                sw.Dispose(); 
            }
            reader.Close();
        }
    }
}
