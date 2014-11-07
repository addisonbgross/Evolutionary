using System;

namespace Generator {

	// Creating a new object of this class automatically creates a random
	// chromosome. if no input is passed to the generateChromosome function,
	// it defaults to 8 characters in length;
	public class Generator {
		// this is used to generate random 1's and 0's later
		static private Random randomNumber = new Random();
		
		public Generator() {
			// Do Nothing
		}

		private int getRandom0or1() {
			return randomNumber.Next(0,2);
		}
		
		private bool isMultipleOfFour(int input) {
			return (input % 4 == 0);
		}	

		private int roundUpToMultipleOfFour(int input) {
			while(!isMultipleOfFour(input)) {
				input++;
			}
			return input;
		}
		
		// Generates a chromomsome with 8 digits.
		public string generateChromosome() {
			return generateChromosome(8);
		}
		
		// Generates the chromomsome.
		public string generateChromosome(int chromosomeLength) {
			chromosomeLength = roundUpToMultipleOfFour(chromosomeLength);
			string randomChromosome = "";
			for (int i = 0; i < chromosomeLength; i++) {
				// rnd.Next(0, 2) generates a random integer that is a 0 or 1
				randomChromosome += getRandom0or1();
			}
			return randomChromosome;
		}
	}
}
