using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField]
    Transform UpperPoint;
    [SerializeField]
    Transform LowerPoint;

    [SerializeField]
    GameObject Obstacle;

    [SerializeField]
    GameObject Block;

    [SerializeField]
    private GameObject lastBlock;

    public static TileSpawner instance;
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
       // Spawn();
    }
    public void Spawn()
    {
        //print("a0");
        StartCoroutine(SpawnBlock());
    }
    
    public IEnumerator SpawnBlock()
    {
        
        print("hello");
       GameObject block = Instantiate(Block, new Vector2(lastBlock.transform.position.x + 26, lastBlock.transform.position.y), transform.rotation);
       GameObject newObstacle = Instantiate(Obstacle, new Vector2(lastBlock.transform.position.x + Random.Range(26, 42),Random.Range(LowerPoint.position.y, UpperPoint.position.y)), transform.rotation);
        
        GameObject.Destroy(lastBlock, 10f);
      lastBlock = block;
        newObstacle.transform.parent = lastBlock.transform;
       yield return new WaitForSeconds(0f);
        
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
