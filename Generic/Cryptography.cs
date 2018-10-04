//Development by Kelmer Ashley Comas Cardona © 2015

using System;
using System.Text;
using System.Security.Cryptography;


namespace Generic
{
    public static class Cryptography
    {
        //CLAVE DE ENCRIPTACION GENERICA
        private static string[] EncryptKey = { "347CA4D5BA73BB2803555B5FBFFDBD42FC36037E96AAB44ED732E436C44C963A533A92DCC6256D24E",
                                                "C4248F3C605441E336D64DDC0316A70F12C41175E05D9DB0B0D24B7442DF3EC4B7A23DC42844206A7",
                                                "31BB7210562C4519627133434878F64720C60AEA096F5ECA9D3E5FFF7B2400CCD79E1118354C9A8A2",
                                                "45A5F955E4C9677F2E3A4DFFFB996A7360BF36F9F62EE0C98BFA5E5B9AE881069C993D7569BA1E7B5",
                                                "375834FEABA59A708AE4925ACEE158D9ABF7BBEF912A85397693F60049AB018053F1733EABA0DCFE8",
                                                "C8A7E9979D2A6A7A0BC68D4776809CDD589F8E7A494ECC3E7D9566FEF914D4154015D60245C3CB0D1",
                                                "7A9054C598A05E47BCB06BADCE90A9EEA4C1D5FB4117BB8EB6366ABF1B8950752D1DD23F9C694115E",
                                                "1F98CD0E392A1FD44ADB0C2C634A69A22FE7D395CEB77DF21F1AA56407EA6E44A21558414599FAEAA",
                                                "0A84AC1E32FF2382498B2CAC8653DB13B1D12E130B6DE75F025977AEA33D1441799C2AE1F32A2399F",
                                                "123FBAA021DB1ACC082640B41DDFE544C4F1CED3B23BD4278EDB37DECC0CB916CCBBD354327915A59",
                                                "5A1B07F42639CE69833BD70AB5F4B6B64AD43E35824DED0D579EB3240C418A2436B29317617A62AB4",
                                                "1DD3957234203F229A36041EBDB0DF6DA78260B762686994EBFAC426AC0BD400EF635D1BA3FC67E76",
                                                "1C744AD893365C5E504E39A112E9DD588F2089E2FE8A912C3E51"
                                            };


        //=====================================================================================================
        //GENERA UNA CLAVE DE ENCRIPTACION Y DESENCRIPTACION ALEATORIA

        public static string GetRandomKey(int bytelength)
        {
            try
            {
                StringBuilder sb = null;
                byte[] buffer = new byte[bytelength];
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                rng.GetBytes(buffer);

                sb = new StringBuilder(bytelength * 2);

                for (int i = 0; i < buffer.Length; i++)
                    sb.Append(String.Format("{0:X2}", buffer[i]));

                return sb.ToString();
            }
            catch { throw; }
        }

        //ENCRIPTA EL TEXTO ESPECIFICADO CON UNA CLAVE DETERMINADA
        public static string Encrypt(string text, string key, bool useHashing = true)
        {
            try
            {
                byte[] keyArray, toEncryptArray;

                toEncryptArray = UTF8Encoding.UTF8.GetBytes(text);

                if (useHashing)
                {
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    hashmd5.Clear();
                }
                else keyArray = UTF8Encoding.UTF8.GetBytes(key);

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                tdes.Clear();
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            catch { throw new Exception("No se pudo encriptar con la clave especificada"); }
        }


        //DESENCRIPTA EL TEXTO ESPECIFICADO CON UNA CLAVE DETERMINADA
        public static string Decrypt(string text, string key, bool useHashing = true)
        {
            try
            {
                byte[] keyArray, toEncryptArray;

                toEncryptArray = Convert.FromBase64String(text);

                if (useHashing)
                {
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    hashmd5.Clear();
                }
                else keyArray = UTF8Encoding.UTF8.GetBytes(key);

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray; tdes.Mode = CipherMode.ECB; tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                tdes.Clear();
                return UTF8Encoding.UTF8.GetString(resultArray, 0, resultArray.Length);
            }
            catch { throw new Exception("No se pudo desencriptar el valor con la clave especificada"); }
        }


        public static string GetGenericKey() { return String.Join("", Cryptography.EncryptKey); }
    }
}
