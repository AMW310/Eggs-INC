using UnityEngine;
using UnityEngine.AI;

public class ChickenBehaviour : MonoBehaviour
{
    private GameObject target;
    private NavMeshAgent agent;

    void Start()
    {
        target = GameObject.Find("Goal");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        agent.speed = 2f;
        agent.isStopped = false;
        agent.destination = target.transform.position;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == target)
        {
            gameObject.SetActive(false);
        }
    }
}
