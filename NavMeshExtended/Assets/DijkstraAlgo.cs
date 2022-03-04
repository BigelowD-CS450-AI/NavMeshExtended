using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DijkstraAlgo
{
    public Node start, goal;
    public List<Node> shortestPath = new List<Node>();
    private List<NodeRecord> OpenNodes;
    private List<NodeRecord> ClosedNodes;
    public DijkstraAlgo(Node start, Node goal)
    {
        this.start = start;
        this.goal = goal;
    }
    
    private class NodeRecord
    {
        public Node node;
        public NodeRecord connection;
        public float costSoFar = Mathf.Infinity;
    }

    public List<Node> CalcPath()
    {
        NodeRecord startRecord = new NodeRecord();
        startRecord.node = start;
        //startRecord.connection = null;
        startRecord.costSoFar = 0.0f;
        OpenNodes = new List<NodeRecord>();
        OpenNodes.Add(startRecord);
        ClosedNodes = new List<NodeRecord>();

        NodeRecord current = new NodeRecord();
        while (OpenNodes.Count > 0)
        {
            Debug.Log(startRecord);
            current = SmallestCostSoFarRecordInOpenRecords();
            Debug.Log(current.costSoFar);
            Debug.Log(current.node == goal);
            if (current.node == goal)
                break;
            //Debug.Log(current.node.connections.Count);
            foreach (EdgeData connection in current.node.connections)
            {
                Debug.Log(connection);
                NodeRecord endNodeRecord;
                Node endNode = connection.node;
                float endNodeCost = current.costSoFar + connection.weight;

                if (ContainedInClosedNodes(endNode))
                    continue;
                else if (ContainedInOpenedNodes(endNode))
                {
                    endNodeRecord = FindInOpenNodes(endNode);
                    if (endNodeRecord.costSoFar <= endNodeCost)
                        continue;
                    //this code is not in pseudo code.
                    //just believe this is needed
                    else
                    {
                        endNodeRecord.node = endNode;
                        endNodeRecord.costSoFar = endNodeCost;
                    }
                    //end of not in pseudo code
                }
                else
                {
                    endNodeRecord = new NodeRecord();
                    endNodeRecord.node = endNode;
                }
                endNodeRecord.costSoFar = endNodeCost;
                endNodeRecord.connection = current;
                if (!ContainedInOpenedNodes(endNode))
                    OpenNodes.Add(endNodeRecord);
            }
            OpenNodes.Remove(current);
            ClosedNodes.Add(current);
        }
        Debug.Log(current.node);
        if (current.node != goal)
            return null;
        else
        {
            List<Node> path = new List<Node>();
            while (current.node != start)
            {
                path.Add(current.node);
                current = current.connection;
            }
            path.Reverse();
            return path;
        }
    }

    private NodeRecord FindInOpenNodes(Node node)
    {
        foreach (NodeRecord nodeRecord in OpenNodes)
            if (nodeRecord.node == node)
                return nodeRecord;
        //this is here for the compiler
        //in the algorithm it always checks if the
        //node exsist in the open list first
        return new NodeRecord();
    }

    public bool ContainedInOpenedNodes(Node node)
    {
        foreach (NodeRecord nodeRecord in OpenNodes)
            if (nodeRecord.node == node)
                return true;
        return false;
    }

    public bool ContainedInClosedNodes(Node node)
    {
        foreach (NodeRecord nodeRecord in ClosedNodes)
            if (nodeRecord.node == node)
                return true;
        return false;
    }

    private NodeRecord SmallestCostSoFarRecordInOpenRecords()
    {
        NodeRecord smallest = new NodeRecord();
        foreach (NodeRecord nodeRecord in OpenNodes)
            if (nodeRecord.costSoFar < smallest.costSoFar)
                smallest = nodeRecord;
        return smallest;
    }
}
