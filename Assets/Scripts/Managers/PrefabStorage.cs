using UnityEngine;
using System.Collections.Generic;

public class PrefabStorage
{
    private List<Object> forwardPrefabs;
    private List<Object> anglePrefabs;
    public Object forwardComplete { get; private set; }
    public Object angleComplete { get; private set; }

    public PrefabStorage()
    {
        forwardPrefabs = new List<Object>();
        anglePrefabs = new List<Object>();
        forwardPrefabs.AddRange(Resources.LoadAll("forwardPrefabs"));
        anglePrefabs.AddRange(Resources.LoadAll("anglePrefabs"));
        forwardComplete = Resources.Load("forwardComplete");
        angleComplete = Resources.Load("rotateComplete");
    }

    public Object GetForward(int number)
    {
        return forwardPrefabs[number];
    }
    public Object GetAngle(int number)
    {
        return anglePrefabs[number];
    }
}
