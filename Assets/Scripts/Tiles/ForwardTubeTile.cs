using UnityEngine;

public class ForwardTubeTile : TubeTile
{
    private Vector3 direction;

    public ForwardTubeTile(Vector3 startPosition,Quaternion rotation) : base(startPosition, rotation) {
        direction = rotation * Vector3.up;
    }

    public override Vector3Int GetNextTile()
    {
        return new Vector3Int(Mathf.RoundToInt(direction.x), Mathf.RoundToInt(direction.y), 0);
    }

    public override Waypoints GetTransform(float factor)
    {
        var length = 4 * factor;
        return new Waypoints(startPosition + (direction * length), rotation);
    }

    public override Quaternion GetNextRotation()
    {
        return rotation;
    }
}