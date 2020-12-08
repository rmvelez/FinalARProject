using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public GameObject battleUI;
    private int playerHealth;
    public Text playerHealthText;

    private bool battleReady;
    public GameObject hitBox;
    public GameObject hitBoxSpawn;
    public float startTimeBetweenHits;
    private float timeBetweenHits;
    private float durationTime;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 100;
        battleReady = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(battleReady == true)
        {
            if (timeBetweenHits <= 0)
            {
                Instantiate(hitBox, hitBoxSpawn.transform.position, hitBox.transform.rotation);
                durationTime = 5f;
                timeBetweenHits = startTimeBetweenHits;
            }
            if (durationTime <= 0)
            {
                timeBetweenHits -= Time.deltaTime;
            }

            durationTime -= 1f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Foe")
        {
            battleUI.SetActive(true);
            playerHealthText.text = "P1: " + playerHealth;
            battleReady = true;
        }
    }
}
