
using System;

namespace Generator {

	// Creating a new object of this class automatically creates a random
	// chromosome. if no input is passed to the constructor, it defaults to 8
	// characters in length;
	public class Generator {
		// is the randomly generated chromosome string
		private string chromosome;
	
		// Generates a chromosome of length 8
		public Generator() {
			this.chromosome = generateChromosome(8);
		}
		
		// Generates a chromosome of length chromosomeLength
		public Generator(int chromosomeLength) {
			if (!isMultipleOfFour(chromosomeLength)) {
				chromosomeLength = roundUpToMultipleOfFour(chromosomeLength);
			}
			this.chromosome = generateChromosome(chromosomeLength);
		}
		
		private bool isMultipleOfFour(int input) {
			if (input % 4 == 0) {
				return true;
			}
			return false;
		}
		
		private int roundUpToMultipleOfFour(int input) {
			while(input%4 != 0) {
				input++;
			}
			return input;
		}
		
		// Generates the chromomsome.
		private string generateChromosome(int chromosomeLength) {
			Random rnd = new Random();
			string randomChromosome = "";
			for (int i = 0; i < chromosomeLength; i++) {
				// rnd.Next(0, 2) generates a random integer that is a 0 or 1
				randomChromosome += rnd.Next(0, 2);
			}
			return randomChromosome;
		}
		
		// Getter method for chromosome string.
		public string getChromosomeString() {
			return this.chromosome;
		}
	}
}
