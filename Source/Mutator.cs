using System.Collections.Generic;
using System;
using System.Linq;

namespace Evolutionary 
{
	public class Mutator 
	{
		public Mutator() {}

		private Random r = new Random();
		private const int chromosomeMaxSize = 8;

		public Dictionary<string, float> Mutate(
			Dictionary<string, float> chromosomeDictionary, 
			float mutationRate, // 0 - 1
			float crossoverRate // 0 - 1
			)
		{
			List<KeyValuePair<string, float>> chromosomes = chromosomeDictionary.ToList ();
			Dictionary<string, float> affectedChromosomes = new Dictionary<string, float> ();
			KeyValuePair<string, float> chromosome1;
			KeyValuePair<string, float> chromosome2;

			int pairsToCrossover = (int)Math.Ceiling (crossoverRate * chromosomes.Count) / 2;

			for (; pairsToCrossover > 0; pairsToCrossover--) 
			{
				chromosome1 = chromosomes [(int)Math.Floor (chromosomes.Count * r.NextDouble ())];
				chromosomes.Remove (chromosome1);
				chromosome2 = chromosomes [(int)Math.Floor (chromosomes.Count * r.NextDouble ())];
				chromosomes.Remove (chromosome2);

				int swapIndex = (int)Math.Ceiling (chromosomeMaxSize * r.NextDouble ());
				string new1 = chromosome1.Key.Substring (0, swapIndex)
				              + chromosome2.Key.Substring (swapIndex);
				string new2 = chromosome2.Key.Substring (0, swapIndex)
				              + chromosome1.Key.Substring (swapIndex);
					
				affectedChromosomes.Add (new1, 0f);
				affectedChromosomes.Add (new2, 0f);
			}
			foreach (KeyValuePair<string, float> kvp in chromosomes)
				affectedChromosomes.Add (kvp.Key, kvp.Value);
				
			chromosomes.Clear ();

			return affectedChromosomes;
		}
	}
}


