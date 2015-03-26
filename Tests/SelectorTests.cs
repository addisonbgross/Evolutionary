using NUnit.Framework;
using System;
using System.Collections.Generic;
using Selector;

namespace Test
{
	[TestFixture()]
	public class SelectorTests
	{
		Selector.Selector selector = new Selector.Selector();
		static Dictionary<string, float> dictionary = new Dictionary<string, float> ();

		[Test()]
		public void killAll () {
			dictionary.Clear ();
			string s = "000";
			for (int i = 0; i < 100; ++i)
				dictionary.Add(s += "1", 1.0f);

			selector.Select (dictionary, 1.0f);

			Assert.AreEqual (true, dictionary.Count == 0);
		}
		[Test()]
		public void killHalf () {
			dictionary.Clear ();
			int countBeforeKilling = dictionary.Count / 2;
			string s = "101";
			for (int i = 0; i < 100; ++i)
				dictionary.Add(s += "1", 1.0f);

			selector.Select (dictionary, 0.5f);

			Assert.AreEqual (true, dictionary.Count <= countBeforeKilling);
		}
	}
}

