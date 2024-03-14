using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehaviour : MonoBehaviour
{
    BehaviourTree tree;


    // Start is called before the first frame update
    void Start()
    {
        tree = new BehaviourTree();
        Node wander = new Node("Walk around");
        Node idle = new Node("Stay still");
        Node hunt = new Node("Look for Player");
        Node attack = new Node("Attack the Player");

        wander.AddChild(idle);
        wander.AddChild(hunt);
        wander.AddChild(attack);

        tree.AddChild(wander);
        tree.PrintTree();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
