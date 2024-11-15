using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float count;

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        Spawner.ChickenLanded += IncreaseCount;
    }

    void OnDisable()
    {
        Spawner.ChickenLanded -= IncreaseCount;
    }

    private void IncreaseCount(GameObject obj)
    {
        if (obj.tag == "Chicken")
        {
            ++count;
        }

        if (obj.tag == "Evil")
        {
            obj.GetComponent<EvilBehaviour>().chickenCount = count;
        }
    }
}
