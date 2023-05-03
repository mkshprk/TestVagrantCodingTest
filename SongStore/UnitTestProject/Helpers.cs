using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    public static class Helpers
    {
        private static Random _rnd = new Random();
        public static string GetSongName() => $"Song_{_rnd.Next(1,100)}";

        public static string GetUserName() => $"User_{_rnd.Next(1, 100)}";
    }
}
