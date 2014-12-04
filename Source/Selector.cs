using System;
using System.Collections.Generic;
/**
 * The basic idea:
 * -get a set of chromosomes
 * -iterate through the chromosomes
 * 		-add each fitness value to killLevel
 * 		-add the chromosome and a random number to deathList
 * -multiply killLevel by the percentage of chromosomes to be killed
 * -sort deathList randomly
 * -iterate through deathList
 * 		-subtract the chromosome's fitness from the killLevel
 * 		-if the killLevel is below zero break
 * 		-remove the current chromosome from the original set
 */
namespace Evolutionary {
	public class Selector {
		static List<KeyValuePair<int, String>> deathList = new List<KeyValuePair<int, String>> ();
		static Random random = new Random();
		static float killLevel;

		public Selector (){}

		public void Select (Dictionary<string, float> chromosomes, float killRate) {
		
			deathList.Clear();
			killLevel = 0;

			var keys = new List<string> (chromosomes.Keys);
		
			foreach (string key in keys) {
				KeyValuePair<int, String> kvp = new KeyValuePair<int, String> (random.Next(), key);
				deathList.Add (kvp);

				killLevel += chromosomes [key];
			}

			killLevel *= killRate;
			deathList.Sort (CustomSort);

			foreach (KeyValuePair<int, String> kvp in deathList) {
				if ((killLevel -= chromosomes[kvp.Value]) < 0) {
					break;
				}
				chromosomes.Remove (kvp.Value);
			}
		}

		public int CustomSort(KeyValuePair<int, string> x, KeyValuePair<int, String> y) {
			if (x.Key > y.Key)
				return 1;
			else if (y.Key < x.Key)
				return -1;
			else
				return 0;
		}
	}
}

