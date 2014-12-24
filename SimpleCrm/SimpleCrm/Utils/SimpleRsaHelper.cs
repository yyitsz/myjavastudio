using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace SimpleCrm.Utils
{
    public class SimpleRsaHelper
    {
        public static readonly string PUB_KEY = @"<RSAKeyValue><Modulus>x+k0u4f/zrTWO7ePk0ic66d3XSQM5f1SZelN7tFg4CzC7IZLVNGhgSrr4W083NFKspZ8n2InwAuxH8E0iwC+UugTb2J6P6hk4zalBlIBFWkWlCZEVfPB2/P9u45IM965KoV4kHv1FekAIBmcKWBacml0b6OH9I61XkLsqmGlkak=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
 
        public static string RSAEncryptWithPublicKey(string publicKey, string content)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            byte[] cipherbytes;
            rsa.FromXmlString(publicKey);
            cipherbytes = rsa.Encrypt(Encoding.UTF8.GetBytes(content), false);

            return Convert.ToBase64String(cipherbytes);
        }


        public static string RSADecrypWithPublicKey(string publicKey, string content)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            byte[] cipherbytes;
            rsa.FromXmlString(publicKey);
            byte[] bytes = Convert.FromBase64String(content);
            cipherbytes = rsa.PublicDecryption(bytes);

            return Encoding.UTF8.GetString(cipherbytes);
        }

    }
}
