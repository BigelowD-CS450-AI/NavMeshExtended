using UnityEngine;
using UnityEngine.AI;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private NavMeshAgent agent;
    void Start()
    {
        //camera = GameObject.FindObjectOfType<Camera>();
        agent = gameObject.GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
                agent.SetDestination(hit.point);
        }
    }
}
