using UnityEngine;
using System;
using System.Collections.Generic;

namespace UnityMidiControl.Input {
	[Serializable]
	public class ControlMappings {
		public List<ControlMapping> Mappings = new List<ControlMapping>();

		public void ClearMappings() {
			Mappings = new List<ControlMapping>();
		}

		public void RemoveMapping(int control, int minVal, int maxVal, string key) {
			for (int i = Mappings.Count - 1; i >= 0; --i) {
				ControlMapping m = Mappings[i];
				if ((m.control == control) && (m.minVal == minVal) && (m.maxVal == maxVal) && (m.key == key)) {
					Mappings.RemoveAt(i);
					return; // if there are multiple mappings with the same settings, only the first will be removed
				}
			}
		}

		public void MapControl(int control, int minVal, int maxVal, string key) {
			Mappings.Insert(0, new ControlMapping(control, minVal, maxVal, key));
		}

//		public bool MapsKey(string key) {
//			foreach (KeyMapping m in Mappings) {
//				if (m.key == key) return true;
//			}
//
//			return false;
//		}

//		public List<int> GetTriggers(string key) {
//			List<int> triggers = new List<int>();
//			foreach (KeyMapping m in Mappings) {
//				if (m.key == key) triggers.Add(m.trigger);
//			}
//
//			return triggers;
//		}
	}

	[Serializable]
	public class ControlMapping {
		public int control;
		public int minVal; // exclusive - value must be greater than this to trigger the key
		public int maxVal; // inclusive - value must be less than or equal to this to trigger the key
		public string key; // key activated (e.g., "x")
		
		public ControlMapping(int control, int minVal, int maxVal, string key) {
			this.control = control;
			this.minVal = minVal;
			this.maxVal = maxVal;
			this.key = key;
		}
	}
}