using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            if (this.gameObject.tag == "teleportingLevel")
            {
                //load teleport level
                SceneManager.LoadScene("teleporting Scene", LoadSceneMode.Single);
            }
            if (this.gameObject.tag == "comLevel")
            {
                //load compactor level
                SceneManager.LoadScene("Compactor Scene", LoadSceneMode.Single);
            }
            if (this.gameObject.tag == "shootingLevel")
            {
                //load shooting level
                SceneManager.LoadScene("ShootingLevel", LoadSceneMode.Single);

            }
            if (this.gameObject.tag == "telEnd")
            {
                //load hub
                SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            }
            if (this.gameObject.tag == "comEnd")
            {
                //load hub
                SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            }
            if (this.gameObject.tag == "ShootEnd")
            {
                //load hub
                SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            }
            //player.transform.position = NextLocation.transform.position;
        }
    }
}
