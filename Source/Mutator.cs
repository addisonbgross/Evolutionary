using System.Collections.Generic;
using System;
using System.Linq;

namespace Evolutionary 
{
	public class Mutator 
	{
		private Random r = new Random();
		private int chromosomeMaxSize;
		private float mutationRate;
		private float crossoverRate;

		public Mutator() {}

		//must be called before Mutate or Crossover is called
		public void setCrossoverRate(int crossover) 
		{
			crossoverRate = crossover;
		}

		public void setMutationRate(int mutation) 
		{
			mutationRate = mutation;
		}

		public void Crossover(Dictionary<string, float> chromosomeDictionary)
		{
			List<KeyValuePair<string, float>> chromosomeList = chromosomeDictionary.ToList ();
			Dictionary<string, float> newChromosomeDictionary = new Dictionary<string, float> ();
			KeyValuePair<string, float> chromosome1;
			KeyValuePair<string, float> chromosome2;

			int pairsToCrossover = (int)Math.Ceiling (crossoverRate * chromosomeList.Count) / 2;

			for (; pairsToCrossover > 0; pairsToCrossover--) 
			{
				chromosome1 = chromosomeList [(int)Math.Floor (chromosomeList.Count * r.NextDouble ())];
				chromosome2 = chromosomeList [(int)Math.Floor (chromosomeList.Count * r.NextDouble ())];

				int swapIndex = (int)Math.Ceiling (chromosome1.Key.Length * r.NextDouble ());
				string new1 = chromosome1.Key.Substring (0, swapIndex)
				              + chromosome2.Key.Substring (swapIndex);
				string new2 = chromosome2.Key.Substring (0, swapIndex)
				              + chromosome1.Key.Substring (swapIndex);

				if(!newChromosomeDictionary.ContainsKey(new1)) //ensures no duplicates
					newChromosomeDictionary.Add (new1, 0f);
				if(!newChromosomeDictionary.ContainsKey(new2))
					newChromosomeDictionary.Add (new2, 0f);
			}
			foreach (KeyValuePair<string, float> kvp in chromosomeList) {
				if (!newChromosomeDictionary.ContainsKey (kvp.Key)) //ensures no duplicates
					newChromosomeDictionary.Add (kvp.Key, kvp.Value);
			}

			chromosomeList.Clear ();
			chromosomeDictionary = newChromosomeDictionary;
		}

		public void Mutate(Dictionary<string, float> chromosomeDictionary)
		{
			List<KeyValuePair<string, float>> chromosomes = chromosomeDictionary.ToList ();

			int chromosomesToMutate = (int)Math.Ceiling (mutationRate * chromosomes.Count);

			for (; chromosomesToMutate > 0; chromosomesToMutate--) 
			{
				string chromosomeKey = chromosomes [(int)Math.Floor (chromosomes.Count * r.NextDouble ())].Key;
				chromosomeDictionary.Remove (chromosomeKey);

				//flip a bit of DNA
				char[] tempChromo;
				int mutationPoint = (int)Math.Floor (chromosomeKey.Length * r.NextDouble ());
				if (chromosomeKey [mutationPoint] == '0') {
					tempChromo = chromosomeKey.ToCharArray ();
					tempChromo [mutationPoint] = '1';
					chromosomeKey = tempChromo.ToString ();
					//chromosomeKey [mutationPoint] = '1';
				} else {
					tempChromo = chromosomeKey.ToCharArray ();
					tempChromo [mutationPoint] = '0';
					chromosomeKey = tempChromo.ToString ();
				}
				if (!chromosomeDictionary.ContainsKey (chromosomeKey)) //ensures no duplicates
					chromosomeDictionary.Add (chromosomeKey, 0f);
			}
		}
	}
}


