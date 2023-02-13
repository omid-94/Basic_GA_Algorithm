using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Basic_GA_Algorithm
{
    public class Helper
    {
        private static Random _randomGenerator = new Random(DateTime.Now.Millisecond);
        public static int RandomNumber(int start, int end)
        {
            int randomNumber = _randomGenerator.Next(start, end + 1);
            return randomNumber;
        }
        public static char MutatedGenes()
        {
            int len = BaseInfo.Genes.Length;
            int r = RandomNumber(0, len - 1);
            return BaseInfo.Genes[r];
        }
        public static string CreateGnome()
        {
            int len = BaseInfo.Target.Length;
            string gnome = "";
            for (int i = 0; i < len; i++)
                gnome += MutatedGenes();
            return gnome;
        }
    }
}
