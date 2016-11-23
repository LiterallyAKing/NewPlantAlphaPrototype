public enum GridFarDirection{
	//N, NE, E, SE, S, SW, W, NW
	N, NNE, NE, NEE, E, SEE, SE, SSE, S, SSW, SW, SWW, W, NWW, NW, NNW
}

public static class GridFarDirectionExtensions{
	public static GridFarDirection Opposite (this GridFarDirection direction){
		return (int)direction < 8 ? (direction + 8) : (direction - 8);
	}
}