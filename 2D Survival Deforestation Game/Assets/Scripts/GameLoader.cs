using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    public GameObject tree;

    // Update is called once per frame
    public void LoadGame()
    {
        Camera camera = Camera.main;
        float halfHeight = camera.orthographicSize*(0.75f);
        float halfWidth = camera.aspect * halfHeight*(0.75f);

        GameObject.Find("PlayButton").SetActive(false);
        for(var i = 0; i < 10; i++)
        {
            Vector2 randomPosition = new Vector2(Random.Range(-1*halfWidth, halfWidth), Random.Range(-1*halfHeight, halfHeight));

            var treeObject = Instantiate(tree, randomPosition, Quaternion.identity);
            treeObject.transform.SetParent(GameObject.Find("Trees").transform);
        }

    }
}

