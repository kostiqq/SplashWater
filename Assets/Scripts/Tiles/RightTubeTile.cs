using UnityEngine;

public class RightTubeTile : TubeTile
{
    public const float radius = 2;

    public RightTubeTile(Vector3 startPosition, Quaternion rotation) : base(startPosition,rotation)
    {

    }

    public override Vector3Int GetNextTile()
    {
        var vector = rotation * new Vector3(1, 0, 0);
        return new Vector3Int(Mathf.RoundToInt(vector.x), Mathf.RoundToInt(vector.y), 0);
    }

    public override Waypoints GetTransform(float factor)
    {
        float angle = -90 * factor;
        var x = -radius * Mathf.Cos(Mathf.Deg2Rad * angle);
        var y = -radius * Mathf.Sin(Mathf.Deg2Rad * angle);
        var localPosition = (new Vector3(x, y, 0) + (Vector3.right * radius));
        var position = rotation * localPosition;
        return new Waypoints(startPosition + position, rotation * Quaternion.Euler(0, 0, angle));
    }

    public override Quaternion GetNextRotation()
    {
        return rotation * Quaternion.Euler(0, 0, -90);
    }
}