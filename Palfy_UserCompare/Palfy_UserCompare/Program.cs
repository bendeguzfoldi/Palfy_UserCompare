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
            for (int i = 0; i < users.Length; i++)
            {
                string[] users_temp = users[i].Split(';');
                string users_lastname = users_temp[0];
                string[] firstname_temp = users_temp[1].Split(' ');
                string users_firstname = firstname_temp[0];
                string users_nev = kisbetusit(users_lastname) + " " + kisbetusit(users_firstname);

                int k = 0;
                while (k < nevsor.Length && users_nev != kisbetusit(nevsor_nevek[k]))
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
                string lastname = temp[0];
                string[] firstname_temp = temp[1].Split(' ');
                string firstname = firstname_temp[0];
                ret[i] = lastname + " " + firstname;

            }
            return ret;
        }
        static string kisbetusit (string nev)
        {
            string nevkicsi = nev.ToLower();
            string ret = string.Empty;
            for (int i = 0; i < nevkicsi.Length; i++)
            {
                char tmp = nevkicsi[i];
                switch (tmp)
                {
                    case 'á':
                        ret += 'a';
                        break;
                    case 'é':
                        ret += 'e';
                        break;
                    case 'í':
                        ret += 'i';
                        break;
                    case 'ó':
                        ret += 'o';
                        break;
                    case 'ö':
                        ret += 'o';
                        break;
                    case 'ő':
                        ret += 'o';
                        break;
                    case 'ú':
                        ret += 'u';
                        break;
                    case 'ü':
                        ret += 'u';
                        break;
                    case 'ű':
                        ret += 'u';
                        break;
                    default:
                        ret += tmp;
                        break;
                }
            }
            return ret;
        }
    }
}
