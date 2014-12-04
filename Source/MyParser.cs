using System;
using System.Collections;

namespace Evolutionary {

	public class MyParser {
		
		public MyParser() {}

		public float Evaluate(string expression) {
			#pragma warning disable
			try {
				return (float)new System.Data.DataTable ().Compute (expression, null);
			} catch(Exception e) {
				//it's fine
				return 0f;
			}
		}
	}
}
