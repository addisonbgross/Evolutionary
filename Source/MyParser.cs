using System;
using System.Data;

namespace Evolutionary {
	public class MyParser {
		
		public MyParser() {}

		public float Evaluate(string expression) {
			#pragma warning disable
			try {
				var loDataTable = new DataTable();
				var loDataColumn = new DataColumn("Eval", typeof (double), expression);
				loDataTable.Columns.Add(loDataColumn);
				loDataTable.Rows.Add(0);
				var result =  (double)(loDataTable.Rows[0]["Eval"]);
				return (float)result;
			} catch(Exception e) {
				//it's fine
				return 0f;
			}
			#pragma warning restore
		}
	}
}
