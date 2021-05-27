using System;
using System.Text;
using System.Security.Cryptography;

//файл для хранения функций, использующихся во любых файлах программы 
namespace Practica
{
    class Encryption { 
        public static string GetSHA256(string input)
        {
            return BitConverter.ToString(SHA256.Create().ComputeHash(Encoding.Default.GetBytes(input)));
        }
    }
}