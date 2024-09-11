using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    void Start(){
        basketList = new List<GameObject>();
        for (int i=0; i <numBaskets; i++)
        {
            GameObject tBasketGo = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY*i);
            tBasketGo.transform.position = pos;
            basketList.Add(tBasketGo);
        }
    }

    public void AppleMissed(){
        // Destroy all of the falling Apples
        GameObject[] appleArray=GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tempGo in appleArray){
            Destroy(tempGo);
        }

        int basketIndex = basketList.Count -1;
        GameObject basketGo = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(basketGo);

        if (basketList.Count==0){
            SceneManager.LoadScene(2);
        }
    }

    public void BranchMissed(){
        //Destroy the falling Branches
        GameObject[] appleArray=GameObject.FindGameObjectsWithTag("Branch");
        foreach (GameObject tempGo in appleArray){
            Destroy(tempGo);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
