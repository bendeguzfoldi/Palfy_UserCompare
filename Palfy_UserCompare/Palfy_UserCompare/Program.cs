using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Palfy_UserCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] users = File.ReadAllLines("users.csv");
            string[] nevsor = File.ReadAllLines("nevsor.csv");
            string[] nevsor_nevek = nevsor_nevgenerator(nevsor);
            //string[] users_nevek = users_nevgenerator(users);
            for (int i = 0; i < users.Length; i++)
            {
                string[] users_temp = users[i].Split(';');
                string users_nev = users_temp[0] + " " + users_temp[1];
                int k = 0;
                while (k<nevsor.Length&&users_nev !=nevsor_nevek[k])
                {
                    k++;
                }
                bool exist = k < nevsor.Length;
                if (!exist)
                {
                    Console.WriteLine(users_nev + " " + users_temp[2]);
                }
                
            }
            Console.ReadLine();
        }
        //static string[] users_nevgenerator(string[] users)
        //{
        //    string[] ret = new string[users.Length];
        //    for (int i = 0; i < users.Length; i++)
        //    {
        //        string[] temp = users[i].Split(';');
        //        ret[i] = ret[i] + temp[0] + " " + temp[1];

        //    }
        //    return ret;
        //}
        static string[] nevsor_nevgenerator(string[] nevsor)
        {
            string[] ret = new string[nevsor.Length];
            for (int i = 0; i < nevsor.Length; i++)
            {
                string[] temp = nevsor[i].Split(';');
                ret[i] = ret[i] + temp[0] + " " + temp[1];

            }
            return ret;
        }
    }
}
