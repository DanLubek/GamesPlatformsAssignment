using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetManager : MonoBehaviour
{
    public static int score = 0;

    public bool isShootingTargets = false;

    float t = 30;

    public List<GameObject> targets = new List<GameObject>();

    public TMP_Text scoreText, bestText, newRecordText, countdownText, timerText;

    int best;

    bool canDespawn = false;

    private void Start()
    {
        isShootingTargets = false;        

        targets.Add(GameObject.Find("target_001"));
        targets.Add(GameObject.Find("target_001 (1)"));
        targets.Add(GameObject.Find("target_001 (2)"));
        targets.Add(GameObject.Find("target_001 (3)"));
        targets.Add(GameObject.Find("target_001 (4)"));

        scoreText = GameObject.Find("Score_Text").GetComponent<TMP_Text>();
        bestText = GameObject.Find("Best_Text").GetComponent<TMP_Text>();
        newRecordText = GameObject.Find("NewBest_Text").GetComponent<TMP_Text>();
        countdownText = GameObject.Find("Countdown_Text").GetComponent<TMP_Text>();
        timerText = GameObject.Find("Timer_Text").GetComponent<TMP_Text>();

        scoreText.text = "Score : " + 0.ToString();

        if (PlayerPrefs.HasKey("bestScore"))
        {
            best = PlayerPrefs.GetInt("bestScore");
        }
        else
        {
            best = 0;
        }
        bestText.text = "Best : " + best.ToString();

        if (newRecordText != null && newRecordText.enabled)
        {
            newRecordText.enabled = false;
        }

        if (countdownText != null && countdownText.enabled)
        {
            countdownText.text = 3.ToString();
            countdownText.enabled = false;
        }

        score = 0;

        DespawnOrRespawnAll(true, false);

        canDespawn = true;

        enabled = false;
    }

    void Update()
    {
        if (isShootingTargets)
        {
            scoreText.text = "Score : " + score.ToString();

            t -= Time.deltaTime;
            int timer = Mathf.RoundToInt(t);
            timerText.text = timer.ToString();
            if (timer <= 0)
            {
                EndGame();
            }
        }
        
        if (canDespawn)
        {
            for (int i = 0; i < targets.Count; i++)
            {
                if (!targets[i].activeSelf)
                {
                    continue;
                }
                else if (targets[i].activeSelf)
                {
                    DespawnOrRespawnAll(true, false);
                }
            }
        }        
    }

    void DespawnOrRespawnAll(bool despawn, bool respawn)
    {
        foreach (GameObject target in targets)
        {
            if (despawn)
            {
                target.GetComponent<TargetMove>().Disappear(respawn);                
            }
            else
            {
                target.GetComponent<TargetMove>().Reappear();
            }            
        }
    }

    public void StartGame()
    {
        canDespawn = false;
        StartCoroutine(PreGameWait());
        DespawnOrRespawnAll(false, true);        
        scoreText.text = "Score : " + 0.ToString();
        newRecordText.enabled = false;
        timerText.text = 30.ToString();
    }

    IEnumerator PreGameWait()
    {
        countdownText.enabled = true;
        countdownText.text = 3.ToString();
        yield return new WaitForSeconds(1f);
        countdownText.text = 2.ToString();
        yield return new WaitForSeconds(1f);
        countdownText.text = 1.ToString();
        yield return new WaitForSeconds(1f);
        countdownText.text = "START";
        score = 0;
        isShootingTargets = true;
        yield return new WaitForSeconds(1.5f);
        countdownText.enabled = false;
    }

    public void EndGame()
    {
        isShootingTargets = false;
        foreach (GameObject target in targets)
        {
            target.GetComponent<TargetMove>().StopAllCoroutines();
        }
        DespawnOrRespawnAll(true, false);
        canDespawn = true;
        timerText.text = 0.ToString();
        if (score > best)
        {
            bestText.text = "Best : " + score;
            best = score;
            PlayerPrefs.SetInt("bestScore", best);
            newRecordText.enabled = true;
        }
        Destroy(this);
    }
}
