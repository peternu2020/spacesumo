using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    private readonly float[] times = new float[] { 5.0f, 20.0f, 30.0f };
    private int currTimeIndex;
    private readonly float zoneSpeed = 0.02f;
    private Vector3[] endScales = new Vector3[4]; // originalScale is first
    private bool[] completed = new bool[] { false, false, false };
    private float journeyLength, restartDelay;

    public GameObject canvas;
    private TextMeshProUGUI displayText;
    private string originalText;
    private bool playerLost;
    private float timeStart, timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        currTimeIndex = 0;
        timeStart = Time.time;
        playerLost = false;
        restartDelay = 3.0f;
        displayText = canvas.GetComponentInChildren<TextMeshProUGUI>();
        originalText = displayText.text;
        endScales[0] = transform.localScale;
        endScales[1] = endScales[0] / 1.2f;
        endScales[2] = endScales[1] / 1.2f;
        endScales[3] = endScales[2] / 1.2f;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed = Time.time - timeStart;
        if (!playerLost)
        {
            if (currTimeIndex < times.Length)
            {
                float timeLeft = times[currTimeIndex] - timeElapsed;
                if (timeLeft < 0.0f)
                {
                    displayText.text = "Shrinking ...";
                    displayText.color = new Color(1.0f, 0.0f, 0.0f);
                }
                else
                {
                    displayText.color = new Color(1.0f, 1.0f, 1.0f);
                    displayText.text = originalText + " " + Mathf.RoundToInt(timeLeft).ToString() + " s";
                }
                if (timeElapsed >= times[currTimeIndex])
                {
                    journeyLength = Vector3.Distance(endScales[currTimeIndex], endScales[currTimeIndex + 1]);
                    float distCovered = (timeElapsed - times[currTimeIndex]) * zoneSpeed;
                    float fracJourney = distCovered / journeyLength;
                    transform.localScale = Vector3.Lerp(endScales[currTimeIndex], endScales[currTimeIndex + 1], fracJourney);
                    if (fracJourney >= 1 && !completed[currTimeIndex])
                    {
                        completed[currTimeIndex] = true;
                        currTimeIndex++;
                    }
                }
            }
            else
            {
                displayText.text = originalText + " 0 s";
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Enemy")
            displayText.text = "Player 1 has lost.";
        else
            displayText.text = "Player 2 has lost.";
        playerLost = true;
        StartCoroutine(EndGame());
    }

    private IEnumerator EndGame()
    {
        while (restartDelay > 0.0f)
        {
            restartDelay -= Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(sceneName: "Level");
    }
}
