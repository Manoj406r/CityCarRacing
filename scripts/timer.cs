using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    [Header("timer")]
    public float countdowntimer = 5f;
    [Header("things to stop")]
    public playercontrol playercontrol;
    public playercontrol playercontrol1;
    public playercontrol playercontrol2;
    public playercontrol playercontrol3;
    public opponentcar opponentcar;
    public opponentcar opponentcar1;
    public opponentcar opponentcar2;
    public opponentcar opponentcar3;
    public opponentcar opponentcar4;

    public Text countdowntext;

    void Start()
    {
        StartCoroutine(timecount());
    }

    // Update is called once per frame
    void Update()
    {
        if(countdowntimer >1)
        {
            playercontrol.accelarationforce = 0f;
            playercontrol1.accelarationforce = 0f;
            playercontrol2.accelarationforce = 0f;
            playercontrol3.accelarationforce = 0f;
            opponentcar.movingspeed = 0f;
            opponentcar1.movingspeed = 0f;
            opponentcar2.movingspeed = 0f;
            opponentcar3.movingspeed = 0f;
            opponentcar4.movingspeed = 0f;
        }
        else if(countdowntimer == 0)
        {
            playercontrol.accelarationforce = 300f;
            playercontrol1.accelarationforce = 300f;
            playercontrol2.accelarationforce = 300f;
            playercontrol3.accelarationforce = 300f;
            opponentcar.movingspeed = 12f;
            opponentcar1.movingspeed = 13f;
            opponentcar2.movingspeed = 14f;
            opponentcar3.movingspeed = 9f;
            opponentcar4.movingspeed = 8f;
        }
    }
    IEnumerator timecount()
    {
        while(countdowntimer > 0)
        {
            countdowntext.text = countdowntimer.ToString();
            yield return new WaitForSeconds(1f);
            countdowntimer--;
        }

        countdowntext.text = "GO";
        yield return new WaitForSeconds(1f);
        countdowntext.gameObject.SetActive(false);
    }
}
