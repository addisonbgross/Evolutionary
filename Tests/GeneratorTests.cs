using NUnit.Framework;
using System;
using System.Collections.Generic;
using Generator;

/**
 * A collection of tests to verify the effectiveness of
 * the evolutionary algorithm.
 **/
namespace Tests
{
	[TestFixture()]
	public class GeneratorTests
	{
		int SAMPLESIZE = 100;
		Generator.Generator generator = new Generator.Generator();

		[Test()]
		public void checkIfStringIsGenerated() {
			Assert.AreEqual(generator.generateChromosome().GetType(), typeof(string));
		}
		[Test()]
		public void resolveUndersizedStringRequest() {
			string chromo = generator.generateChromosome (2);
			Assert.AreEqual (4, chromo.Length);
		}
		[Test()]
		public void resolveNegativeStringRequest() {
			string chromo = generator.generateChromosome (-2);
			Assert.Greater (0, chromo.Length);
		}
		[Test()]
		public void resolveArgNotMultipleOfFour() {
			string chromo = generator.generateChromosome (11);
			Assert.AreEqual(true,  (chromo.Length % 4 == 0));

			chromo = generator.generateChromosome (1);
			Assert.AreEqual(true,  (chromo.Length % 4 == 0));

			chromo = generator.generateChromosome (666);
			Assert.AreEqual(true,  (chromo.Length % 4 == 0));

			chromo = generator.generateChromosome (0);
			Assert.AreEqual(true,  (chromo.Length % 4 == 0));
		}
		[Test()]
		public void retrieveManyRandomString() {
			List<string> strList = new List<string> ();
			int allowableDuplicates = SAMPLESIZE / 10;

			for (int i = 0; i < SAMPLESIZE; ++i)
				strList.Add (generator.generateChromosome ());

			for (int i = 0; i < strList.Count; ++i)
				for (int j = 0; j < strList.Count; ++j)
					if (strList[i] == strList[j])
						--allowableDuplicates;
			Assert.AreEqual(true, (allowableDuplicates > 0));
		}
	}
}

