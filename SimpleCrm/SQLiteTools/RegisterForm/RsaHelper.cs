using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace SQLiteTools.RegisterForm
{
    public class RsaHelper
    {
        public static string PUB_KEY = @"<RSAKeyValue><Modulus>x+k0u4f/zrTWO7ePk0ic66d3XSQM5f1SZelN7tFg4CzC7IZLVNGhgSrr4W083NFKspZ8n2InwAuxH8E0iwC+UugTb2J6P6hk4zalBlIBFWkWlCZEVfPB2/P9u45IM965KoV4kHv1FekAIBmcKWBacml0b6OH9I61XkLsqmGlkak=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        public static string PRI_KEY = @"<RSAKeyValue><Modulus>x+k0u4f/zrTWO7ePk0ic66d3XSQM5f1SZelN7tFg4CzC7IZLVNGhgSrr4W083NFKspZ8n2InwAuxH8E0iwC+UugTb2J6P6hk4zalBlIBFWkWlCZEVfPB2/P9u45IM965KoV4kHv1FekAIBmcKWBacml0b6OH9I61XkLsqmGlkak=</Modulus><Exponent>AQAB</Exponent><P>6tlodE7F7yN75JhS6gY2X+QOMYxTOunYTx29Ae2KZahGll6ycZy4EwaxGSF2Aoh5HuLtQtDTjHv14me2RTtWOw==</P><Q>2epGRchNoYkiT+TZiLIL4YsYb7musx6ilarb/y1R6LDIUEG4xnml8RnjD7OlCquyLRgvBoEXqPlNm6D++wYlaw==</Q><DP>qm0BDz5HB2aBtv8PVIMTnHy8DBrgH2WpsqhLDAYco+784oxwBGCNeEkn5avRnr743oAhW5Z9nnoqkpVewVjxFw==</DP><DQ>PGBqo/8Bc1Y5iYVQuE0Meas+VAZQXxSH24wBdEwsO5pvhb0P4v3lek2/2aPegHxd25ytutGdqpWYaRxMSWTEjQ==</DQ><InverseQ>rIU2F9BUXU5N7knu0+ZMVCGwwN589ha7YnMza5Dg5VF3k/uHk5prVA21+zNBrEbBLmDqav5BJiobKwuNtkOy7A==</InverseQ><D>DmtEsW4KxmcGuMHxqibnopuuoVozT/dolQ8x3tLdUO4JlTPOhSyloIJvBxBw/mBeKeluzbQvt8tgGDFAT/Jax9FrNDMxDAId+WRBaZaQUyKeEekwyvCqwVRuebKDHbi9JeDcKDvv+YWZlidkxCS9Mw3uLVPpZ903IXcoFgs1g90=</D></RSAKeyValue>";

        public static string RSAEncryptWithPublicKey(string publicKey, string content)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            byte[] cipherbytes;
            rsa.FromXmlString(publicKey);
            cipherbytes = rsa.Encrypt(Encoding.UTF8.GetBytes(content), false);

            return Convert.ToBase64String(cipherbytes);
        }

        public static string RSADecrypWithPrivateKey(string privateKey, string content)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            byte[] cipherbytes;
            rsa.FromXmlString(privateKey);
            byte[] bytes = Convert.FromBase64String(content);
            cipherbytes = rsa.Decrypt(bytes, false);

            return Encoding.UTF8.GetString(cipherbytes);
        }

        public static string RSAEncryptWithPrivateKey(string privateKey, string content)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            byte[] cipherbytes;
            rsa.FromXmlString(privateKey);
            cipherbytes = rsa.PrivareEncryption(Encoding.UTF8.GetBytes(content));

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

        public static Tuple<String, string> GenRSAKey()
        {
            RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
            String pri = provider.ToXmlString(true);
            string pub = provider.ToXmlString(false);

            return Tuple.Create(pri, pub);

        }
    }
}
