using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public List<Sprite> imagenesParejas;
    public List<Image> parejasImage;
    public int maximasParejasPorImagen = 2;
    List<Image> parejasRestantes;

    private void Awake()
    {
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
}
