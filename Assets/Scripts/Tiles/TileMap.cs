using System;

[Serializable]
public class TileMap
{
    public int type;
    public int number;

    public TileMap(int type, int number)
    {
        this.type = type;
        this.number = number;
    }
}
