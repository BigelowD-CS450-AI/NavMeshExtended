using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DijkstraTraveler : MonoBehaviour
{
    public Node start;
    public Node goal;
    private LineRenderer lr;
    private List<Node> path = new List<Node>();
    //Vector3 offset = new Vector3(0.0f, -.5f, 0.0f);
    // Start is called before the first frame update
    void Start()
    {
        lr = gameObject.GetComponent<LineRenderer>();
        //GetRandomGoal();
        //GetDijkstraPath();
    }
    void GetDijkstraPath()
    {
        DijkstraAlgo dijkstraAlgo = new DijkstraAlgo(start, goal);
        path = dijkstraAlgo.CalcPath();
        lr.positionCount = 0;
        lr.positionCount = path.Count+1;
        lr.SetPosition(0, transform.position);
        for (int i = 1; i < lr.positionCount; ++i)
            lr.SetPosition(i, path[i-1].transform.position);
        lr.startWidth = 3.0f;
        lr.endWidth = 3.0f;
    }

    private void GetRandomGoal()
    {
        List<Node> allNodes = GameObject.FindObjectsOfType<Node>().ToList();
        allNodes.Remove(start);
        goal = allNodes[Random.Range(0, allNodes.Count)];
        GetDijkstraPath();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path.Count>0)
        {
            transform.position = Vector3.MoveTowards(transform.position, path[0].transform.position, 10.0f * Time.fixedDeltaTime);
            Vector3 offset = path[0].transform.position - transform.position;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, Mathf.Atan2(offset.x, offset.z) * Mathf.Rad2Deg, 0.0f), 90f *Time.fixedDeltaTime);
            if (Vector3.Distance(transform.position, path[0].transform.position) < 0.2)
            {
                start = path[0];
                path.RemoveAt(0);
            }
        }
        else
            GetRandomGoal();
    }
}
