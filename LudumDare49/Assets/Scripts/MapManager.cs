using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public Texture2D Map;
    public GameObject Player;
    public List<MapTile> MapTiles;

    public void GenerateMap()
    {
        Debug.Log("GenerateMap", this);
        DeleteMap();

        for (int x = 0; x < Map.width; x++)
        {
            for (int y = 0; y < Map.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }

    private void GenerateTile(int x, int y)
    {
        var color = Map.GetPixel(x, y);
        var tilePrefab = MapTiles.FirstOrDefault(x => x.color == color);
        if(tilePrefab != null)
        {
            var pos = new Vector2(x, y);
            if (tilePrefab.IsSpawn)
            {
                SetPlayerToSpawn(pos);
            }
            var newTile = Instantiate(tilePrefab.tilePrefab);
            newTile.transform.position = pos;
            newTile.transform.SetParent(transform);
        }
        else
        {
            Debug.LogError($"canot spawn tile {x} {y} color {color} unknown", this);
            return;
        }
    }

    private void SetPlayerToSpawn(Vector3 pos)
    {
        Player.transform.position = pos;
    }

    public void DeleteMap()
    {
        //https://stackoverflow.com/questions/46358717/how-to-loop-through-and-destroy-all-children-of-a-game-object-in-unity
        int i = 0;
        GameObject[] allChildren = new GameObject[transform.childCount];
        foreach (Transform child in transform)
        {
            allChildren[i] = child.gameObject;
            i += 1;
        }

        //Now destroy them
        foreach (GameObject child in allChildren)
        {
            DestroyImmediate(child.gameObject);
        }

    }
}

[System.Serializable]
public class MapTile{
    public Color color;
    public GameObject tilePrefab;
    public bool IsSpawn = false;
}
