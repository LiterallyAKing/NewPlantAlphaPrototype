﻿public enum GridDirection{
	N, NE, E, SE, S, SW, W, NW
}

public static class GridDirectionExtensions{
	public static GridDirection Opposite (this GridDirection direction){
		return (int)direction < 4 ? (direction + 4) : (direction - 4);
	}
}