/*
 * Created by SharpDevelop.
 * User: athis_000
 * Date: 03/08/2017
 * Time: 20:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace cmdUtils.Objets.business
{
	/// <summary>
	/// Description of StatMoulRecap.
	/// </summary>
	public class StatMoulRecap
	{
		private String year;
		private int visiteQty;
		private int stockQty;
		private int stockNegQty;
		private int stockZeroQty;
		private int stockPosQty;
		
		public StatMoulRecap( //
			String year, //
			int visiteQty,  //
			int stockQty,  //
			int stockNegQty, int stockZeroQty, int stockPosQty) 
		{
			this.year=year;
			this.visiteQty=visiteQty;
			this.stockQty=stockQty;
			this.stockNegQty=stockNegQty;
			this.stockZeroQty=stockZeroQty;
			this.stockPosQty=stockPosQty;
		}
		public String getYear() {
			return year;
		}
		public int getVisiteQty() {
			return visiteQty;
		}
		public int getStockQty() {
			return stockQty;
		}
		public int getStockNegQty() {
			return stockNegQty;
		}
		public int getStockZeroQty() {
			return stockZeroQty;
		}
		public int getStockPosQty() {
			return getStockPosQty;
		}
	}
}
