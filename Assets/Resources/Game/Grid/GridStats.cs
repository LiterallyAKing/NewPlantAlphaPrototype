using UnityEngine;
using System.Collections;

public class GridStats : MonoBehaviour {
	public GridCell mycell;
	public int Light { get { 
			if (mycell.occupied) {
				return baseLight + mycell.plantincell.LightMod;
			} else {
				return baseLight;
			}
		}
	}
	public int Water { get { 
			if (mycell.occupied) {
				return baseWater + mycell.plantincell.WaterMod;
			} else {
				return baseWater;
			}
		}
	}
	public int Heat {
		get {
			if (mycell.occupied) {
				return baseHeat + mycell.plantincell.HeatMod;
			} else {
				return baseHeat;
			}
		}
	}

	[HideInInspector] public int baseLight = 0;
	[HideInInspector] public int baseWater = 0;
	[HideInInspector] public int baseHeat = 0;


}
