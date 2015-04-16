/*
 * Created by SharpDevelop.
 * User: athis_000
 * Date: 16/04/2015
 * Time: 22:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
namespace totoUtil.Objets
{
	/// <summary>
	/// Description of GrepOptions
	/// </summary>
	public class GrepOptions
	{
		public GrepOptions()
		{
		}
		private Boolean printFileName=true;
		private Boolean printLineNumber=true;
		private int limitLineLengh=-1;
		
		public Boolean getPrintFileName() {
			return printFileName;
		}
		public Boolean getPrintLineNumber() {
			return printLineNumber;
		}
		public int getLimitLineLength() {
			return limitLineLengh;
		}

		public void setPrintFileName(Boolean val) {
			printFileName=val;
		}
		public void setPrintLineNumber(Boolean val) {
			printLineNumber=val;
		}
		public void setLimitLineLength(int val) {
			limitLineLengh=val;
		}

	}
}
