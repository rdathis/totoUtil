/*
 * Created by SharpDevelop.
 * User: athis_000
 * Date: 23/04/2015
 * Time: 19:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Diagnostics;
namespace cmdUtils.Objets
{
	
	public class ProcessUtil  {
		
		
		
		public Process startProcess(String cmd, String args, ProcessWindowStyle windowStyle) {
			var info = new ProcessStartInfo();
			info.FileName = cmd;
			info.Arguments = args;
			//Process.Start(info);
			
			String us = Environment.ExpandEnvironmentVariables("%userprofile%");
			us = us.Replace("\\", "/");
			info.Arguments = info.Arguments.Replace("%userprofile%", us);
			
			info.RedirectStandardError = true;
			info.RedirectStandardOutput = true;
			info.UseShellExecute = false;
			
			var p = new Process();
			p.StartInfo.WindowStyle = windowStyle;
			p.StartInfo = info;
			

			//Execution
			p.Start();
			
			return p;
			//recup. des flux
			//String s1 = p.StandardOutput.ReadToEnd();
			//String s2 = p.StandardError.ReadToEnd();
		}
	}
}
