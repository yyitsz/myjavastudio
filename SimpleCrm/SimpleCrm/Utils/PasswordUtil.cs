using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace SimpleCrm.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public class PasswordUtil
    {

        public static String getKey()
        {
            return "&**98)(";
        }


        /// <summary>
        /// Encrypts the specified plain password.
        /// </summary>
        /// <param name="plainPassword">The plain password.</param>
        /// <returns></returns>
        public static String Encrypt(String plainPassword)
        {

            if (plainPassword == null) return null;

            String encrptedPassword = "";

            for (int i = 0; i < plainPassword.Length; i++)
            {

                int encAsc = (int)plainPassword[i] + i + 2;

                encrptedPassword = encrptedPassword + (char)encAsc;

            }

            return encrptedPassword;

        }



        /// <summary>
        /// Decrypts the specified encrpted password.
        /// </summary>
        /// <param name="encrptedPassword">The encrpted password.</param>
        /// <returns></returns>
        public static String Decrypt(String encrptedPassword)
        {

            if (encrptedPassword == null) return null;

            String plainPassword = "";

            for (int i = 0; i < encrptedPassword.Length; i++)
            {

                int decAsc = (int)encrptedPassword[i] - (i + 2);

                plainPassword = plainPassword + (char)decAsc;

            }

            return plainPassword;

        }


        public static byte[] XorEncrypt(String message, String key)
        {

            byte[] keys = Encoding.UTF8.GetBytes(key);
            byte[] msgByte = Encoding.UTF8.GetBytes(message);

            int msgLen = msgByte.Length;
            int keyLen = keys.Length;
            byte[] result = new byte[msgLen];

            for (int i = 0; i < msgLen; i++)
            {
                result[i] = (byte)(msgByte[i] ^ keys[i % keyLen]);
            }
            return result;

        }

        public static String XorDecrypt(byte[] msgByte, String key)
        {
            byte[] keys = Encoding.UTF8.GetBytes(key);
            int msgLen = msgByte.Length;
            int keyLen = keys.Length;
            byte[] result = new byte[msgLen];

            for (int i = 0; i < msgLen; i++)
            {
                result[i] = (byte)(msgByte[i] ^ keys[i % keyLen]);
            }
            return Encoding.UTF8.GetString(result);

        }

        public static String XorEncryptString(String message, String key)
        {
            byte[] result = XorEncrypt(message, key);
            return Convert.ToBase64String(result);
        }

        public static String XorDecryptString(String message, String key)
        {
            byte[] msgByte = Convert.FromBase64String(message);
            return XorDecrypt(msgByte, key);
        }

        public static String XorEncryptString(String message)
        {
            byte[] result = XorEncrypt(message, getKey());
            return Convert.ToBase64String(result);
        }
    }

}
