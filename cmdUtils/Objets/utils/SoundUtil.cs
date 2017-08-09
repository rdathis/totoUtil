/*
 * Utilisateur: Renaud
 * Date: 07/08/2017
 * Heure: 13:05:55
 * 
 */
using System;
using System.IO;

namespace cmdUtils.Objets.utils
{
	/// <summary>
	/// Description of SoundUtil.
	/// </summary>
	public class SoundUtil
	{
		
		
		private String media = Environment.GetEnvironmentVariable("windir") + "/media/";
		private Boolean exists = false;
		public static class SOUNDS
		{
			public static readonly string
				CHORD = "chord.wav",
				DING = "ding.wav",
				TADA = "tada.wav",
				ERROR = "windows error.wav",
				NOTIFY = "notify.wav";
			
		}
		public SoundUtil()
		{
			exists = Directory.Exists(media);
		}
		public void play(string file)
		{
			if (File.Exists(file)) {
				new System.Media.SoundPlayer(file).Play();
			}
		}

		public void playDingDing()
		{
			if (exists) {
				play(SOUNDS.DING);
			}
		}
		public void playChord()
		{
			if (exists) {
				play(SOUNDS.CHORD);
			}
		}
		public void playTada()
		{
			if (exists) {
				play(SOUNDS.TADA);
			}
		}
		public void playError()
		{
			if (exists) {
				play(SOUNDS.ERROR);
			}
		}
		public void playNotify()
		{
			if (exists) {
				play(SOUNDS.NOTIFY);
			}
		}
	}
}
