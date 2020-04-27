using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleporterForTesting : MonoBehaviour
{
    private GameObject player;
    public Transform NextLocation;
    private GameObject gage;
    public float level1Complete = 0;
    public float level2Complete = 0;
    public float level3Complete = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gage = GameObject.Find("gage");
        if (this.gameObject.tag == "win")
        {
            if (gage.GetComponent<dontdestrod>().level1 ==0 || gage.GetComponent<dontdestrod>().level2 ==0 || gage.GetComponent<dontdestrod>().level3 == 0) {
                this.gameObject.SetActive(false);
            }
            if (gage.GetComponent<dontdestrod>().level1 == 1)
            {
                if (gage.GetComponent<dontdestrod>().level2 == 1)
                {
                    if (gage.GetComponent<dontdestrod>().level3 == 1)
                    {
                        this.gameObject.SetActive(true);
                    }
                }
            }
        }
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
                gage.GetComponent<dontdestrod>().level1 = 1;
                //load teleport level
                SceneManager.LoadScene("teleporting Scene", LoadSceneMode.Single);
            }
            if (this.gameObject.tag == "comLevel")
            {
                gage.GetComponent<dontdestrod>().level2 = 1;
                //load compactor level
                SceneManager.LoadScene("Compactor Scene", LoadSceneMode.Single);
            }
            if (this.gameObject.tag == "shootingLevel")
            {
                gage.GetComponent<dontdestrod>().level3 = 1;
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

            if (this.gameObject.tag == "win")
            {
                gage.GetComponent<dontdestrod>().level1 = 0;
                gage.GetComponent<dontdestrod>().level2 = 0;
                gage.GetComponent<dontdestrod>().level3 = 0;
                SceneManager.LoadScene("Victory Screen", LoadSceneMode.Single);
            }
        }
    }
}
