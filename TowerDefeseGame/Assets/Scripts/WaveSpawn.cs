using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawn : MonoBehaviour {

    public GameObject enemy;
    public Text countDownText;
    public Transform start;
    private float countDown = 2;
    private float MaxCountDown = 5;
    private int waveNumber = 1;
    private float timeDelay = 0f;
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        countDown -= Time.deltaTime;
        countDownText.text = Mathf.Round(countDown).ToString();
        if (countDown <= 0f)
        {
            countDown = MaxCountDown;
            countDownText.text = countDown.ToString();
            StartCoroutine(SpawnDelay());
        }
	}
    void SpawnEnemy()
    {
        Instantiate(enemy, start.position, start.rotation);
    }
    IEnumerator SpawnDelay()
    {
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.4f);
        }
        waveNumber++;
    }
}
