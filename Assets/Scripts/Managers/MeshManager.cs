using UnityEngine;
using System.Collections.Generic;

public class MeshManager
{
    private readonly LevelBuilder levelBuilder;
    private readonly PrefabStorage prefabStorage;
    private readonly Grid grid;
    public GameObject movable;
    private Vector3Int nextTilePosition;
    private Quaternion nextRotation;

    private IList<TubeTile> tiles;
    private int tileCount;
    private float progress;

    public MeshManager(LevelBuilder levelBuilder, PrefabStorage prefabStorage, Grid grid)
    {
        this.levelBuilder = levelBuilder;
        this.prefabStorage = prefabStorage;
        this.grid = grid;
        movable = GameObject.Find("WaterDrop");
        tiles = new List<TubeTile>();
        nextTilePosition = new Vector3Int(0, 0, 0);
        nextRotation = Quaternion.identity;
        progress = 0;
        tileCount = 0;
    }

    public void CreateRoad()
    {
        var map = levelBuilder.level.Map;
        foreach (TileMap tile in map.tiles)
        {
            AddRoad((TubeType)tile.type, tile.number);
        }
    }

    public void AddRoad(TubeType type, int number)
    {
        var tileSpawn = grid.CellToLocal(nextTilePosition);
        var start = tileSpawn - (nextRotation * Vector3.up * grid.cellSize.x / 2);
        Object prefab = null;
        Object border = null;
        TubeTile tile = null;
        switch (type)
        {
            case TubeType.Forward:
                tile = new ForwardTubeTile(start, nextRotation);
                prefab = prefabStorage.GetForward(number);
                border = prefabStorage.forwardComplete;
                break;
            case TubeType.Left:
                tile = new LeftTubeTile(start, nextRotation);
                prefab = prefabStorage.GetAngle(number);
                border = prefabStorage.angleComplete;
                break;
            case TubeType.Right:
                tile = new RightTubeTile(start, nextRotation);
                prefab = prefabStorage.GetAngle(number);
                border = prefabStorage.angleComplete;
                nextRotation *= Quaternion.Euler(0, 180, 0);
                break;
        }
        GameObject.Instantiate(prefab, grid.CellToWorld(nextTilePosition), nextRotation, grid.gameObject.transform);
        GameObject.Instantiate(border, grid.CellToWorld(nextTilePosition) + new Vector3(0, 0, -1), nextRotation, grid.gameObject.transform);
        tiles.Add(tile);
        nextTilePosition += tile.GetNextTile();
        nextRotation = tile.GetNextRotation();
    }

    public void Update()
    {
        progress = progress + Time.deltaTime / 2;
        if (progress >= 1)
        {
            progress = 0;
            tileCount++;
            if (tileCount == tiles.Count)
            {
                levelBuilder.Win();
                return;
            }
        }
        var position = tiles[tileCount].GetTransform(progress);
        grid.gameObject.transform.position = new Vector3(position.Position.x * -1, position.Position.y * -1, 10);
        movable.transform.rotation = position.Rotation;
    }
}
