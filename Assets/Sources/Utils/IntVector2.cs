using UnityEngine;

public struct IntVector2
{
    public int X;
    public int Y;

    public IntVector2(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Vector3 ToVector3()
    {
        return new Vector3(X, Y);
    }

    public Vector2 ToVector2()
    {
        return new Vector2(X, Y);
    }

}
