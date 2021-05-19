using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Threading;

namespace Saugumas_4.Utilities
{
    class FileEncryptionTool
    {
        private static ManualResetEvent resetEvent = new ManualResetEvent(true);

        public static void EncryptCombo(string inputFile, string password = "Verij big secret verij big")
        {
            FileEncrypt(inputFile, password);
            File.Delete(inputFile);
        }

        public static void DecryptCombo(string inputFile, string password = "Verij big secret verij big")
        {
            FileDecrypt(inputFile, password);
            File.Delete(inputFile);
        }

        /// <summary>
        /// Creates a random salt that will be used to encrypt your file. This method is required on FileEncrypt.
        /// </summary>
        /// <returns></returns>
        public static byte[] GenerateRandomSalt()
        {
            byte[] data = new byte[32];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                for (int i = 0; i < 10; i++)
                {
                    // Fille the buffer with the generated data
                    rng.GetBytes(data);
                    resetEvent.WaitOne();
                }
            }

            return data;
        }

        public static void FileEncrypt(string inputFile, string password)
        {
            //http://stackoverflow.com/questions/27645527/aes-encryption-on-large-files
            if (!(File.Exists(inputFile)))
                throw new Exception("Toks failas/naudotojas neegzistuoja");
            //generate random salt
            byte[] salt = GenerateRandomSalt();

            //create output file name
            FileStream fsCrypt = new FileStream(inputFile + ".aes", FileMode.Create);

            //convert password string to byte arrray
            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);

            //Set Rijndael symmetric encryption algorithm
            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            AES.Padding = PaddingMode.PKCS7;

            //http://stackoverflow.com/questions/2659214/why-do-i-need-to-use-the-rfc2898derivebytes-class-in-net-instead-of-directly
            //"What it does is repeatedly hash the user password along with the salt." High iteration counts.
            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            //Cipher modes: http://security.stackexchange.com/questions/52665/which-is-the-best-cipher-mode-and-padding-mode-for-aes-encryption
            AES.Mode = CipherMode.CFB;

            // write salt to the begining of the output file, so in this case can be random every time
            fsCrypt.Write(salt, 0, salt.Length);

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateEncryptor(), CryptoStreamMode.Write);

            FileStream fsIn = new FileStream(inputFile, FileMode.Open);

            //create a buffer (1mb) so only this amount will allocate in the memory and not the whole file
            byte[] buffer = new byte[1048576];
            int read;

            try
            {
                while ((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
                {
                    //Application.DoEvents(); // -> for responsive GUI, using Task will be better!
                    cs.Write(buffer, 0, read);
                    resetEvent.WaitOne();
                }

                // Close up
                fsIn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                cs.Close();
                fsCrypt.Close();
            }
        }

        /// <summary>
        /// Decrypts an encrypted file with the FileEncrypt method through its path and the plain password.
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="outputFile"></param>
        /// <param name="password"></param>
        public static bool FileDecrypt(string inputFile, string password)
        {
            if (!(File.Exists(inputFile)))
                throw new Exception("Toks failas/naudotojas neegzistuoja");

            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] salt = new byte[32];

            FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);
            fsCrypt.Read(salt, 0, salt.Length);

            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);
            AES.Padding = PaddingMode.PKCS7;
            AES.Mode = CipherMode.CFB;

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateDecryptor(), CryptoStreamMode.Read);

            FileStream fsOut = new FileStream(inputFile.Remove(inputFile.Length - 4), FileMode.Create);

            int read;
            byte[] buffer = new byte[1048576];

            bool failed = false;
            try
            {
                while ((read = cs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fsOut.Write(buffer, 0, read);
                    resetEvent.WaitOne();
                }
            }
            catch (CryptographicException ex_CryptographicException)
            {
                Console.WriteLine("CryptographicException error: " + ex_CryptographicException.Message);
                failed = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                failed = true;
            }

            try
            {
                cs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error by closing CryptoStream: " + ex.Message);
            }
            finally
            {
                fsOut.Close();
                fsCrypt.Close();
            }

            return failed;
        }

        public static string GetMD5(string path)
        {
            string result;
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(path))
                {
                    result = "";
                    byte[] data = md5.ComputeHash(stream);
                    foreach(byte b in data)
                    {
                        result += ((int)b).ToString();
                        resetEvent.WaitOne();
                    }
                }
            }
            return result;
        }

        public static void WriteChecksum(string path, List<string> MD5Values)
        {
            path += "\\Checksum.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    foreach (string s in MD5Values)
                    {
                        sw.WriteLine(s);
                        resetEvent.WaitOne();
                    }
                }
            }
        }

        public static List<string> ReadChecksum(string path, SynchronizationContext ui)
        {
            path += "\\Checksum.txt";
            List<string> MD5Values = new List<string>();
            if (File.Exists(path))
            {
                MD5Values.AddRange(File.ReadAllLines(path));
            }
            else
            {
                throw new Exception("Failed to find the checksum");
            }

            return MD5Values;
        }

        public static void ResetMRE()
        {
            resetEvent.Reset();
        }

        public static void SetMRE()
        {
            resetEvent.Set();
        }
    }
}
