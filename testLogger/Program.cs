/*
 * Utilisateur: Renaud
 * Date: 13/07/2017
 * Heure: 12:57:39
 * 
 */
using System;
using System.IO;
using log4net;
using log4net.Config;

namespace testLogger
{
	class Program
	{
		public static void Main(string[] args)
		{
			log4net.ILog LOGGER = LogManager.GetLogger("testUtil");
			
			Console.WriteLine("Hello World!");
			//BasicConfigurator.Configure();
			
			//log4net.Config.XmlConfigurator.Configure();
			const string file="W:/meo-moulinettes/conf/logger.config";
			if(File.Exists(file)) {
				XmlConfigurator.Configure(new Uri(file));
			} else {
				Console.WriteLine("Erreur : config absent : "+file);
			}
			System.Diagnostics.Debug.Print("starting");
			LOGGER.Debug("it's raining");
			LOGGER.Info("water spotted");
			LOGGER.Warn("we are sinking !");
			LOGGER.Error("so many fishes");
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
			
			/*
Hello World!
xxxx 348  [1] INFO  testUtil (null) - info
xxxx 391  [1] DEBUG testUtil (null) - debug
xxxx 391  [1] WARN  testUtil (null) - warn
xxxx 391  [1] ERROR testUtil (null) - error
Press any key to continue . . .
 
 https://logging.apache.org/log4net/log4net-1.2.13/release/sdk/log4net.Layout.PatternLayout.html
			 */
		}
		
	}
}