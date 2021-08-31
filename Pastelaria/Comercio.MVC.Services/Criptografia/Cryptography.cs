using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Comercio.MVC.Services.Criptografia
{
    public class Cryptography
    {
        // Atributo que irá receber um tipo de algoritmo de criptografia(hash) | Algoritmos: SHA512, MD5, RIPDEM160
        public HashAlgorithm Algorithm { get; set; }

        public Cryptography(HashAlgorithm algorithm)
        {
            Algorithm = algorithm;
        }

        public Cryptography()
        {
        }

        public string HashGenerate(string stringToBeEncrypted)
        {
            var encodedValue = Encoding.UTF8.GetBytes(stringToBeEncrypted);
            var passwordEncrypted = Algorithm.ComputeHash(encodedValue);

            StringBuilder sb = new StringBuilder();

            foreach (var caractere in passwordEncrypted)
            {
                sb.Append(caractere.ToString("X2"));
            }

            return sb.ToString();
        }

        public bool HashVerify(string senha1, string senha2)
        {
            if (string.IsNullOrEmpty(senha1) || string.IsNullOrEmpty(senha2))
            {
                throw new NullReferenceException("A string [stringstored] esta nula ou vazia.");
            }

            var hashsSenha1 = this.HashGenerate(senha1);
            var hashsSenha2 = this.HashGenerate(senha2);

            if (String.Equals(hashsSenha1, hashsSenha2)) return true;
            return false;
        }
    }
}
