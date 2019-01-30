using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public GameObject apple;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(apple, gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
