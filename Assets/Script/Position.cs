using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position{
    public enum Direction {
        left = 0,
        up = 1,
        right = 2,
        down = 3
    }

    public static Direction Opposite (Direction pos) {
        return (Direction)(((int)pos + 2) % 4);
    }

    public static Direction TurnLeft (Direction pos) {
        return (Direction)(((int)pos + 1) % 4);
    }

    public static Direction TurnRight(Direction pos) {
        return (Direction)(((int)pos + 3) % 4);
    }
}
