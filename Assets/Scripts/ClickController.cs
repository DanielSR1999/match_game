using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickController : MonoBehaviour
{
    GameController gameController;

    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
    public void SeleccionarElemento()
    {
        Debug.Log(nameof(SeleccionarElemento));
        if(gameController.elementoSeleccionado01=="")
        {
            gameController.elementoSeleccionado01 = transform.parent.GetComponent<Image>().sprite.name;
            gameController.imageSeleccionada01= transform.parent.GetComponent<Image>();
        }
        else
        {
            if (gameController.elementoSeleccionado02 == "")
            {
                gameController.elementoSeleccionado02 = transform.parent.GetComponent<Image>().sprite.name;
                gameController.imageSeleccionada02 = transform.parent.GetComponent<Image>();
                gameController.CheckParejas();
            }
        }
    }
}
