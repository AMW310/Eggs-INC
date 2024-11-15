using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EvilBehaviour : MonoBehaviour
{
    private GameObject target;
    private NavMeshAgent agent;

    public float chickenCount = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void OnEnable()
    {
        Spawner.ChickenLanded += Attack;
    }
    void OnDisable()
    {
        Spawner.ChickenLanded -= Attack;
    }

    // Update is called once per frame
    void Update()
    {
        if(chickenCount == 0)
        {
            Wander();
        }
    }

    private void Attack(GameObject chickTarget)
    {
        if (chickTarget.tag == "Chicken")
        {
            agent.speed = 4f;
            agent.isStopped = false;
            agent.destination = chickTarget.transform.position;
            target = chickTarget;
        }
    }

    void Wander()
    {
        Vector3 rndPos = new Vector3(Random.Range(-25.0f, 25.0f), 0, Random.Range(-25.0f, 25.0f));
        agent.speed = 2f;
        agent.isStopped = false;
        agent.destination = rndPos;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == target)
        {
            target.SetActive(false);
            target = GameObject.FindWithTag("Chicken");
            Attack(target);
            Debug.Log("Chicken Eaten");
        }
    }
}