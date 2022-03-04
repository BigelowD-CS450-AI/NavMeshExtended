using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class WeightChanger : MonoBehaviour
{
    public Dropdown dd;


    public void Start()
    {
        dd.onValueChanged.AddListener(delegate {
            ChangeWeights();
        });
    }

    // Start is called before the first frame update
    public void ChangeWeights()
    {
        WeightCalculationType wct = (WeightCalculationType)dd.value;
        List<Node> nodes = GameObject.FindObjectsOfType<Node>().ToList();
        foreach (Node node in nodes)
            node.ChangeWeightCalcualtion(wct);
    }

    public void OnDestroy()
    {
        dd.onValueChanged.RemoveAllListeners();
    }
}
