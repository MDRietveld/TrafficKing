using System;
using System.Collections.Generic;

namespace TrafficKing
{
	public static class PoliceStation
	{
		static List<IObserver> observer = new List<IObserver>();

		public static void Notify(){
			Game1.Instance._world.AddPolice ();
			foreach (IObserver obs in observer) {
				obs.OnPackage ();
			}
		}



		public static void Register(IObserver obs){
			observer.Add (obs);
		}
	}
}

