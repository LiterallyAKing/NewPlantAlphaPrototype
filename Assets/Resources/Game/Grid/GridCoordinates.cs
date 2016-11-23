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

		int iX = Mathf.RoundToInt(x);
		int iZ = Mathf.RoundToInt(z);

		return new GridCoordinates(iX, iZ);
	}

}
