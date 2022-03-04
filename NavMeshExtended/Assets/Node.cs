using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EdgeData
{
    public Node node;
    public float weight;
    public EdgeData(Node node, float weight)
    {
        this.node = node;
        this.weight = weight;
    }
    public EdgeData(EdgeData edgeData)
    {
        this = edgeData;
    }
}

public enum WeightCalculationType {distance = 0, mostConnections=1,leastConnections=2, scenicRoute=3};

public class Node : MonoBehaviour
{
    //List of all outgoing node connections
    public List<EdgeData> connections = new List<EdgeData>();
    public List<Node> EditorConnections;// = new Dictionary<Node, EdgeData>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (Node node in EditorConnections)
            connections.Add(new EdgeData(node, Vector3.Distance(transform.position, node.transform.position) ) );
    }

    public void ChangeWeightCalcualtion(WeightCalculationType wct)
    {
        switch (wct)
        {
            case WeightCalculationType.distance :
                foreach (Node node in EditorConnections)
                    connections.Add(new EdgeData(node, Vector3.Distance(transform.position, node.transform.position) ) );
                break;
            case WeightCalculationType.mostConnections :
                foreach (Node node in EditorConnections)
                    connections.Add(new EdgeData(node, node.connections.Count ) );
                break;
            case WeightCalculationType.leastConnections :
                foreach (Node node in EditorConnections)
                    connections.Add(new EdgeData(node, -node.connections.Count ) );
                break;
            case WeightCalculationType.scenicRoute :
                foreach (Node node in EditorConnections)
                    connections.Add(new EdgeData(node, -Vector3.Distance(transform.position, node.transform.position) ) );
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
