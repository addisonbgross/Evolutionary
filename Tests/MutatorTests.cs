using NUnit.Framework;
using System;
using System.Collections.Generic;
using Mutator;

namespace Tests
{
	[TestFixture()]
	public class MutatorTests
	{
		Mutator mutator = new Mutator();

		[Test()]
		public void testCrossover () {
			String chromo1 = "00001111";
			String chromo2 = "11110000";

			mutator.Crossover(chromo1, chromo2, 1.0);

			Assert.AreNotSame (chromo1, "00001111");
			Assert.AreNotSame (chromo2, "11110000");
		}
		[Test()]
		public void testMutation() {
			String chromo1 = "00001111";
			String chromo2 = "11110000";

			mutator.Mutate (chromo1, 1.0);
			mutator.Mutate (chromo2, 1.0);

			Assert.AreNotSame (chromo1, "00001111");
			Assert.AreNotSame (chromo2, "11110000");
		}

	}
}

