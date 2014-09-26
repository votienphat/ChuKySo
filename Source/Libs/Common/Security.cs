using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Common
{
    public class Security
    {
        #region Base 64 by key

        /// <summary>
        /// Mã hóa chuỗi với định dạng Base64, có key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string EncryptBase64ByKey(string key, string content)
        {
            var toEncryptArray = Encoding.UTF8.GetBytes(content);
            var hashmd5 = new MD5CryptoServiceProvider();
            var keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(key));
            var tdes = new TripleDESCryptoServiceProvider { Key = keyArray, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 };
            var cTransform = tdes.CreateEncryptor();
            var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        /// Giải mã chuỗi có định dạng Base64, có key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string DecryptBase64ByKey(string key, string content)
        {
            var toEncryptArray = Convert.FromBase64String(content);
            var hashmd5 = new MD5CryptoServiceProvider();
            var keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(key));
            var tdes = new TripleDESCryptoServiceProvider { Key = keyArray, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 };
            var cTransform = tdes.CreateDecryptor();
            var resultArray = cTransform.TransformFinalBlock(
            toEncryptArray, 0, toEncryptArray.Length);
            return Encoding.UTF8.GetString(resultArray);
        }

        #endregion

        #region Mã hóa và giải mã
        /// <summary>
        /// Ma hoa mot chuoi
        /// </summary>
        /// <param name="key"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Encode(string key, string text)
        {
            byte[] data = Encoding.UTF8.GetBytes(key + text);
            var myEncoder = new Encode(data);
            var sb = new StringBuilder();

            sb.Append(myEncoder.GetEncoded());

            return sb.ToString();
        }

        /// <summary>
        /// Giai ma mot chuoi
        /// </summary>
        /// <param name="key"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Decode(string key, string text)
        {
            char[] data = text.ToCharArray();
            var myDecoder = new Decode(data);
            var sb = new StringBuilder();

            byte[] temp = myDecoder.GetDecoded();
            sb.Append(Encoding.UTF8.GetChars(temp));

            return sb.ToString().Substring(key.Length);
        }
        #endregion

        /// <summary>
        /// Sign data
        /// </summary>
        /// <param name="certFilePath"></param>
        /// <param name="password"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SignData(string certFilePath, string password, string value)
        {
            var sha1 = new SHA1CryptoServiceProvider();
            var x509Cert = new X509Certificate2(certFilePath, password, X509KeyStorageFlags.MachineKeySet);
            var rsaCryptoIPT = x509Cert.PrivateKey as RSACryptoServiceProvider;

            if (rsaCryptoIPT != null)
                return Convert.ToBase64String(rsaCryptoIPT.SignData(Encoding.UTF8.GetBytes(value), sha1));

            return string.Empty;
        }

        /// <summary>
        /// Sign data
        /// </summary>
        /// <param name="certFilePath">Path of cert file</param>
        /// <param name="password"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string SignData(string certFilePath, string password, params object[] values)
        {
            return SignData(certFilePath, password, String.Concat(values));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="certFilePath"></param>
        /// <param name="password"></param>
        /// <param name="separate"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string SignDataWithSeparate(string certFilePath, string password, object separate, params object[] values)
        {
            return SignData(certFilePath, password, AddSeparate(separate, values));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="certFilePath"></param>
        /// <param name="password"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string EncryptData(string certFilePath, string password, string value)
        {
            // Our bytearray to hold all of our data after the encryption
            var cert = new X509Certificate2(certFilePath, password, X509KeyStorageFlags.MachineKeySet);
            byte[] plainbytes = Encoding.UTF8.GetBytes(value);

            using (var rsa = (RSACryptoServiceProvider)cert.PublicKey.Key)
            {
                try
                {
                    // by default this will create a 128 bits AES (Rijndael) object
                    SymmetricAlgorithm sa = SymmetricAlgorithm.Create();
                    ICryptoTransform ct = sa.CreateEncryptor();
                    byte[] encrypt = ct.TransformFinalBlock(plainbytes, 0, plainbytes.Length);

                    var fmt = new RSAPKCS1KeyExchangeFormatter(rsa);
                    byte[] keyex = fmt.CreateKeyExchange(sa.Key);

                    // return the key exchange, the IV (public) and encrypted data
                    var result = new byte[keyex.Length + sa.IV.Length + encrypt.Length];
                    Buffer.BlockCopy(keyex, 0, result, 0, keyex.Length);
                    Buffer.BlockCopy(sa.IV, 0, result, keyex.Length, sa.IV.Length);
                    Buffer.BlockCopy(encrypt, 0, result, keyex.Length + sa.IV.Length, encrypt.Length);
                    return Convert.ToBase64String(result);

                }
                finally
                {
                    // Clear the RSA key container, deleting generated keys.
                    rsa.PersistKeyInCsp = false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="certFilePath"></param>
        /// <param name="password"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string EncryptData(string certFilePath, string password, params object[] values)
        {
            return EncryptData(certFilePath, password, String.Concat(values));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="certFilePath"></param>
        /// <param name="password"></param>
        /// <param name="separate"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string EncryptDataWithSeparate(string certFilePath, string password, object separate, params object[] values)
        {
            return EncryptData(certFilePath, password, AddSeparate(separate, values));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="certFilePath"></param>
        /// <param name="password"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string DecryptData(string certFilePath, string password, string value)
        {
            var cert = new X509Certificate2(certFilePath, password, X509KeyStorageFlags.MachineKeySet);

            var rsaCSP = (RSACryptoServiceProvider)cert.PrivateKey;
            byte[] cipherbytes = Convert.FromBase64String(value);

            // by default this will create a 128 bits AES (Rijndael) object
            SymmetricAlgorithm sa = SymmetricAlgorithm.Create();

            var keyex = new byte[rsaCSP.KeySize >> 3];
            Buffer.BlockCopy(cipherbytes, 0, keyex, 0, keyex.Length);

            var def = new RSAPKCS1KeyExchangeDeformatter(rsaCSP);
            byte[] key = def.DecryptKeyExchange(keyex);

            var iv = new byte[sa.IV.Length];
            Buffer.BlockCopy(cipherbytes, keyex.Length, iv, 0, iv.Length);

            ICryptoTransform ct = sa.CreateDecryptor(key, iv);
            byte[] decrypt = ct.TransformFinalBlock(cipherbytes, keyex.Length + iv.Length, cipherbytes.Length - (keyex.Length + iv.Length));
            return Encoding.UTF8.GetString(decrypt);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="certFilePath"></param>
        /// <param name="password"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string DecryptData(string certFilePath, string password, params object[] values)
        {
            return DecryptData(certFilePath, password, String.Concat(values));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="certFilePath"></param>
        /// <param name="password"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string EncryptData1024(string certFilePath, string password, string value)
        {
            //Lay thong tin cert tu tap tin
            var cert = new X509Certificate2(certFilePath, password, X509KeyStorageFlags.MachineKeySet);

            //Ma hoa chuoi
            var rsaPublicKey = (RSACryptoServiceProvider)cert.PublicKey.Key;
            byte[] plainbytes = Encoding.UTF8.GetBytes(value);
            byte[] cipherbytes = rsaPublicKey.Encrypt(plainbytes, false);

            return Convert.ToBase64String(cipherbytes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="certFilePath"></param>
        /// <param name="password"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string EncryptData1024(string certFilePath, string password, params object[] values)
        {
            return EncryptData1024(certFilePath, password, String.Concat(values));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="certFilePath"></param>
        /// <param name="password"></param>
        /// <param name="separate"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string EncryptData1024WithSeparate(string certFilePath, string password, object separate, params object[] values)
        {
            return EncryptData1024(certFilePath, password, AddSeparate(separate, values));
        }

        /// <summary>
        /// Gia ma du lieu 1024 bit
        /// </summary>
        /// <returns></returns>
        public static string DecryptData1024(string certFilePath, string password, string strEncryptData)
        {
            var cert = new X509Certificate2(certFilePath, password, X509KeyStorageFlags.MachineKeySet);

            //Kiem tra lai chuoi da ma hoa
            var rsaCSP = (RSACryptoServiceProvider)cert.PrivateKey;
            byte[] cipherbytes = Convert.FromBase64String(strEncryptData);
            byte[] plainbytes = rsaCSP.Decrypt(cipherbytes, false);
            return Encoding.UTF8.GetString(plainbytes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="certFilePath"></param>
        /// <param name="password"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string DecryptData1024(string certFilePath, string password, params object[] values)
        {
            return DecryptData1024(certFilePath, password, String.Concat(values));
        }

        /// <summary>
        /// Encrypt MD5
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string EncryptMD5(string value)
        {
            MD5 md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(value));

            return Convert.ToBase64String(data);
        }

        /// <summary>
        /// Encrypt MD5
        /// </summary>
        /// <returns></returns>
        public static string EncryptMD5(params object[] values)
        {
            return EncryptMD5(String.Concat(values));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="separate"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string EncryptMD5WithSeparate(object separate, params object[] values)
        {
            return EncryptMD5(AddSeparate(separate, values));
        }

        /// <summary>
        /// Mã hóa Md5 dạng base
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Md5(string value)
        {
            MD5 md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(value));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        /// <summary>
        /// Mã hóa Md5 dạng base
        /// </summary>
        /// <returns></returns>
        public static string Md5(params object[] values)
        {
            return Md5(String.Concat(values));
        }

        /// <summary>
        /// Mã hóa Md5 dạng base
        /// </summary>
        /// <param name="separate"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string Md5WithSeparate(object separate, params object[] values)
        {
            return Md5(AddSeparate(separate, values));
        }

        public static int RandomNumber(int min, int max)
        {
            var rd = new Random();
            if (max < min)
            {
                return rd.Next(max, min);
            }
            return rd.Next(min, max);

        }

        public static string RandomString(int size, bool lowerCase)
        {
            var builder = new StringBuilder();
            var random = new Random();
            for (int i = 0; i < size; i++)
            {
                char ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        /// <summary>
        /// Add separate between items
        /// </summary>
        /// <param name="separate">A char or string for seperation</param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static object[] AddSeparate(object separate, params object[] values)
        {
            var newValues = new List<object>();
            foreach (var value in values)
            {
                newValues.Add(value);
                newValues.Add(separate);
            }

            if (newValues.Count > 0)
            {
                newValues.RemoveAt(newValues.Count - 1);
            }

            return newValues.ToArray();
        }

        #region Base64
        /// <summary>
        /// Encrypts string to encrypt without key.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string EncryptBase64(string value)
        {
            byte[] data = Encoding.UTF8.GetBytes(value);
            var myEncoder = new Base64Encoder(data);
            var sb = new StringBuilder();

            sb.Append(myEncoder.GetEncoded());
            return sb.ToString();
        }

        /// <summary>
        /// Encrypts string to encrypt has key.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string EncryptBase64(string key, string value)
        {
            return EncryptBase64(String.Concat(key, value));
        }

        /// <summary>
        /// Decrypt
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string DecryptBase64(string value)
        {
            char[] data = value.ToCharArray();
            var myDecoder = new Base64Decoder(data);
            var sb = new StringBuilder();

            byte[] temp = myDecoder.GetDecoded();
            sb.Append(Encoding.UTF8.GetChars(temp));

            return sb.ToString();
        }

        /// <summary>
        /// Decrypts string to encrypt has key.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string DecryptBase64(string key, string value)
        {
            var decrypt = DecryptBase64(value);
            return key.Length > decrypt.Length ? decrypt : decrypt.Substring(key.Length - 1);
        }
        #endregion

        
    }

    /// <summary>
    /// Summary description for Base64Encoder.
    /// </summary>
    public class Base64Encoder
    {
        byte[] source;
        int length, length2;
        int blockCount;
        int paddingCount;
        public Base64Encoder(byte[] input)
        {
            source = input;
            length = input.Length;
            if ((length % 3) == 0)
            {
                paddingCount = 0;
                blockCount = length / 3;
            }
            else
            {
                paddingCount = 3 - (length % 3);//need to add padding
                blockCount = (length + paddingCount) / 3;
            }
            length2 = length + paddingCount;//or blockCount *3
        }

        public char[] GetEncoded()
        {
            byte[] source2;
            source2 = new byte[length2];
            //copy data over insert padding
            for (int x = 0; x < length2; x++)
            {
                if (x < length)
                {
                    source2[x] = source[x];
                }
                else
                {
                    source2[x] = 0;
                }
            }

            byte b1, b2, b3;
            byte temp, temp1, temp2, temp3, temp4;
            byte[] buffer = new byte[blockCount * 4];
            char[] result = new char[blockCount * 4];
            for (int x = 0; x < blockCount; x++)
            {
                b1 = source2[x * 3];
                b2 = source2[x * 3 + 1];
                b3 = source2[x * 3 + 2];

                temp1 = (byte)((b1 & 252) >> 2);//first

                temp = (byte)((b1 & 3) << 4);
                temp2 = (byte)((b2 & 240) >> 4);
                temp2 += temp; //second

                temp = (byte)((b2 & 15) << 2);
                temp3 = (byte)((b3 & 192) >> 6);
                temp3 += temp; //third

                temp4 = (byte)(b3 & 63); //fourth

                buffer[x * 4] = temp1;
                buffer[x * 4 + 1] = temp2;
                buffer[x * 4 + 2] = temp3;
                buffer[x * 4 + 3] = temp4;

            }

            for (int x = 0; x < blockCount * 4; x++)
            {
                result[x] = sixbit2char(buffer[x]);
            }

            //covert last "A"s to "=", based on paddingCount
            switch (paddingCount)
            {
                case 0: break;
                case 1: result[blockCount * 4 - 1] = '='; break;
                case 2: result[blockCount * 4 - 1] = '=';
                    result[blockCount * 4 - 2] = '=';
                    break;
                default: break;
            }
            return result;
        }

        private char sixbit2char(byte b)
        {
            char[] lookupTable = new char[64]
          {  'A','B','C','D','E','F','G','H','I','J','K','L','M',
            'N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
            'a','b','c','d','e','f','g','h','i','j','k','l','m',
            'n','o','p','q','r','s','t','u','v','w','x','y','z',
            '0','1','2','3','4','5','6','7','8','9','+','/'};

            if ((b >= 0) && (b <= 63))
            {
                return lookupTable[(int)b];
            }
            else
            {
                //should not happen;
                return ' ';
            }
        }
    }

    /// <summary>
    /// Summary description for Base64Decoder.
    /// </summary>
    public class Base64Decoder
    {
        char[] source;
        int length, length2, length3;
        int blockCount;
        int paddingCount;
        public Base64Decoder(char[] input)
        {
            int temp = 0;
            source = input;
            length = input.Length;

            //find how many padding are there
            for (int x = 0; x < 2; x++)
            {
                if (input[length - x - 1] == '=')
                    temp++;
            }
            paddingCount = temp;
            //calculate the blockCount;
            //assuming all whitespace and carriage returns/newline were removed.
            blockCount = length / 4;
            length2 = blockCount * 3;
        }

        public byte[] GetDecoded()
        {
            byte[] buffer = new byte[length];//first conversion result
            byte[] buffer2 = new byte[length2];//decoded array with padding

            for (int x = 0; x < length; x++)
            {
                buffer[x] = char2sixbit(source[x]);
            }

            byte b, b1, b2, b3;
            byte temp1, temp2, temp3, temp4;

            for (int x = 0; x < blockCount; x++)
            {
                temp1 = buffer[x * 4];
                temp2 = buffer[x * 4 + 1];
                temp3 = buffer[x * 4 + 2];
                temp4 = buffer[x * 4 + 3];

                b = (byte)(temp1 << 2);
                b1 = (byte)((temp2 & 48) >> 4);
                b1 += b;

                b = (byte)((temp2 & 15) << 4);
                b2 = (byte)((temp3 & 60) >> 2);
                b2 += b;

                b = (byte)((temp3 & 3) << 6);
                b3 = temp4;
                b3 += b;

                buffer2[x * 3] = b1;
                buffer2[x * 3 + 1] = b2;
                buffer2[x * 3 + 2] = b3;
            }
            //remove paddings
            length3 = length2 - paddingCount;
            byte[] result = new byte[length3];

            for (int x = 0; x < length3; x++)
            {
                result[x] = buffer2[x];
            }

            return result;
        }

        private byte char2sixbit(char c)
        {
            char[] lookupTable = new char[64]
                                     {
                                         'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N',
                                         'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                                         'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n',
                                         'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                                         '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '/'
                                     };
            if (c == '=')
                return 0;
            else
            {
                for (int x = 0; x < 64; x++)
                {
                    if (lookupTable[x] == c)
                        return (byte)x;
                }
                //should not reach here
                return 0;
            }

        }

    }



    public class Decode
    {
        char[] source;
        int length, length2, length3;
        int blockCount;
        int paddingCount;
        public Decode(char[] input)
        {
            int temp = 0;
            source = input;
            length = input.Length;

            //find how many padding are there
            for (int x = 0; x < 2; x++)
            {
                if (input[length - x - 1] == '=')
                    temp++;
            }
            paddingCount = temp;
            //calculate the blockCount;
            //assuming all whitespace and carriage returns/newline were removed.
            blockCount = length / 4;
            length2 = blockCount * 3;
        }

        public byte[] GetDecoded()
        {
            byte[] buffer = new byte[length];//first conversion result
            byte[] buffer2 = new byte[length2];//decoded array with padding

            for (int x = 0; x < length; x++)
            {
                buffer[x] = char2sixbit(source[x]);
            }

            byte b, b1, b2, b3;
            byte temp1, temp2, temp3, temp4;

            for (int x = 0; x < blockCount; x++)
            {
                temp1 = buffer[x * 4];
                temp2 = buffer[x * 4 + 1];
                temp3 = buffer[x * 4 + 2];
                temp4 = buffer[x * 4 + 3];

                b = (byte)(temp1 << 2);
                b1 = (byte)((temp2 & 48) >> 4);
                b1 += b;

                b = (byte)((temp2 & 15) << 4);
                b2 = (byte)((temp3 & 60) >> 2);
                b2 += b;

                b = (byte)((temp3 & 3) << 6);
                b3 = temp4;
                b3 += b;

                buffer2[x * 3] = b1;
                buffer2[x * 3 + 1] = b2;
                buffer2[x * 3 + 2] = b3;
            }
            //remove paddings
            length3 = length2 - paddingCount;
            byte[] result = new byte[length3];

            for (int x = 0; x < length3; x++)
            {
                result[x] = buffer2[x];
            }

            return result;
        }

        private byte char2sixbit(char c)
        {
            char[] lookupTable = new char[64]
					{	'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
						'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
						'0','1','2','3','4','5','6','7','8','9','+','/'};
            if (c == '=')
                return 0;
            else
            {
                for (int x = 0; x < 64; x++)
                {
                    if (lookupTable[x] == c)
                        return (byte)x;
                }
                //should not reach here
                return 0;
            }

        }
    }

    public class Encode
    {
        private byte[] source;
        private int length, length2;
        private int blockCount;
        private int paddingCount;

        public Encode(byte[] input)
        {
            source = input;
            length = input.Length;
            if ((length % 3) == 0)
            {
                paddingCount = 0;
                blockCount = length / 3;
            }
            else
            {
                paddingCount = 3 - (length % 3); //need to add padding
                blockCount = (length + paddingCount) / 3;
            }
            length2 = length + paddingCount; //or blockCount *3
        }

        public char[] GetEncoded()
        {
            byte[] source2;
            source2 = new byte[length2];
            //copy data over insert padding
            for (int x = 0; x < length2; x++)
            {
                if (x < length)
                {
                    source2[x] = source[x];
                }
                else
                {
                    source2[x] = 0;
                }
            }

            byte b1, b2, b3;
            byte temp, temp1, temp2, temp3, temp4;
            byte[] buffer = new byte[blockCount * 4];
            char[] result = new char[blockCount * 4];
            for (int x = 0; x < blockCount; x++)
            {
                b1 = source2[x * 3];
                b2 = source2[x * 3 + 1];
                b3 = source2[x * 3 + 2];

                temp1 = (byte)((b1 & 252) >> 2); //first

                temp = (byte)((b1 & 3) << 4);
                temp2 = (byte)((b2 & 240) >> 4);
                temp2 += temp; //second

                temp = (byte)((b2 & 15) << 2);
                temp3 = (byte)((b3 & 192) >> 6);
                temp3 += temp; //third

                temp4 = (byte)(b3 & 63); //fourth

                buffer[x * 4] = temp1;
                buffer[x * 4 + 1] = temp2;
                buffer[x * 4 + 2] = temp3;
                buffer[x * 4 + 3] = temp4;

            }

            for (int x = 0; x < blockCount * 4; x++)
            {
                result[x] = sixbit2char(buffer[x]);
            }

            //covert last "A"s to "=", based on paddingCount
            switch (paddingCount)
            {
                case 0:
                    break;
                case 1:
                    result[blockCount * 4 - 1] = '=';
                    break;
                case 2:
                    result[blockCount * 4 - 1] = '=';
                    result[blockCount * 4 - 2] = '=';
                    break;
                default:
                    break;
            }
            return result;
        }

        private char sixbit2char(byte b)
        {
            char[] lookupTable = new char[64]
                {
                    'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
                    'U', 'V', 'W', 'X', 'Y', 'Z',
                    'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
                    'u', 'v', 'w', 'x', 'y', 'z',
                    '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '/'
                };

            if ((b >= 0) && (b <= 63))
            {
                return lookupTable[(int)b];
            }
            else
            {
                //should not happen;
                return ' ';
            }
        }
    }
}
