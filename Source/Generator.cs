
using System;

namespace Generator {

	// Creating a new object of this class automatically creates a random
	// chromosome. if no input is passed to the constructor, it defaults to 8
	// characters in length;
	public class Generator {
		private Random randomNumber = new Random();
		
		public Generator() {
		}
		
		private bool isMultipleOfFour(int input) {
			return (input % 4 == 0) ? true : false;
		}
		
		private int roundUpToMultipleOfFour(int input) {
			while(!isMultipleOfFour(input)) {
				input++;
			}
			return input;
		}
		
		// Generates the chromomsome with 8 numbers.
		public string generateChromosome() {
			return generateChromosome(8);
		}
		
		// Generates the chromomsome.
		public string generateChromosome(int chromosomeLength) {
			chromosomeLength = roundUpToMultipleOfFour(chromosomeLength);
			string randomChromosome = "";
			for (int i = 0; i < chromosomeLength; i++) {
				// rnd.Next(0, 2) generates a random integer that is a 0 or 1
				randomChromosome += randomNumber.Next(0, 2);
			}
			return randomChromosome;
		}
	}
}
