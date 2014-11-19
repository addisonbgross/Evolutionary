using System;
using Gtk;

public class Controller
{
	Button startButton, resetButton, drawButton;
	Entry mutationEntry, crossoverEntry;
	Evolutionary.GraphView graphView;

	public Controller () {}
	public VBox GetInterface() {
		VBox box = new VBox(false, 0);

		HBox inputBox1 = new HBox (false, 0);
		HBox inputBox2 = new HBox (false, 0);
		HBox buttonBox = new HBox (false, 0);

		startButton = new Button ("Start");
		startButton.Clicked += StartEvent;

		drawButton = new Button ("Draw");
		drawButton.Clicked += DrawEvent;

		resetButton = new Button ("Reset");
		resetButton.Clicked += ResetEvent;

		mutationEntry = new Entry ();
		mutationEntry.SetSizeRequest (30, 30);
		mutationEntry.MaxLength = 10;
		crossoverEntry = new Entry ();
		crossoverEntry.SetSizeRequest (30, 30);
		crossoverEntry.MaxLength = 10;


		inputBox1.Add (new Label ("Set Mutation Rate"));
		inputBox1.Add (mutationEntry);
		inputBox1.Add (new Label ("Set Crossover Rate"));
		inputBox1.Add (crossoverEntry);

		inputBox2.Add (new Label ("Set Mutation Rate"));
		inputBox2.Add (mutationEntry);
		inputBox2.Add (new Label ("Set Crossover Rate"));
		inputBox2.Add (crossoverEntry);

		buttonBox.Add (startButton);
		buttonBox.Add (drawButton);
		buttonBox.Add (resetButton);

		box.Add (inputBox1);
		box.Add (inputBox2);
		box.Add (buttonBox);
		box.Show (); 
		return box;
	}
	public void SendInput() {
		if (startButton.Label == "Start")
			startButton.Label = "Stop";
		else
			startButton.Label = "Start";
	}
	public void ClearEntries() {
		mutationEntry.Text = "";
		crossoverEntry.Text = "";
		startButton.Label = "Start";
	}
	public void StartEvent(object obj, EventArgs args) {
		SendInput ();
	}
	public void DrawEvent(object obj, EventArgs args) {
		/*
		if(graphView != null)
			graphView.OnExpose (null, null);
		*/
	}
	public void SetGraph(Evolutionary.GraphView gv) {
		this.graphView = gv;
	}
	public void ResetEvent(object obj, EventArgs args) {
		ClearEntries ();
	}
}

