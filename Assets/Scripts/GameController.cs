using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public List<Sprite> imagenesParejas;
    public List<Image> parejasImage;
    public int maximasParejasPorImagen = 2;
    List<Image> parejasRestantes;

    public string elementoSeleccionado01="", elementoSeleccionado02="";
    public Image imageSeleccionada01, imageSeleccionada02;
    public static GameController instance;

    private void Awake()
    {
        if(instance!=null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        parejasRestantes = parejasImage;
    }
    private void Start()
    {
        while(parejasRestantes.Count>0)
        {
            int randomNum = Random.Range(0, imagenesParejas.Count);
            for(int i=0;i< maximasParejasPorImagen;i++)
            {
                int randomPosition = Random.Range(0, parejasRestantes.Count);
                parejasImage[randomPosition].sprite = imagenesParejas[randomNum];
                parejasRestantes.RemoveAt(randomPosition);
            }
            imagenesParejas.RemoveAt(randomNum);
        }
    }
    public void CheckParejas()
    {
        Debug.Log(nameof(CheckParejas));
        if(elementoSeleccionado01==elementoSeleccionado02)
        {
            StartCoroutine(HideMatch());
        }
        else
        {
            StartCoroutine(HideNoMatch());
        }
    }
    void Resetear()
    {
        Debug.Log(nameof(Resetear));
        elementoSeleccionado01 = "";
        elementoSeleccionado02 = "";
    }
    IEnumerator HideMatch()
    {
        Debug.Log(nameof(HideMatch));
        FindObjectOfType<EventSystem>().enabled = false;
        yield return new WaitForSeconds(1.25f);
        imageSeleccionada02.transform.gameObject.SetActive(false);
        imageSeleccionada01.transform.gameObject.SetActive(false);
        Resetear();
        FindObjectOfType<EventSystem>().enabled = true;
    }
    IEnumerator HideNoMatch()
    {
        Debug.Log(nameof(HideNoMatch));
        FindObjectOfType<EventSystem>().enabled = false;
        yield return new WaitForSeconds(1.25f);
        imageSeleccionada01.transform.GetChild(0).GetComponent<Image>().enabled = true;
        imageSeleccionada02.transform.GetChild(0).GetComponent<Image>().enabled = true;
        Resetear();
        FindObjectOfType<EventSystem>().enabled = true;
    }
}
