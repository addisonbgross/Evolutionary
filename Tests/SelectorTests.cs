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
		Dictionary<String, float> dictionary = new Dictionary<String, float> ();

		[Test()]
		public void killAll () {
			int countBeforeKilling = dictionary.Count;

			for (int i = 0; i < 100; ++i)
				dictionary.Add("0101010", 1.0f);
			
			selector.Select (dictionary, 1.0f);

			Assert.AreEqual (true, dictionary.Count == 0);
		}
		[Test()]
		public void killHalf () {
			int countBeforeKilling = dictionary.Count / 2;

			for (int i = 0; i < 100; ++i)
				dictionary.Add("0101010", 1.0f);

			selector.Select (dictionary, 0.5f);

			Assert.AreEqual (true, dictionary.Count <= countBeforeKilling);
		}
	}
}

