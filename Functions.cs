using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Text.Json;

//файл для хранения функций, использующихся во любых файлах программы 
namespace Practica
{
    class Encryption { 
        public static string GetSHA256(string input)
        {
            return BitConverter.ToString(SHA256.Create().ComputeHash(Encoding.Default.GetBytes(input)));
        }
    }

    class Files
    {
        public static async void WriteUser(User user)
        {
            using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<User>(fs, user);
            }
        }

        public static User ReadUser()
        {
            User user;
            try {
                using (FileStream fs = new FileStream("user.json", FileMode.Open, FileAccess.Read))
                {
                    Byte[] data = new byte[fs.Length];
                    int dataToRead = (int)fs.Length;
                    int offset = 0;
                    while (dataToRead > 0)
                    {
                        fs.Read(data, offset, dataToRead);
                        if (dataToRead == 0) break;
                        offset++;
                        dataToRead--;
                    }
                    user = JsonSerializer.Deserialize<User>(data);
                }
            }
            catch(FileNotFoundException)
            {
                return null;
            }
            return user;
        }
    }
}