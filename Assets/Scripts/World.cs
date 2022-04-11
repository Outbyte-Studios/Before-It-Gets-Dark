using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {
    [SerializeField] Sprite tile;
    [SerializeField] int width;
    [SerializeField] int height;
    [SerializeField] float frequency;
    [SerializeField] float seed;
    
    void Start() {
        seed = Random.Range(-9999, 9999);
        Generate();
    }

    public void Generate() {
        for(int x = 0; x < width * 2; x++) {
            for(int y = 0; y < height * 2; y++) {
                if(Mathf.PerlinNoise((x + seed) * frequency, (y + seed) * frequency) < 0.5f) {
                    GameObject block = new GameObject("Block");
                    block.transform.parent = this.transform;
                    block.AddComponent<SpriteRenderer>();
                    block.GetComponent<SpriteRenderer>().sprite = tile;
                    block.transform.position = new Vector2(x, y);
                    block.transform.localScale = new Vector3(3.125f, 3.125f, 1.0f);
                    block.AddComponent<BoxCollider2D>();
                }
            }
        }
    }
}
