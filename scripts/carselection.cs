using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class carselection : MonoBehaviour
{
    [Header("buttons and canvas")]
    public Button nextbutton;
    public Button previousbutton;

    [Header("cameras")]
    public GameObject cam1;
    public GameObject cam2;
    [Header("buttons and canvas")]
    public GameObject selectioncanvas;
    public GameObject Skipbutton;
    public GameObject playbutton;

    private int currentcar;
    private GameObject[] carlist;
    private void Awake()
    {
        selectioncanvas.SetActive(false);
        playbutton.SetActive(false);
        cam2.SetActive(false);
        choosecar(0);

    }
    private void Start()
    {

        currentcar = PlayerPrefs.GetInt("carselected");
        carlist = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            carlist[i] = transform.GetChild(i).gameObject;

        foreach (GameObject go in carlist)
            go.SetActive(false);
        if (carlist[currentcar])
            carlist[currentcar].SetActive(true);

    }
    private void choosecar(int index)
    {
        previousbutton.interactable = (currentcar != 0);
        nextbutton.interactable = (currentcar != transform.childCount - 1);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == index);
        }
    }

    public void switchcar(int switchcars)
    {
        currentcar += switchcars;
        choosecar(currentcar);
    }
    public void playgame()
    {
        PlayerPrefs.SetInt("carselected", currentcar);
        SceneManager.LoadScene("scene_day");
    }
    public void skipbutton()
    {
        selectioncanvas.SetActive(true);
        playbutton.SetActive(true);
        Skipbutton.SetActive(false);
        cam1.SetActive(false);
        cam2.SetActive(true);
    }
}
