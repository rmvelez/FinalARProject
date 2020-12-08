using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoeControl : MonoBehaviour
{
    public GameObject healthUI;
    private int foeHealth;
    public Text foeHealthText;

    // Start is called before the first frame update
    void Start()
    {
        foeHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (foeHealth <= 0)
        {
            this.gameObject.SetActive(false);
            healthUI.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Friend")
        {
            healthUI.SetActive(true);
            foeHealthText.text = "P2: " + foeHealth;
        }
        if (other.gameObject.tag == "GoodHitBox")
        {
            foeHealth -= 5;
            foeHealthText.text = "P2: " + foeHealth;
        }
    }
}
