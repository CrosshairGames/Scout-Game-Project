using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(objToSpawn, gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
