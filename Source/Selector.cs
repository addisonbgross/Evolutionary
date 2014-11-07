using System;
using System.Collections.Generic;

namespace Selector {
	public class Selector {
		static Dictionary<int, String> deathList = new Dictionary<float, String> ();
		static Random random = new Random();
		static float killLevel;

		public Selector (){}

		public void Select (Dictionary<string, float> chromosomes, float killRate) {

			deathList.Clear;
			killLevel = 0;

			var keys = new List<string> (chromosomes.Keys);
		
			foreach (string key in keys) {
				deathList.Add (random.Next, key);
				killLevel += chromosomes [key];
				//chromosomes [key] = Math.Round (chromosomes[key], 3);
			}

			killLevel *= killRate;
			List<KeyValuePair<int, String>> list = deathList;
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

