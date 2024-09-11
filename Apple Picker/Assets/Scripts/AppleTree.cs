using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject applePrefab;
    public GameObject branchPrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float changeDirChance = 0.1f;
    public float dropDelay = 1f;
    private float branchDropChance = 0.05f;

    private Rounds roundManager;

    // Start is called before the first frame update
    void Start()
    {
        roundManager = FindObjectOfType<Rounds>();
        Invoke("DropItem", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }

    void FixedUpdate()
    {
        if (Random.value < changeDirChance)
        {
            speed *= -1;
        }
    }

    void DropItem()
    {
        GameObject itemToDrop;

        // Decide whether to drop a branch or an apple
        if (Random.value < branchDropChance) // 5% chance to drop a branch
        {
            itemToDrop = branchPrefab;
        }
        else // 95% chance to drop an apple
        {
            itemToDrop = applePrefab;
        }

        if (itemToDrop != null)
        {
            GameObject droppedItem = Instantiate(itemToDrop);
            droppedItem.transform.position = transform.position;
        }

        Invoke("DropItem", dropDelay); // Continue dropping items
    }

    public void IncreaseDifficulty(int round){
        if (speed > 0){
            speed += round * 0.2f; // Increase speed positively
        }
        else{
            speed -= round * 0.2f; // Increase speed negatively (more negative)
        }
        dropDelay = Mathf.Max(0.1f, dropDelay - round * 0.05f); // Reduce delay between apple drops, but not below 0.1s
    }
}
