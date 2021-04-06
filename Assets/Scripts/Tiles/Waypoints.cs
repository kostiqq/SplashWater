using UnityEngine;

public struct Waypoints
{
    Vector3 position;
    Quaternion rotation;

    public Waypoints(Vector2 position, Quaternion rotation)
    {
        this.position = position;
        this.rotation = rotation;
    }
    public Quaternion Rotation
    {
        get
        {
            return rotation;
        }
        set
        {
            rotation = value;
        }
    }
    public Vector3 Position
    {
        get
        {
            return position;
        }

        set
        {
            position = value;
        }
    }
}