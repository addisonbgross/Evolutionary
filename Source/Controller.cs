using System;
using Gtk;

//TODO decouple the graphView from the Controller somehow
public class Controller
{
	Button startButton, resetButton, drawButton;
	Entry mutationEntry, crossoverEntry, selectionEntry, chromosomeEntry;
	Evolutionary.GraphView graphView;

	public Controller () {}
	public VBox GetInterface() {
		VBox box = new VBox(false, 0);
		VBox inputBound = new VBox (false, 0);
		VBox inputBox1 = new VBox (false, 0);
		VBox inputBox2 = new VBox (false, 0);
		HBox buttonBox = new HBox (false, 0);

		startButton = new Button ("Start");
		startButton.Clicked += StartEvent;

		drawButton = new Button ("Draw");
		drawButton.Clicked += DrawEvent;

		resetButton = new Button ("Reset");
		resetButton.Clicked += ResetEvent;

		mutationEntry = new Entry ();
		mutationEntry.SetSizeRequest (10, 30);
		mutationEntry.MaxLength = 10;
		crossoverEntry = new Entry ();
		crossoverEntry.SetSizeRequest (10, 30);
		crossoverEntry.MaxLength = 10;
		selectionEntry = new Entry ();
		selectionEntry.SetSizeRequest (10, 30);
		selectionEntry.MaxLength = 10;
		chromosomeEntry = new Entry ();
		chromosomeEntry.SetSizeRequest (10, 30);
		chromosomeEntry.MaxLength = 10;

		inputBox1.Add (new Label ("Mutation Rate"));
		inputBox1.Add (mutationEntry);
		inputBox1.Add (new Label ("Crossover Rate"));
		inputBox1.Add (crossoverEntry);

		inputBox2.Add (new Label ("Selection Rate"));
		inputBox2.Add (selectionEntry);
		inputBox2.Add (new Label ("Chromosome Length"));
		inputBox2.Add (chromosomeEntry);

		buttonBox.Add (startButton);
		buttonBox.Add (drawButton);
		buttonBox.Add (resetButton);

		inputBound.Add (inputBox1);
		inputBound.Add (inputBox2);

		box.BorderWidth = 10;
		//box.Add (inputBox1);
		//box.Add (inputBox2);
		box.Add (inputBound);
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
		if(graphView != null)
			graphView.ReDraw();
	}
	public void SetGraph(Evolutionary.GraphView gv) {
		this.graphView = gv;
	}
	public void ResetEvent(object obj, EventArgs args) {
		ClearEntries ();
	}
}

