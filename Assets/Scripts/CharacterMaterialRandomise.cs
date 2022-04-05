using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMaterialRandomise : MonoBehaviour
{
    private int randomValue;
    private Color randomColor;

    // Start is called before the first frame update
    void Start()
    {
        randomValue = Random.Range(100, 256);
        randomColor = new Color(randomValue, randomValue, randomValue);
        GetComponent<MeshRenderer>().material.color = randomColor;
    }
}
