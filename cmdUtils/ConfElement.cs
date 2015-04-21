/*
 * Created by SharpDevelop.
 * User: athis_000
 * Date: 20/04/2015
 * Time: 20:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;   
using System.Configuration;

namespace cmdUtils
{
	/// <summary>
	/// Represents a single XML tag inside a ConfigurationSection
	/// or a ConfigurationElementCollection.
	/// </summary>
	public sealed class ConfElement : ConfigurationElement
	{
		/// <summary>
		/// The attribute <c>name</c> of a <c>ConfElement</c>.
		/// </summary>
		[ConfigurationProperty("name1", IsKey = true, IsRequired = true)]
		public string Name
		{
			get { return (string)this["name1"]; }
			set { this["name1"] = value; }
		}
	
	
		/// <summary>
		/// A demonstration of how to use a boolean property.
		/// </summary>
		[ConfigurationProperty("special")]
		public bool IsSpecial {
			get { return (bool)this["special"]; }
			set { this["special"] = value; }
		}
	}
	
}

