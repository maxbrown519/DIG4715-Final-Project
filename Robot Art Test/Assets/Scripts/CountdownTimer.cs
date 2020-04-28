using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startTime = 60f;

    [SerializeField] Text countdownText;

    void Start()
    {
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= 1 * Time.deltaTime;
            print(currentTime);
            countdownText.text = currentTime.ToString("0");
        }

        if (currentTime >= 3.5f) { countdownText.color = Color.black; }
        if (currentTime < 10.5f) { countdownText.color = Color.red; }

        if (currentTime <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}