using System;
using System.Collections.Generic;

namespace Selector {
	public class Selector {
		Dictionary<float, String> deathList = new Dictionary<float, String> ();
		Random random = new Random();
		float killLevel;

		public Selector (){}

		public void Select (Dictionary<string, float> chromosomes, float killRate) {

			deathList.Clear();
			killLevel = 0;

			var keys = new List<string> (chromosomes.Keys);
		
			foreach (string key in keys) {
				deathList.Add (random.Next(), key);
				killLevel += chromosomes [key];
				//chromosomes [key] = Math.Round (chromosomes[key], 3);
			}

			killLevel *= killRate;
			List<KeyValuePair<float, String>> list = deathList;
			list.Sort ();

			foreach (String s in list) {
				if (killLevel -= chromosomes (s) < 0) {
					break;
				}
				chromosomes.Remove (s);
			}
		}
	}
}

