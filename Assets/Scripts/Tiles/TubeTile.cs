using UnityEngine;

public abstract class TubeTile
{
    protected Vector3 startPosition;
    protected Quaternion rotation;


    public TubeTile(Vector3 startPosition, Quaternion rotation)
    {
        this.startPosition = startPosition;
        this.rotation = rotation;
    }

    public abstract Waypoints GetTransform(float factor);

    public abstract Vector3Int GetNextTile();

    public abstract Quaternion GetNextRotation();
}