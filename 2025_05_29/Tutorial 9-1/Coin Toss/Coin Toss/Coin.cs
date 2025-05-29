using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Coin_Toss
{
    internal class Coin
    {
        private string sideUp; // 硬幣正面
        Random rand = new Random();// 隨機數生成器


        public Coin()
        {
            sideUp = "正面"; // 預設硬幣正面為"正面"
        }

        public void Toss()
        {
            // 擲硬幣，隨機選擇"正面"或"反面"
            if (rand.Next(2) == 0)
            {
                sideUp = "正面";
            }
            else
            {
                sideUp = "反面";
            }


        }
        public string GetSideUp()
        {
            // 返回當前硬幣正面
            return sideUp;
        }
    }


}
