
using System;
using System.Collections.Generic;
using System.Data;


namespace Generator {
	/*
	 * 0: 0000
	 * 1: 0001
	 * 2: 0010
	 * 3: 0011
	 * 4: 0100
	 * 5: 0101
	 * 6: 0110
	 * 7: 0111
	 * 8: 1000
	 * 9: 1001
	 * +: 1010
	 * -: 1011
	 * *: 1100
	 * /: 1101
	 * DORMANT: 1110
	 * DORMANT: 1111
	 * */

	public class Decoder {
		public Decoder() {
		
		}
		private const bool DEBUG = true;
		
		public Dictionary<string, float> decode(int target, Dictionary<string, float> chromosomeSet) {
			List<string> fourDigitStrings = new List<string>();
			fourDigitStrings = getListOfFourDigitStringsFromDictionary(chromosomeSet);
			string stringFromChromosomeSet = getChromosomeStringFromDictionary(chromosomeSet);
			
			if (isFitnessScoreCalculatable(fourDigitStrings)) {
				
				
				float fitnessScore = (float)1/ ((float)target -findFitnessScoreUsingFourDigitList(fourDigitStrings));
				
				if (DEBUG) {
					Console.WriteLine("Fitness Score = " + fitnessScore);
				}
				
				chromosomeSet.Clear();
				chromosomeSet.Add(stringFromChromosomeSet, fitnessScore);
			}
			else {
				// Could not calculate
				if (DEBUG) {
					Console.WriteLine("Could not Calculate");
				}
			}
			
			return chromosomeSet;
		}
		
		private string getChromosomeStringFromDictionary(Dictionary<string, float> chromosomeSet) {
			foreach (KeyValuePair<string, float> pair in chromosomeSet) {
				return pair.Key;
			}
			return "Did not find anything";
		}
		
		// Probably do not ever need this
//		private float getFitnessScoreFromDictionary(Dictionary<string, float> chromosomeSet) {
//			foreach (KeyValuePair<string, float> pair in chromosomeSet) {
//				return pair.Value;
//			}
//			return -1;
//		}
		
		private List<string> getListOfFourDigitStringsFromDictionary(Dictionary<string, float> chromosomeSet) {
			List<string> fourDigitStrings = new List<string>();
			string chromosome = getChromosomeStringFromDictionary(chromosomeSet);
			string temp = "";
			
			for (int i = 0; i < chromosome.Length; i += 4) {
				temp = chromosome[i].ToString() + chromosome[i + 1].ToString() + 
						chromosome[i + 2].ToString() + chromosome[i + 3].ToString();
				fourDigitStrings.Add(temp);
			}
			return fourDigitStrings;
		}
		
		private float findFitnessScoreUsingFourDigitList(List<string> fourDigitList) {
			string runningTotal = getValueAsString(fourDigitList[0]);
			
			for (int i = 1; i < fourDigitList.Capacity; i++) {
				runningTotal += getValueAsString(fourDigitList[i]);
			}
			return Evaluate(runningTotal);			
		}
		
		private string getValueAsString(string fourDigitChromosome) {
			switch (fourDigitChromosome) {
			case "0000":
				if (DEBUG) {
					Console.WriteLine("0");
				}
				return "0";
			case "0001":
				if (DEBUG) {
					Console.WriteLine("1");
				}
				return "1";
			case "0010":
				if (DEBUG) {
					Console.WriteLine("2");
				}
				return "2";
			case "0011":
				if (DEBUG) {
					Console.WriteLine("3");
				}
				return "3";
			case "0100":
				if (DEBUG) {
					Console.WriteLine("4");
				}
				return "4";
			case "0101":
				if (DEBUG) {
					Console.WriteLine("5");
				}
				return "5";
			case "0110":
				if (DEBUG) {
					Console.WriteLine("6");
				}
				return "6";
			case "0111":
				if (DEBUG) {
					Console.WriteLine("7");
				}
				return "7";
			case "1000":
				if (DEBUG) {
					Console.WriteLine("8");
				}
				return "8";
			case "1001":
				if (DEBUG) {
					Console.WriteLine("9");
				}
				return "9";
			case "1010":
				if (DEBUG) {
					Console.WriteLine("+");
				}
				return "+";
			case "1011":
				if (DEBUG) {
					Console.WriteLine("-");
				}
				return "-";
			case "1100":
				if (DEBUG) {
					Console.WriteLine("*");
				}
				return "*";
			default:
				if (DEBUG) {
					Console.WriteLine("/");
				}
				return "/";
			}
		}
		
			// if the first or last set of four digits corresponds to a operator,
			// or is dormant, then return false
			// If any of the strings correspond to dormant, return false
			// if an operator is right after another operator, return false
		private bool isFitnessScoreCalculatable(List<string> fourDigitList) {
			if (isOperator(fourDigitList[0]) || isDormant(fourDigitList[0])) {
				return false;
			}
			int maxIndexOfFourDigitList = fourDigitList.Capacity - 1;
			if (isOperator(fourDigitList[maxIndexOfFourDigitList]) || 
				isDormant(fourDigitList[maxIndexOfFourDigitList])) {
				return false;
			}
			int lastIndexThatWasOperator = -5; // Something that will never mess up the rest
			for (int i = 0; i < fourDigitList.Capacity; i++) {
				if (isDormant(fourDigitList[i])) {
					return false;
				}
				
				if (isOperator(fourDigitList[i])) {
					if (lastIndexThatWasOperator == i-1) {
						return false;
					}
					lastIndexThatWasOperator = i;
				}
			}
			
			return true;
		}
		
		private bool isOperator(string fourDigitChromosome) {
			if (fourDigitChromosome.Equals("1010") || fourDigitChromosome.Equals("1011") ||
				fourDigitChromosome.Equals("1100") || fourDigitChromosome.Equals("1101")) {
				return true;
			}
			return false;
		}
		
		private bool isDormant(string fourDigitChromosome) {
			if (fourDigitChromosome.Equals("1110") || fourDigitChromosome.Equals("1111")) {
				return true;
			}
			return false;
		}
		
		private float Evaluate(string expression) {
			DataTable table = new DataTable();
			table.Columns.Add("expression", typeof(string), expression);
			DataRow row = table.NewRow();
			table.Rows.Add(row);
			
			if (DEBUG) {
				Console.WriteLine("Evaluated Expression = " + float.Parse((string)row["expression"]));	
			}
			
			return float.Parse((string)row["expression"]);
		}
		
		
	}
}
