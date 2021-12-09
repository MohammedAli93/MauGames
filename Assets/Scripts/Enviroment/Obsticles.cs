using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsticles : MonoBehaviour
{

    PlayerMove move;
    public GameObject obsticle;
    // Start is called before the first frame update
    void Start()
    {
        move = GameObject.FindObjectOfType<PlayerMove>();
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            move.Die(); 
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
