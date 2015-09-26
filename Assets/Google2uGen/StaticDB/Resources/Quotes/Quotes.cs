//----------------------------------------------
//    Google2u: Google Doc Unity integration
//         Copyright © 2015 Litteratus
//
//        This file has been auto-generated
//              Do not manually edit
//----------------------------------------------

using UnityEngine;
using System.Globalization;

namespace Google2u
{
	[System.Serializable]
	public class QuotesRow : IGoogle2uRow
	{
		public string _Author;
		public string _Quote;
		public string _Book;
		public QuotesRow(string __ID, string __Author, string __Quote, string __Book) 
		{
			_Author = __Author.Trim();
			_Quote = __Quote.Trim();
			_Book = __Book.Trim();
		}

		public int Length { get { return 3; } }

		public string this[int i]
		{
		    get
		    {
		        return GetStringDataByIndex(i);
		    }
		}

		public string GetStringDataByIndex( int index )
		{
			string ret = System.String.Empty;
			switch( index )
			{
				case 0:
					ret = _Author.ToString();
					break;
				case 1:
					ret = _Quote.ToString();
					break;
				case 2:
					ret = _Book.ToString();
					break;
			}

			return ret;
		}

		public string GetStringData( string colID )
		{
			var ret = System.String.Empty;
			switch( colID )
			{
				case "Author":
					ret = _Author.ToString();
					break;
				case "Quote":
					ret = _Quote.ToString();
					break;
				case "Book":
					ret = _Book.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "Author" + " : " + _Author.ToString() + "} ";
			ret += "{" + "Quote" + " : " + _Quote.ToString() + "} ";
			ret += "{" + "Book" + " : " + _Book.ToString() + "} ";
			return ret;
		}
	}
	public sealed class Quotes : IGoogle2uDB
	{
		public enum rowIds {
			Quote1, Quote2
		};
		public string [] rowNames = {
			"Quote1", "Quote2"
		};
		public System.Collections.Generic.List<QuotesRow> Rows = new System.Collections.Generic.List<QuotesRow>();

		public static Quotes Instance
		{
			get { return NestedQuotes.instance; }
		}

		private class NestedQuotes
		{
			static NestedQuotes() { }
			internal static readonly Quotes instance = new Quotes();
		}

		private Quotes()
		{
			Rows.Add( new QuotesRow("Quote1", "Amélie Beaudroit", "Ploup", "The Ploup Book"));
			Rows.Add( new QuotesRow("Quote2", "Charles Pearson", "Haha salut", "Lolibook"));
		}
		public IGoogle2uRow GetGenRow(string in_RowString)
		{
			IGoogle2uRow ret = null;
			try
			{
				ret = Rows[(int)System.Enum.Parse(typeof(rowIds), in_RowString)];
			}
			catch(System.ArgumentException) {
				Debug.LogError( in_RowString + " is not a member of the rowIds enumeration.");
			}
			return ret;
		}
		public IGoogle2uRow GetGenRow(rowIds in_RowID)
		{
			IGoogle2uRow ret = null;
			try
			{
				ret = Rows[(int)in_RowID];
			}
			catch( System.Collections.Generic.KeyNotFoundException ex )
			{
				Debug.LogError( in_RowID + " not found: " + ex.Message );
			}
			return ret;
		}
		public QuotesRow GetRow(rowIds in_RowID)
		{
			QuotesRow ret = null;
			try
			{
				ret = Rows[(int)in_RowID];
			}
			catch( System.Collections.Generic.KeyNotFoundException ex )
			{
				Debug.LogError( in_RowID + " not found: " + ex.Message );
			}
			return ret;
		}
		public QuotesRow GetRow(string in_RowString)
		{
			QuotesRow ret = null;
			try
			{
				ret = Rows[(int)System.Enum.Parse(typeof(rowIds), in_RowString)];
			}
			catch(System.ArgumentException) {
				Debug.LogError( in_RowString + " is not a member of the rowIds enumeration.");
			}
			return ret;
		}

	}

}
