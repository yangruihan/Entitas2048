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

    public IntVector2(Vector2 v)
    {
        X = (int)v.x;
        Y = (int)v.y;
    }

    public IntVector2(Vector3 v)
    {
        X = (int)v.x;
        Y = (int)v.y;
    }

    public Vector3 ToVector3()
    {
        return new Vector3(X, Y);
    }

    public Vector2 ToVector2()
    {
        return new Vector2(X, Y);
    }

    public override string ToString()
    {
        return string.Format("[IntVector2] ({0}, {1})", X, Y);
    }

    public static IntVector2 operator +(IntVector2 v1, IntVector2 v2)
    {
        return new IntVector2(v1.X + v2.X, v1.Y + v2.Y);
    }
}
