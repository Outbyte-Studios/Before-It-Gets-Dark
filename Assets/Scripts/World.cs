using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {
    public Sprite dust;
    public Sprite strongDust;
    public Sprite stone;

    public int width = 100;
    public float multiplier = 40.0f;
    public float addition = 10.0f;
    public float frequency = 0.05f;
    public float seed;
    
    void Start() {
        seed = Random.Range(-9999, 9999);

        Generate();
    }

    public void Generate() {
        for(int x = 0; x < width; x++) {
            float height = Mathf.PerlinNoise((x + seed) * frequency, seed * frequency) * multiplier + addition;
            for(int y = 0; y < height; y++) {
                GameObject block = new GameObject("Block");
                block.transform.parent = this.transform;
                block.layer = LayerMask.NameToLayer("Ground");
                block.AddComponent<SpriteRenderer>();
                block.transform.position = new Vector2(x, y);
                block.transform.localScale = new Vector3(3.125f, 3.125f, 1.0f);
                block.AddComponent<BoxCollider2D>();
                block.GetComponent<BoxCollider2D>().size = new Vector3(0.32f, 0.32f, 1.0f);

                if(y < height - 20) {
                    block.GetComponent<SpriteRenderer>().sprite = stone;
                } else if(y < height - 5) {
                    block.GetComponent<SpriteRenderer>().sprite = strongDust;
                } else if(y < height) {
                    block.GetComponent<SpriteRenderer>().sprite = dust;
                }
            }
        }
    }
}
