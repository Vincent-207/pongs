using UnityEditor.ShaderGraph.Internal;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Tilemaps;

public class backgroundGen : MonoBehaviour
{
    [SerializeField]
    int width, height;
    [SerializeField]
    Color mainTileColor, secondaryTileColor;
    [SerializeField]
    float tileWidth, tileHeight;
    [SerializeField]
    Sprite tileSprite;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       

        for(int y = 0; y < height; y++)
        {
            for(int x = 0; x < width; x++)
            {
                Vector3 spawnPos =  new Vector3((x - width/2) * tileWidth, (y - height/2) * tileHeight);
                if((x + y) % 2 == 0)
                {
                    spawnTile(secondaryTileColor, x ,y ).transform.position = spawnPos;
                }
                else
                {
                    spawnTile(mainTileColor, x , y).transform.position = spawnPos;
                }
            }
        }
        
    }

    GameObject spawnTile(Color color, int x, int y)
    {
        GameObject tileObj = new GameObject("Tile " + x.ToString() + " " + y.ToString());
        SpriteRenderer tileSpriteRenderer = tileObj.AddComponent<SpriteRenderer>();
        tileSpriteRenderer.sprite = tileSprite;
        tileSpriteRenderer.color = color;
        tileSpriteRenderer.sortingOrder = -10;
        tileObj.transform.localScale = new Vector3(tileWidth, tileHeight, 1);
        tileObj.transform.parent = transform;
        return tileObj;
    }
}
