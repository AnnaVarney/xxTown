using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public GameObject healthBar;
    public GameObject dieUI;
    public int maxHealth = 100;
    private int health = 100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void attacked(int ap) {
        health -= ap;
        if(health <= 0) {
            health = 0;
            die();
        }
        else {
            StartCoroutine(ChangeColor());
        }
        float fHP = health / (float)maxHealth;
        healthBar.transform.localScale = new Vector3(1, fHP, 1);
    }
    void die() {
        GetComponent<Animator>().Play("die");
        GetComponent<PlayerController>().enabled = false;
    }
    void useItem(int hp) {
        health += hp;
        if (health >= maxHealth) {
            health = maxHealth;
        }
        float fHP = health / (float)maxHealth;
        healthBar.transform.localScale = new Vector3(1, fHP, 1);
    }

    IEnumerator ChangeColor() {
        GetComponent<SpriteRenderer>().color = Color.red;

        yield return new WaitForSeconds(0.2f);

        GetComponent<SpriteRenderer>().color = Color.white;
    }

    void showDieUI() {
        dieUI.SetActive(true);
    }
}
