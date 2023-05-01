using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ptera : MonoBehaviour
{
    public GameObject itemToDrop;
    public float dropChance = .09f;
    public float dropDelay = 0.5f;
    public float moveSpeed = 5f;
    public float leftBound = -10f;
    public float rightBound = 10f;

    private bool hasDroppedItem = false;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime * Vector3.left);
        if(transform.position.x < -12f)
        {
            
            Destroy(gameObject);
        }
        if (!hasDroppedItem && Random.value < dropChance)
        {
            Invoke("DropItem", dropDelay);
            hasDroppedItem = true;
        }
    }

    private void DropItem()
    {
        Instantiate(itemToDrop, transform.position, Quaternion.identity);
    }
    
}
