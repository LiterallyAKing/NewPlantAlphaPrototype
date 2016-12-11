using UnityEngine;

[System.Serializable]
public struct GridCoordinates {

	[SerializeField]
	private int x, z;

	public int X {
		get {
			return x;
		}
	}
	public int Z {
		get {
			return z;
		}
	}

	public GridCoordinates(int x, int z){
		this.x = x;
		this.z = z;
	}
	public override string ToString (){
		return "(" + X.ToString () + ", " + Z.ToString () + ")";
	}
	public string ToStringOnSeparateLines(){
		return X.ToString () + "\n" + Z.ToString ();
	}

	public string ToStringForName (){
		return "x" + X.ToString () + "z" + Z.ToString ();
	}

	public static GridCoordinates FromOffsetCoordinates(int x, int z){
		return new GridCoordinates (x,z);
	}

	public static GridCoordinates FromPosition(Vector3 position){
		float x = position.x;
		float y = x;
		float z = position.z;

		int iX = Mathf.RoundToInt(x*2f);
		int iZ = Mathf.RoundToInt(z*2f);

		return new GridCoordinates(iX, iZ);
	}


	public static bool operator ==(GridCoordinates a, GridCoordinates b)
	{
		// If both are null, or both are same instance, return true.
		if (System.Object.ReferenceEquals(a, b))
		{
			return true;
		}

		// If one is null, but not both, return false.
		if (((object)a == null) || ((object)b == null))
		{
			return false;
		}

		// Return true if the fields match:
		return a.x == b.x && a.z == b.z;
	}

	public static bool operator !=(GridCoordinates a, GridCoordinates b)
	{
		return !(a == b);
	}

}
