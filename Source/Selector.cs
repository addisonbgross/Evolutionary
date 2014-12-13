using System;
using System.Collections.Generic;

namespace Evolutionary 
{
	public class Selector 
	{
		private List<KeyValuePair<int, String>> deathList = new List<KeyValuePair<int, String>> ();
		private Random random = new Random();
		private float populationSize;

		public Selector (){}

		public void setPopulationSize (int p) {
			populationSize = p;
		}

		public void Select (ref Dictionary<string, float> chromosomes) {
			deathList.Clear();
			var chromosomesKilled = 0;
			var allFullyEvolved = false;
			var killQuota = Math.Max(0, chromosomes.Count - populationSize);
			var keys = new List<string> (chromosomes.Keys);
		
			allFullyEvolved = true;

			foreach (string key in keys) {
				if (chromosomes [key] != 1f) {
					allFullyEvolved = false;
					KeyValuePair<int, String> kvp = new KeyValuePair<int, String> (random.Next(), key);
					deathList.Add (kvp);
				}
			}

			if (!allFullyEvolved) {
				deathList.Sort (CustomSort);
				int ringIterator = 0;

				while (chromosomesKilled < killQuota) {
					KeyValuePair<int, String> kvp = deathList[ringIterator];
					if ((float)random.NextDouble () > chromosomes [kvp.Value]) {
						chromosomes.Remove (kvp.Value);
						deathList.Remove (kvp);
						chromosomesKilled++;
					}
					ringIterator++;
					ringIterator %= deathList.Count;
				}
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

