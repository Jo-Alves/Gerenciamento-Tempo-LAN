using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace GerenciamentoTempoLan
{ 
    public static class ClassSecurityPassword
    {
        public static string Pass(string Pass)
        {
            SHA1CryptoServiceProvider sp = new SHA1CryptoServiceProvider();
            sp.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Pass));
            byte[] ps = sp.Hash;
            StringBuilder sb = new StringBuilder();
            foreach(byte b in ps)
            {
                sb.Append(b.ToString());
            }
            return sb.ToString();
        }
    }
}
