using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finish : MonoBehaviour
{
    [Header("finish ui var")]
    public GameObject finishui;
    public GameObject playerui;
    public GameObject playercar;
    public GameObject steeringwheel;
    public GameObject Arrowsvertical;
    public GameObject brake;
    public GameObject menu;

    [Header("win/lose status")]
    public Text status;


    private void Start()
    {
        StartCoroutine(waitforthefinishui());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(finishzonetimer());
            gameObject.GetComponent<BoxCollider>().enabled = false;
            status.text = "You Win";
            status.color = Color.black;
        }
        else if(other.gameObject.tag =="opponentcar")
        {
            StartCoroutine(finishzonetimer());
            gameObject.GetComponent<BoxCollider>().enabled = false;
            status.text = "You Lose ";
            status.color = Color.red;
        }
    }
    IEnumerator waitforthefinishui()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(25f);
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }

    IEnumerator finishzonetimer()
    {
        finishui.SetActive(true);
        playerui.SetActive(false);
        playercar.SetActive(false);
        steeringwheel.SetActive(false);
        Arrowsvertical.SetActive(false);
        brake.SetActive(false);
        menu.SetActive(false);
        

        yield return new WaitForSeconds(5f);
        Time.timeScale = 0f;
    }
}
