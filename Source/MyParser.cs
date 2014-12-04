using System;

namespace Evolutionary {
	public class MyParser {
		
		public MyParser() {}

		public float Evaluate(string expression) {
			#pragma warning disable
			try {
				return float.Parse(new System.Data.DataTable ().Compute (expression, null).ToString());
			} catch(Exception e) {
				//it's fine
				return 0f;
			}
			#pragma warning restore
		}
	}
}
