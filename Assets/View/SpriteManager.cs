using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpriteManager
{
    private static readonly Dictionary<string, Sprite> Sprites;

    public static Sprite GetSprite(string spriteName) => Sprites[spriteName];

    static SpriteManager()
    {
        Sprites = new Dictionary<string, Sprite>();
        var spriteArray = Resources.LoadAll<Sprite>("");
        foreach (var sprite in spriteArray)
        {
            Sprites.Add(sprite.name, sprite);
        }
    }

    public static Sprite GetRandomTileSprite()
    {
        return Sprites["Tile_" + Random.Range(0, 8)];
    }

    public static Sprite GetRandomRoadSprite()
    {
        return Sprites["Road_" + Random.Range(0, 8)];
    }

    public static Sprite GetRandomTreeSprite()
    {
        return Sprites["Tree_" + Random.Range(0, 5)];
    }
}
