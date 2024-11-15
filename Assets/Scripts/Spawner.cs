using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public static event Action<GameObject> ChickenLanded; 

    [SerializeField] private GameObject chickenPrefab;
    [SerializeField] private GameObject evilPrefab;
    private GameObject spawnPos;

    void Awake()
    {
        spawnPos = this.gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SpawnChance();
        }
    }

    public void SpawnChance()
    {
        float rnd = Random.Range(1, 100);
        if (rnd % 10 != 0)
        {
            SpawnChicken(spawnPos.transform.position);
        }
        else
        {
            SpawnEvil(spawnPos.transform.position);
        }
    }

    public GameObject SpawnChicken(Vector3 position)
    {
        GameObject chicken = Object.Instantiate(chickenPrefab, position, Quaternion.identity);
        ChickenBehaviour script = chicken.GetComponent<ChickenBehaviour>();

        if (ChickenLanded != null)
            ChickenLanded(chicken);

        return chicken;
    }
    
    public GameObject SpawnEvil(Vector3 position)
    {
        GameObject eChicken = Object.Instantiate(evilPrefab, position, Quaternion.identity);
        EvilBehaviour script = eChicken.GetComponent<EvilBehaviour>();

        if (ChickenLanded != null)
            ChickenLanded(eChicken);

        return eChicken;
    }


}
