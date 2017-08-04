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
		
		public StatMoulRecap(String year) {
			this.year=year;
		}

		public void setVisiteQty(int value) {
			this.visiteQty=visiteQty;
		}
		public void setStockQty(int value) {
			this.stockQty=stockQty;
		}
		public void setStockNegQty(int value) {
			this.stockNegQty=stockNegQty;
		}
		public void setStockZeroQty(int value) {
			this.stockZeroQty=stockZeroQty;
		}
		public void setStockPosQty(int value) {
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
