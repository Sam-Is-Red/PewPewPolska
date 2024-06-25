using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deploy_Oil_Slick : MonoBehaviour
{
    public GameObject oilSlickPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(OilWave());
    }

    private void spawnEnemy() {
        GameObject a = Instantiate(oilSlickPrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(-screenBounds.x + 17f, screenBounds.x), screenBounds.y);

    }

    IEnumerator OilWave() {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
        
    }

}