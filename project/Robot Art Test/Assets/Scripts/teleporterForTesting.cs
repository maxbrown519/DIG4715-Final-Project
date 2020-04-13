using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporterForTesting : MonoBehaviour
{
    private GameObject player;
    public Transform NextLocation;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.position = NextLocation.transform.position;
        }
    }
}
