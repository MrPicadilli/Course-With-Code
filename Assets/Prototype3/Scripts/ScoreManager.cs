using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public Transform startingPoint;
    public MoveLeft bg;
    public PlayerController3 playerController;
    private float bgSpeed;
    public float multiplicator = 1.0f;
    private float score = 0.0f;
    private float lerpSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        bgSpeed = bg.speed;
        playerController.gameOver = true;
        StartCoroutine(PlayIntro());
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerController.gameOver)
        {
            multiplicator = bgSpeed < bg.speed ? 2.0f : 1.0f;
            score += Time.deltaTime * multiplicator;
            Debug.Log(score);
        }

    }
    IEnumerator PlayIntro()
    {
        Vector3 startPos = playerController.transform.position;
        Vector3 endPos = startingPoint.position;
        float journeyLength = Vector3.Distance(startPos, endPos);
        float startTime = Time.time;
        float distanceCovered = (Time.time - startTime) * lerpSpeed;
        float fractionOfJourney = distanceCovered / journeyLength;
        playerController.GetComponent<Animator>().SetFloat("Speed_Multiplier",
        0.5f);
        while (fractionOfJourney < 1)
        {
            distanceCovered = (Time.time - startTime) * lerpSpeed;
            fractionOfJourney = distanceCovered / journeyLength;
            playerController.transform.position = Vector3.Lerp(startPos, endPos,
            fractionOfJourney);
            yield return null;
        }
        playerController.GetComponent<Animator>().SetFloat("Speed_Multiplier",
        1.0f);
        playerController.gameOver = false;

    }
}
