using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInfo : MonoBehaviour
{

    [Header("Map Bounds")]
    public Vector2Int MaxCoordinate;
    public Vector2Int MinCoordinate;

    public bool IsPositionInBounds(Vector3 pos)
    {
        return pos.x <= MaxCoordinate.x &&
               pos.x >= MinCoordinate.x &&
               pos.y <= MaxCoordinate.y &&
               pos.y >= MinCoordinate.y;
    }

    public Vector3 ClampPosition(Vector3 pos, Vector2 border)
    {
        return new Vector3(
            Mathf.Clamp(pos.x, MinCoordinate.x + border.x - 1, MaxCoordinate.x - border.x + 1),
            Mathf.Clamp(pos.y, MinCoordinate.y + border.y - 1, MaxCoordinate.y - border.y + 1),
            pos.z);
    }

}
