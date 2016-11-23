using UnityEngine;
using System.Collections;

public class GridStats : MonoBehaviour {
	[SerializeField] private int light = 0;
	[SerializeField] private int water = 0;
	[SerializeField] private int heat = 0;
	public int Light { get { return light; } 
		set{
				if (value < -2) {
					light = -2;
				} else if (value > 2) {
					light = 2;
				} else {
					light = value;
				}			
			}
	}
	public int Water { get { return water; } 
		set{
			if (value < -2) {
				water = -2;
			} else if (value > 2) {
				water = 2;
			} else {
				water = value;
			}			
		}
	}
	public int Heat { get { return heat; } 
		set{
			if (value < -2) {
				heat = -2;
			} else if (value > 2) {
				heat = 2;
			} else {
				heat = value;
			}			
		}
	}

}
