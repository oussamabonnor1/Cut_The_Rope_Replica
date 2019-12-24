using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkGenerator : MonoBehaviour
{
    public Rigidbody2D rb, previousBody;
    public GameObject linkPrefab;
    public GameObject weight;
    public int chainLength;
    public float weightDistance;

    // Start is called before the first frame update
    void Start()
    {
        previousBody = rb;
        for (int i = 0; i < chainLength; i++)
        {
            GameObject link = Instantiate(linkPrefab, transform);
            link.GetComponent<HingeJoint2D>().connectedBody = previousBody;
            previousBody = link.GetComponent<Rigidbody2D>();
        }
        linkWeight(previousBody);
    }

    void linkWeight(Rigidbody2D previousBody){
        HingeJoint2D weightJoint = weight.AddComponent<HingeJoint2D>();
        weightJoint.autoConfigureConnectedAnchor = false;
        weightJoint.connectedBody = previousBody;
        weightJoint.connectedAnchor = new Vector2(0,-weightDistance);
    }
}
