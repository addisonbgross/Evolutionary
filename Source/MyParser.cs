using System;
using System.Collections;

namespace Evolutionary {

	public class MyParser {

		private Stack numbersStack = new Stack();
		
		public MyParser() {}
		
		// 50+25
		public float Evaluate(string expression) {
			float tempNumber1 = 0;
			
			float number1;
			float number2;
			
			char tempOperator = '/';
			bool multiplyTempNumber = false;
			bool canUseTempOperator = false;
			numbersStack.Push (1f);
			
			for (int i = 0; i < expression.Length; i++) {
				if (isNumber(expression[i])) {
					if (multiplyTempNumber) {
						tempNumber1 *= 10;
						tempNumber1 += getNumberFromChar(expression[i]);
					}
					else {
						tempNumber1 = getNumberFromChar(expression[i]);
						multiplyTempNumber = true;
					}
				}
				else {
					numbersStack.Push(tempNumber1);
					if (canUseTempOperator) {
						number2 = (float)numbersStack.Pop();
						number1 = (float)numbersStack.Pop();
						numbersStack.Push(operateNum1andNum2(number1, tempOperator, number2));
					}
					tempOperator = expression[i];
					multiplyTempNumber = false;
					canUseTempOperator = true;
				}
			}
			numbersStack.Push(tempNumber1);
			number2 = (float)numbersStack.Pop();
			number1 = (float)numbersStack.Pop();
			return operateNum1andNum2(number1, tempOperator, number2);
		}
		
		private float operateNum1andNum2(float number1, char tempOperator, float number2) {
			switch (tempOperator) {
			case '+':
				return number1 + number2;
			case '-':
				return number1 - number2;
			case '*':
				return number1 * number2;
			default:
				return number1 / number2;
			}
		}
		
		private float getNumberFromChar(char token) {
			switch (token) {
			case '0':
				return 0;
			case '1':
				return 1;
			case '2':
				return 2;
			case '3':
				return 3;
			case '4':
				return 4;
			case '5':
				return 5;
			case '6':
				return 6;
			case '7':
				return 7;
			case '8':
				return 8;
			default:
				return 9;
			}
		}
		
		private bool isNumber(char token) {
			switch (token) {
			case '0':
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9':
				return true;
			default:
				return false;
			}
		}
	}
}
