﻿/*
 * Utilisateur: Renaud
 * Date: 06/03/2017
 * Heure: 13:29:45
 * 
 */
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using cmdUtils.Objets;

namespace testCrypt
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Crypto tests");
			String str =" a few string to convert";
			String pass = "56456s4f564sd56f4 sd64 0s56df4s56 04s56f0";
			Console.WriteLine("str : "+str);
			string crypted = EncryptString(str, pass);
			Console.WriteLine("crypted : "+crypted);
			string uncrypted = DecryptString(crypted, pass);
			Console.WriteLine("decrypted : "+uncrypted);
		}
		
		private const string initVector = "pemgail9uzpgzl88";
		// This constant is used to determine the keysize of the encryption algorithm
		private const int keysize = 256;
		//Encrypt
		public static string EncryptString(string plainText, string passPhrase)
		{
			byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
			byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
			PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
			byte[] keyBytes = password.GetBytes(keysize / 8);
			RijndaelManaged symmetricKey = new RijndaelManaged();
			symmetricKey.Mode = CipherMode.CBC;
			ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
			cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
			cryptoStream.FlushFinalBlock();
			byte[] cipherTextBytes = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			return Convert.ToBase64String(cipherTextBytes);
		}
		//Decrypt
		public static string DecryptString(string cipherText, string passPhrase)
		{
			byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
			byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
			PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
			byte[] keyBytes = password.GetBytes(keysize / 8);
			RijndaelManaged symmetricKey = new RijndaelManaged();
			symmetricKey.Mode = CipherMode.CBC;
			ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
			MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
			CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
			byte[] plainTextBytes = new byte[cipherTextBytes.Length];
			int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
			memoryStream.Close();
			cryptoStream.Close();
			return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
		}
		
	}
}