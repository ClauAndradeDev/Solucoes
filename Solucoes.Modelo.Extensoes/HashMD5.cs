using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Extensoes
{
    public static class HashMD5
    {
        //public static string GerarHashMd5(string input)
        //{
        //    MD5 md5Hash = MD5.Create();
        //    // Converter a String para array de bytes, que é como a biblioteca trabalha.
        //    byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

        //    // Cria-se um StringBuilder para recompôr a string.
        //    StringBuilder sBuilder = new StringBuilder();

        //    // Loop para formatar cada byte como uma String em hexadecimal
        //    for (int i = 0; i < data.Length; i++)
        //    {
        //        sBuilder.Append(data[i].ToString("x2"));
        //    }

        //    return sBuilder.ToString();
        //}

        public static string RetornarMD5(string Senha)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                return RetonarHash(md5Hash, Senha);
            }
        }

        public static bool ComparaMD5(string senhabanco, string Senha_MD5)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                var senha = RetornarMD5(senhabanco);
                if (VerificarHash(md5Hash, Senha_MD5, senha))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private static string RetonarHash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        private static bool VerificarHash(MD5 md5Hash, string input, string hash)
        {
            StringComparer compara = StringComparer.OrdinalIgnoreCase;

            if (0 == compara.Compare(input, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
