/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 21/06/2016
 * Heure: 13:30:58
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Xml.Serialization;

namespace cmdUtils.Objets
{
	/// <summary>
	/// access to our config file.
	/// </summary>
	public class ConfigUtil
	{
		
		public ConfigUtil()
		{
		}
		
		public ConfigDto readConfigXml(String path="")
		{
			
			XmlSerializer serializer = new XmlSerializer(typeof(ConfigDto));
			
			FileStream fileStream = new FileStream(path+MouliConfig.commonConfigFile, FileMode.Open);
			ConfigDto dto = (ConfigDto)serializer.Deserialize(fileStream);
			fileStream.Close();
			return dto;
		}
		private void writeXml(ConfigDto dto)
		{
			FileStream fs;
			XmlSerializer serializer = new XmlSerializer(typeof(ConfigDto));
			fs = new FileStream(MouliConfig.commonConfigFile, FileMode.OpenOrCreate);
			serializer.Serialize(fs, dto);
			fs.Close();
			
		}
		public String getConfigFilePath()
		{
			//rem:faux
			Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			String path = config.FilePath;
			path = path.Substring(0, path.Length - 19);
			path += ConfigSectionSettings.getFullConfigFileName();
			return path;
		}

		public void saveOldConfig()
		{
			String config=MouliConfig.commonConfigFile;
			//File file = FileInfo new File(config);
			FileInfo file =new FileInfo(config);
			DateTime date = DateTime.Now;
			long ts= date.Ticks;
			String newFileName = file.Directory+"/"+file.Name + "-"+ts+""+file.Extension;
			
			File.Copy(config, newFileName);
		}

		/*
		private void open(String file)
		{
			fs = new FileStream(file, FileMode.Open);
		}
		private void close()
		{
			fs.Close();
			fs = null;
		}
		 */
		public ConfigDto getConfig()
		{
			Console.WriteLine("config:" + getConfigFilePath());
			
			// testWriteXml(dto);
			ConfigDto dto = readConfigXml();
			
			return dto;
		}
		public void saveConfig(ConfigDto configDto) {
			Console.WriteLine("saving config:" + getConfigFilePath());
			writeXml(configDto);
		}
		/*
		private String targetSvgPath(FileStream fs)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(String));
			return (String)serializer.Deserialize(fs);
		}

		// disable once ParameterHidesMember
		public List<MeoInstance>instances(FileStream fs)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<MeoInstance>));
			return  (List<MeoInstance>)serializer.Deserialize(fs);
		}
		public List<MeoInstance> readInstances()
		{
			open(MouliConfig.instancesConfigFile);
			//open("conf/common.xml");
			List<MeoInstance> liste = instances(fs);
			close();
			return liste;
		}
		public List<MeoServeur> readServeurs()
		{
			open(MouliConfig.serversConfigFile);
			//open("conf/common.xml");
			List <MeoServeur> liste = serveurs(fs);
			close();
			return liste;
		}
		// disable once ParameterHidesMember
		private  List<MeoServeur> serveurs(FileStream fs)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<MeoServeur>));
			return (List<MeoServeur>)serializer.Deserialize(fs);
		}
		 */
		
		public string EncryptString( string inputString, int dwKeySize,
		                            string xmlString )
		{
			RSACryptoServiceProvider rsaCryptoServiceProvider =
				new RSACryptoServiceProvider( dwKeySize );
			rsaCryptoServiceProvider.FromXmlString( xmlString );
			int keySize = dwKeySize / 8;
			byte[] bytes = Encoding.UTF32.GetBytes( inputString );
			RSACryptoServiceProvider here
				int maxLength = keySize - 42;
			int dataLength = bytes.Length;
			int iterations = dataLength / maxLength;
			StringBuilder stringBuilder = new StringBuilder();
			for( int i = 0; i <= iterations; i++ )
			{
				byte[] tempBytes = new byte[
					( dataLength - maxLength * i > maxLength ) ? maxLength :
					dataLength - maxLength * i ];
				Buffer.BlockCopy( bytes, maxLength * i, tempBytes, 0,
				                 tempBytes.Length );
				byte[] encryptedBytes = rsaCryptoServiceProvider.Encrypt( tempBytes,
				                                                         true );
				stringBuilder.Append( Convert.ToBase64String( encryptedBytes ) );
			}
			return stringBuilder.ToString();
		}
		public string DecryptString( string inputString, int dwKeySize, string xmlString )
		{
			RSACryptoServiceProvider rsaCryptoServiceProvider
				= new RSACryptoServiceProvider( dwKeySize );
			rsaCryptoServiceProvider.FromXmlString( xmlString );
			int base64BlockSize = ( ( dwKeySize / 8 ) % 3 != 0 ) ?
				( ( ( dwKeySize / 8 ) / 3 ) * 4 ) + 4 : ( ( dwKeySize / 8 ) / 3 ) * 4;
			int iterations = inputString.Length / base64BlockSize;
			ArrayList arrayList = new ArrayList();
			for( int i = 0; i < iterations; i++ )
			{
				byte[] encryptedBytes = Convert.FromBase64String(
					inputString.Substring( base64BlockSize * i, base64BlockSize ) );
				Array.Reverse( encryptedBytes );
				arrayList.AddRange( rsaCryptoServiceProvider.Decrypt(
					encryptedBytes, true ) );
			}
			return Encoding.UTF32.GetString( arrayList.ToArray(
				Type.GetType( "System.Byte" ) ) as byte[] );
		}
		


		private void testCrypta(string[] args)
		{
			string source = "Hello World!";
			using (MD5 md5Hash = MD5.Create())
			{
				string hash = GetMd5Hash(md5Hash, source);
				Console.WriteLine("The MD5 hash of " + source + " is: " + hash + ".");
				Console.WriteLine("Verifying the hash...");
				if (VerifyMd5Hash(md5Hash, source, hash))
				{
					Console.WriteLine("The hashes are the same.");
				}
				else
				{
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
			for (int i = 0; i < data.Length; i++)
			{
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
			if (0 == comparer.Compare(hashOfInput, hash))
			{
				return true;
			}
			else
			{
				return false;
			}
			
		}
	}
}