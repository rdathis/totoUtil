/*
 * Utilisateur: Renaud
 * Date: 04/05/2017
 * Heure: 13:49:26
 * 
*/
using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace cmdUtils.Objets.utils
{
	/// <summary>
	/// Description of CryptoUtil.
	/// </summary>
	public class CryptoUtil
	{
		public CryptoUtil()
		{
		}
		public string EncryptString(string inputString, int dwKeySize,
			string xmlString)
		{
			RSACryptoServiceProvider rsaCryptoServiceProvider =
				new RSACryptoServiceProvider(dwKeySize);
			rsaCryptoServiceProvider.FromXmlString(xmlString);
			int keySize = dwKeySize / 8;
			byte[] bytes = Encoding.UTF32.GetBytes(inputString);
			//RSACryptoServiceProvider here
			int maxLength = keySize - 42;
			int dataLength = bytes.Length;
			int iterations = dataLength / maxLength;
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i <= iterations; i++) {
				byte[] tempBytes = new byte[
					(dataLength - maxLength * i > maxLength) ? maxLength :
					dataLength - maxLength * i ];
				Buffer.BlockCopy(bytes, maxLength * i, tempBytes, 0,
					tempBytes.Length);
				byte[] encryptedBytes = rsaCryptoServiceProvider.Encrypt(tempBytes,
					                        true);
				stringBuilder.Append(Convert.ToBase64String(encryptedBytes));
			}
			return stringBuilder.ToString();
		}
		public string DecryptString(string inputString, int dwKeySize, string xmlString)
		{
			RSACryptoServiceProvider rsaCryptoServiceProvider
				= new RSACryptoServiceProvider(dwKeySize);
			rsaCryptoServiceProvider.FromXmlString(xmlString);
			int base64BlockSize = ((dwKeySize / 8) % 3 != 0) ?
				(((dwKeySize / 8) / 3) * 4) + 4 : ((dwKeySize / 8) / 3) * 4;
			int iterations = inputString.Length / base64BlockSize;
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < iterations; i++) {
				byte[] encryptedBytes = Convert.FromBase64String(
					                        inputString.Substring(base64BlockSize * i, base64BlockSize));
				Array.Reverse(encryptedBytes);
				arrayList.AddRange(rsaCryptoServiceProvider.Decrypt(
					encryptedBytes, true));
			}
			return Encoding.UTF32.GetString(arrayList.ToArray(
				Type.GetType("System.Byte")) as byte[]);
		}
		


		private void testCrypta(string[] args)
		{
			string source = "Hello World!";
			using (MD5 md5Hash = MD5.Create()) {
				string hash = GetMd5Hash(md5Hash, source);
				Console.WriteLine("The MD5 hash of " + source + " is: " + hash + ".");
				Console.WriteLine("Verifying the hash...");
				if (VerifyMd5Hash(md5Hash, source, hash)) {
					Console.WriteLine("The hashes are the same.");
				} else {
					Console.WriteLine("The hashes are not same.");
				}
			}
		}
		string GetMd5Hash(MD5 md5Hash, string input)
		{
			// Convert the input string to a byte array and compute the hash.
			byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
			// Create a new Stringbuilder to collect the bytes
			// and create a string.
			StringBuilder sBuilder = new StringBuilder();
			// Loop through each byte of the hashed data
			// and format each one as a hexadecimal string.
			for (int i = 0; i < data.Length; i++) {
				sBuilder.Append(data[i].ToString("x2"));
			}
			// Return the hexadecimal string.
			return sBuilder.ToString();
		}
		// Verify a hash against a string.
		bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
		{
			// Hash the input.
			string hashOfInput = GetMd5Hash(md5Hash, input);
			// Create a StringComparer an compare the hashes.
			StringComparer comparer = StringComparer.OrdinalIgnoreCase;
			if (0 == comparer.Compare(hashOfInput, hash)) {
				return true;
			} else {
				return false;
			}
			
		}

		byte[] GetKey(string str)
		{
			return Encoding.ASCII.GetBytes(str);
		}

		public string Encrypt(string data)
		{
			TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();

			DES.Mode = CipherMode.ECB;
			DES.GenerateKey();
			
			DES.Key = GetKey("a1!B78s!5(");

			DES.Padding = PaddingMode.PKCS7;
			ICryptoTransform DESEncrypt = DES.CreateEncryptor();
			Byte[] Buffer = ASCIIEncoding.ASCII.GetBytes(data);

			return Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
		}

		public string Decrypt(string data)
		{
			TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();

			DES.Mode = CipherMode.ECB;
			DES.Key = GetKey("a1!B78s!5(");
			
			DES.Padding = PaddingMode.PKCS7;
			ICryptoTransform DESEncrypt = DES.CreateDecryptor();
			Byte[] Buffer = Convert.FromBase64String(data.Replace(" ", "+"));

			return Encoding.UTF8.GetString(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
		}
	}
}
