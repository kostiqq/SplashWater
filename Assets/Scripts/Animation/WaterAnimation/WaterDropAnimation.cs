using System.Collections.Generic;
using UnityEngine;

public class WaterDropAnimation
{
    private List<Sprite> frames = new List<Sprite>();
    private float ping = 10.0f;

    public WaterDropAnimation()
    {
        frames.AddRange(Resources.LoadAll<Sprite>("CharacterAnimation"));
    }

    public Sprite GetNext(float dx)
    {
        int frame = (int)((dx * ping) * (frames.Count - 1));
        if (frame >= frames.Count)
        {
            frame = frames.Count - 1;
        }
        Sprite sprite = frames[frame];
        return sprite;
    }
}
