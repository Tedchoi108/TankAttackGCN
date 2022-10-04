using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void CreateTank()
    {
        Vector3 pos = new Vector3(Random.Range(-100, 100), 3.0f, Random.Range(-100, 100));
    }
}
