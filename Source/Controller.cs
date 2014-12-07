using System;
using Gtk;

//TODO decouple the graphView from the Controller somehow
using System.Collections.Generic;

namespace Evolutionary 
{
	public class Controller
	{
		Button startButton, resetButton, drawButton;
		HScale mutationScale, crossoverScale, chromosomeScale;
		double mutationRate, crossoverRate, chromosomeSize;
		GraphView graphView;

		public Controller () {}
		public VBox GetInterface() {
			VBox box = new VBox(false, 0);
			VBox inputBox = new VBox (false, 0);
			HBox buttonBox = new HBox (false, 0);

			startButton = new Button ("Start");
			drawButton = new Button ("Draw");
			resetButton = new Button ("Reset");
			startButton.Clicked += StartEvent;
			drawButton.Clicked += DrawEvent;
			resetButton.Clicked += ResetEvent;

			mutationScale = new HScale(0, 100, 1);
			crossoverScale = new HScale(0, 100, 1);
			chromosomeScale = new HScale(0, 100, 4);
			chromosomeScale.SetIncrements(4, 4);

			inputBox.Add (new Label ("Mutation Rate"));
			inputBox.Add (mutationScale);
			inputBox.Add (new Label ("Crossover Rate"));
			inputBox.Add (crossoverScale);
			inputBox.Add (new Label ("Chromosome Length"));
			inputBox.Add (chromosomeScale);

			buttonBox.Add (startButton);
			buttonBox.Add (drawButton);
			buttonBox.Add (resetButton);

			box.BorderWidth = 10;
			box.Add (inputBox);
			box.Add (buttonBox);
			box.Show (); 
			return box;
		}
		public void SendInput() {
			if (startButton.Label == "Start") {
				mutationRate = mutationScale.Value;
				crossoverRate = crossoverScale.Value;
				chromosomeSize = chromosomeScale.Value;
				startButton.Label = "Stop";
			} else {
				//mutationScale.MoveSlider
				startButton.Label = "Start";
			}
		}
		public void ClearEntries() {
			startButton.Label = "Start";
		}
		public void StartEvent(object obj, EventArgs args) {
			SendInput ();
		}
		public void DrawEvent(object obj, EventArgs args) {
			if (graphView != null)
				graphView.ReDraw ();
		}
		public void SetGraph(GraphView gv) {
			this.graphView = gv;
		}
		public void ResetEvent(object obj, EventArgs args) {
			ClearEntries ();
		}
	}
}

