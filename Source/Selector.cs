using System;
using System.Collections.Generic;

namespace Selector {
	public class Selector {
		static List<KeyValuePair<int, String>> deathList = new List<KeyValuePair<int, String>> ();
		static Random random = new Random();
		static float killLevel;

		public Selector (){}

		/*
		static void Main() {
			Selector s = new Selector ();
			Dictionary<string, float> d = new Dictionary<string, float>();
			d.Add ("SADFASD", 1.0f);
			s.Select (d, 1.0f);
			Console.WriteLine (d.Count);
		}
		*/

		public void Select (Dictionary<string, float> chromosomes, float killRate) {
		
			deathList.Clear();
			killLevel = 0;

			var keys = new List<string> (chromosomes.Keys);
		
			foreach (string key in keys) {
				KeyValuePair<int, String> kvp = new KeyValuePair<int, String> (random.Next(), key);
				deathList.Add (kvp);

				killLevel += chromosomes [key];
				//chromosomes [key] = Math.Round (chromosomes[key], 3);
			}

			killLevel *= killRate;
			deathList.Sort ();

			foreach (KeyValuePair<int, String> kvp in deathList) {
				if ((killLevel -= chromosomes[kvp.Value]) < 0) {
					break;
				}
				chromosomes.Remove (kvp.Value);
			}
		}
	}
}

