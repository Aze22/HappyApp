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
			Quote1, Quote2, Quote3, Quote4, Quote5, Quote6, Quote7, Quote8, Quote9, Quote10, Quote11, Quote12, Quote13, Quote14, Quote15, Quote16, Quote17, Quote18
			, Quote19, Quote20, Quote21, Quote22, Quote23, Quote24, Quote25, Quote26, Quote27, Quote28, Quote29, Quote30, Quote31, Quote32, Quote33, Quote34, Quote35, Quote36, Quote37, Quote38
			, Quote39, Quote40, Quote41, Quote42, Quote43, Quote44, Quote45, Quote46, Quote47, Quote48, Quote49, Quote50, Quote51, Quote52, Quote53, Quote54, Quote55, Quote56, Quote57, Quote58
			, Quote59, Quote60, Quote61, Quote62, Quote63, Quote64, Quote65, Quote66, Quote67, Quote68, Quote69, Quote70, Quote71
		};
		public string [] rowNames = {
			"Quote1", "Quote2", "Quote3", "Quote4", "Quote5", "Quote6", "Quote7", "Quote8", "Quote9", "Quote10", "Quote11", "Quote12", "Quote13", "Quote14", "Quote15", "Quote16", "Quote17", "Quote18"
			, "Quote19", "Quote20", "Quote21", "Quote22", "Quote23", "Quote24", "Quote25", "Quote26", "Quote27", "Quote28", "Quote29", "Quote30", "Quote31", "Quote32", "Quote33", "Quote34", "Quote35", "Quote36", "Quote37", "Quote38"
			, "Quote39", "Quote40", "Quote41", "Quote42", "Quote43", "Quote44", "Quote45", "Quote46", "Quote47", "Quote48", "Quote49", "Quote50", "Quote51", "Quote52", "Quote53", "Quote54", "Quote55", "Quote56", "Quote57", "Quote58"
			, "Quote59", "Quote60", "Quote61", "Quote62", "Quote63", "Quote64", "Quote65", "Quote66", "Quote67", "Quote68", "Quote69", "Quote70", "Quote71"
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
			Rows.Add( new QuotesRow("Quote1", "Neil Gaiman", "You don't pass or fail at being a person, dear.", "the ocean at the end of the lane"));
			Rows.Add( new QuotesRow("Quote2", "Neil Gaiman", "You're always you, and that don't change, and you're always changing, and there's nothing you can do about it.”", "the ocean at the end of the lane"));
			Rows.Add( new QuotesRow("Quote3", "Neil Gaiman - ", "The only advice I can give you is what you're telling yourself. Only, maybe you're too scared to listen.", "neverwhere"));
			Rows.Add( new QuotesRow("Quote4", "Neil Gaiman", "You get what anybody gets - you get a lifetime.", ""));
			Rows.Add( new QuotesRow("Quote5", "Tony Dorsett", "To succeed, you need to find something to hold on to, something to motivate you, something to inspire you.", ""));
			Rows.Add( new QuotesRow("Quote6", "Christopher McCandless", "The joy of life comes from our encounters with new experiences, and hence there is no greater joy than to have an endlessly changing horizon, for each day to have a new and different sun.", ""));
			Rows.Add( new QuotesRow("Quote7", "Les Brown", "Your smile will give you a positive countenance that will make people feel comfortable around you.", ""));
			Rows.Add( new QuotesRow("Quote8", "Dr. Seuss", "Don't cry because it's over. Smile because it happened.", ""));
			Rows.Add( new QuotesRow("Quote9", "Dr. Seuss", "I like nonsense, it wakes up the brain cells. Fantasy is a necessary ingredient in living, it's a way of looking at life through the wrong end of a telescope. Which is what I do, and that enables you to laugh at life's realities.", ""));
			Rows.Add( new QuotesRow("Quote10", "Albert Einstein", "Look deep into nature, and then you will understand everything better.", ""));
			Rows.Add( new QuotesRow("Quote11", "Albert Einstein", "When you are courting a nice girl an hour seems like a second. When you sit on a red-hot cinder a second seems like an hour. That's relativity.", ""));
			Rows.Add( new QuotesRow("Quote12", "Mark Twain", "If you tell the truth, you don't have to remember anything.", ""));
			Rows.Add( new QuotesRow("Quote13", "Mark Twain", "Humor is mankind's greatest blessing.", ""));
			Rows.Add( new QuotesRow("Quote14", "Mark Twain", "When you fish for love, bait with your heart, not your brain.", ""));
			Rows.Add( new QuotesRow("Quote15", "Jane Austen", "What is right to be done cannot be done too soon.", ""));
			Rows.Add( new QuotesRow("Quote16", "A. P. J. Abdul Kalam", "You have to dream before your dreams can come true.", ""));
			Rows.Add( new QuotesRow("Quote17", "Harriet Tubman", "Every great dream begins with a dreamer. Always remember, you have within you the strength, the patience, and the passion to reach for the stars to change the world.", ""));
			Rows.Add( new QuotesRow("Quote18", "Dalai Lama", "Sleep is the best meditation.", ""));
			Rows.Add( new QuotesRow("Quote19", "Terry Pratchett", "In the beginning there was nothing, which exploded.", ""));
			Rows.Add( new QuotesRow("Quote20", "Terry Pratchett", "The harder I work, the luckier I become.", ""));
			Rows.Add( new QuotesRow("Quote21", "Mary Shelley", "My dreams were all my own; I accounted for them to nobody; they were my refuge when annoyed - my dearest pleasure when free.", ""));
			Rows.Add( new QuotesRow("Quote22", "Dennis P. Kimbro", "Life is 10% what happens to us and 90% how we react to it.", ""));
			Rows.Add( new QuotesRow("Quote23", "Vincent Van Gogh", "Whoever loves much, performs much, and can accomplish much, and what is done in love is done well.", ""));
			Rows.Add( new QuotesRow("Quote24", "Iain Banks", "One should never mistake pattern for meaning.", ""));
			Rows.Add( new QuotesRow("Quote25", "Jane G Six", "There must be something you love, then do it, if not then it means there is still a lot to find out about yourself. ", ""));
			Rows.Add( new QuotesRow("Quote26", "Richard P. Feynman", "The first principle is that you must not fool yourself and you are the easiest person to fool.", ""));
			Rows.Add( new QuotesRow("Quote27", "Jane G Six", "Sometimes you have to be somebody you're not, then you grow to be who you want to.", ""));
			Rows.Add( new QuotesRow("Quote28", "Philip K. Dick", "The true measure of a man is not his intelligence or how high he rises in this freak establishment. No, the true measure of a man is this: how quickly can he respond to the needs of others and how much of himself he can give.", ""));
			Rows.Add( new QuotesRow("Quote29", "Dalai Lama", "Happiness is not something ready made. It comes from your own actions.", ""));
			Rows.Add( new QuotesRow("Quote30", "Terrence Malick", "there are two ways through life, the way of Nature and the way of Grace. You have to choose which one you'll follow.", ""));
			Rows.Add( new QuotesRow("Quote31", "anonymous", "Go after dreams, not people. ", ""));
			Rows.Add( new QuotesRow("Quote32", "Bono", "You can never get enough of what you don’t really need.", ""));
			Rows.Add( new QuotesRow("Quote33", "Johann Wolfgang von Goethe", "Whatever you can do or dream you can, begin it. Boldness has genius, power and magic in it.", ""));
			Rows.Add( new QuotesRow("Quote34", "Robert Henri", "The object isn’t to make art, it’s to be in that wonderful state which makes art inevitable.", ""));
			Rows.Add( new QuotesRow("Quote35", "Arianna Huffington", "We are not on this earth to accumulate victories, things, and experiences, but to be whittled and sandpapered until what’s left is who we truly are.", ""));
			Rows.Add( new QuotesRow("Quote36", "Stephen King", "Fiction is the truth inside the lie.", ""));
			Rows.Add( new QuotesRow("Quote37", "John Steinbeck", "Ideas are like rabbits. You get a couple and learn how to handle them, and pretty soon you have a dozen.", ""));
			Rows.Add( new QuotesRow("Quote38", "Leo Burnett", "Curiosity about life in all of its aspects, I think, is still the secret of great creative people.", ""));
			Rows.Add( new QuotesRow("Quote39", "Herman Melville", "It’s better to fail in originality, than succeed in imitation.", ""));
			Rows.Add( new QuotesRow("Quote40", "Robin WIlliams", "You’re only given a little spark of madness, you mustn’t lose it.", ""));
			Rows.Add( new QuotesRow("Quote41", "Maya Angelou", "I’ve learned that people will forget what you said, people will forget what you did, but people will never forget how you made them feel.", ""));
			Rows.Add( new QuotesRow("Quote42", "Antoine De Saint Exupery", "If you want to build a ship, don’t drum up people to collect wood and don’t assign them tasks and work, but rather teach them to long for the endless immensity of the sea.", ""));
			Rows.Add( new QuotesRow("Quote43", "Ray Bradbury", "Life is trying things to see if they work.", ""));
			Rows.Add( new QuotesRow("Quote44", "Cynthia Heimel", "When in doubt, make a fool of yourself. There’s a thin line between being brilliantly creative and acting like the biggest idiot on earth.", ""));
			Rows.Add( new QuotesRow("Quote45", "Henry Wadsworth Longfellow", "Give what you have. To someone else it may be better than you dare to think.", ""));
			Rows.Add( new QuotesRow("Quote46", "Guy Kawasaki", "Don’t worry, be crappy. ‘Revolutionary’ means you ship and then test… Lots of things made the first Mac in 1984 a piece of crap – but it was a revolutionary piece of crap.", ""));
			Rows.Add( new QuotesRow("Quote47", "William Shakespeare", "The earth has music for those who listen.", ""));
			Rows.Add( new QuotesRow("Quote48", "T.S. Elliot", "Home is where one starts from.", ""));
			Rows.Add( new QuotesRow("Quote49", "T.S. Elliot", "Only those that risk going too far can possibly find out how far one can go.", ""));
			Rows.Add( new QuotesRow("Quote50", "Joseph Chilton Pierce", "To live a creative life, we must lose our fear of being wrong.", ""));
			Rows.Add( new QuotesRow("Quote51", "John Maynard Keynes", "The difficulty lies not so much in developing new ideas as in escaping from old ones.", ""));
			Rows.Add( new QuotesRow("Quote52", "Johann Wolfgang von Goethe", "I love those who yearn for the impossible.", ""));
			Rows.Add( new QuotesRow("Quote53", "Johann Wolfgang von Goethe", "Daring ideas are like chessmen moved forward; they may be beaten, but they may start a winning game.", ""));
			Rows.Add( new QuotesRow("Quote54", "Terri Guillemets", "Art is when you hear a knocking from your soul — and you answer.", ""));
			Rows.Add( new QuotesRow("Quote55", "Nolan Bushnell", "Everyone who’s ever taken a shower has had an idea. It’s the person who gets out of the shower, dries off and does something about it who makes a difference.", ""));
			Rows.Add( new QuotesRow("Quote56", "Huntley Fitzpatrick", "I remember...watching that separation of sea and sky...and for the first time I realize that none of us are seeing the same thing. That all our horizons end in different places.", ""));
			Rows.Add( new QuotesRow("Quote57", "Ella Dominguez", "Sometimes our balance has to be upset and our course reset in order to help us navigate to our final destination.", ""));
			Rows.Add( new QuotesRow("Quote58", "Shane Carruth (primer)", "If you always want what you can't have, what do you want when you can have anything?", ""));
			Rows.Add( new QuotesRow("Quote59", "Marion Grace Woolley. ", "Even in the darkest night a few stars are brave enough to shine.", "Those Rosy Hours at Mazandaran"));
			Rows.Add( new QuotesRow("Quote60", "Marion Grace Woolley\n", "You thought that what you were doing would make other people happy. You have no control over what other people think, only what you think and do for yourself. Don’t judge yourself by other people’s standards, and don’t give your happiness away again. It’s too important. ", "- Georg[i]e"));
			Rows.Add( new QuotesRow("Quote61", "Marion Grace Woolley. ", "Use your imagination, not your eyes...Look beyond what things are, to what they might be.", "Those Rosy Hours at Mazandaran"));
			Rows.Add( new QuotesRow("Quote62", "Laine Cunningham\n", "Earth was a church, and every sound and silence a hymn.", "The Tipping Time"));
			Rows.Add( new QuotesRow("Quote63", "René Magritte", "The mind loves the unknown.", ""));
			Rows.Add( new QuotesRow("Quote64", "― Robin Hobb,", "Long or short, if you worry about every step of a journey, you will divide it endlessly into pieces, any one of which may defeat you. Look only to the end.", "ship of destiny"));
			Rows.Add( new QuotesRow("Quote65", "― Robin Hobb,", "Look forward, not back. Correct your course and go on. You cannot undo yesterday's journey.", "the ship of magic"));
			Rows.Add( new QuotesRow("Quote66", "― Robin Hobb,", "One must plan for the future and anticipate the future without fearing the future.", "the ship of magic"));
			Rows.Add( new QuotesRow("Quote67", "― Robin Hobb,", "A manner of speaking becomes a manner of thinking.", "ship of destiny"));
			Rows.Add( new QuotesRow("Quote68", "― Robin Hobb,", "One can only walk so far from one's true self before the bond either snaps, or pulls one back.", "Royal assassin"));
			Rows.Add( new QuotesRow("Quote69", "Frank Herbert", "I must not fear. Fear is the mind-killer. Fear is the little-death that brings total obliteration. I will face my fear. I will permit it to pass over me and through me. And when it has gone past I will turn the inner eye to see its path. Where the fear has gone there will be nothing. Only I will remain.", "Dune"));
			Rows.Add( new QuotesRow("Quote70", "Novalis", "Our life is no dream, but it should and will perhaps become one.", ""));
			Rows.Add( new QuotesRow("Quote71", "Laine Cunningham", "Pouring all his suffering and grief, all his tears and pain and hope and love down the sacred red line on the arrow’s shaft, Aidan sighted on his target. Peace flowed through his limbs. He was relaxed and calm, he felt strength instead of pain.", "Reparation"));
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
