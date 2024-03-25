using System.Collections;
using UnityEngine;

public class ForestGenerator : MonoBehaviour
{
    public GameObject[] treePrefabs;
    public int numberOfTrees = 100;
    public Vector2 spawnAreaSize = new Vector2(100, 100);

    

    private void Start()
    {
        //the starting forest
        GenerateForest();
    }

   
    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RegenerateForest();
        }
    }

    //function to generate the forest
    private void GenerateForest()
    {
        //a loop to spawn the amount of trees
        for (int i = 0; i < numberOfTrees; i++)
        {
            //generating a random position in the spawn area
            Vector3 randomPosition = new Vector3(Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                                                  0,
                                                  Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2));

            //instantiatin a random tree prefab at a random position
            Instantiate(treePrefabs[Random.Range(0, treePrefabs.Length)], randomPosition, Quaternion.identity);
        }
    }

    //function to destroy previous forest and regernerate a new forest 
    private void RegenerateForest()
    {
        GameObject[] trees = GameObject.FindGameObjectsWithTag("Tree");
        foreach (GameObject tree in trees)
        {
            Destroy(tree);
        }

        //new forest
        GenerateForest();
    }
}
