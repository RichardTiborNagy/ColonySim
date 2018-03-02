using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpriteLoader
{
    public static Dictionary<string, Sprite> Sprites;

    public static Sprite GetSprite(string spriteName) => Sprites[spriteName];

    static SpriteLoader()
    {
        Sprites = new Dictionary<string, Sprite>();
        var spriteArray = Resources.LoadAll<Sprite>("");
        foreach (var sprite in spriteArray)
        {
            Sprites.Add(sprite.name, sprite);
            //Debug.Log(sprite.name);
        }
    }
}
