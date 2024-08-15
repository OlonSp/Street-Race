using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarColorScript : MonoBehaviour
{
    [SerializeField] private List<Texture> colorOfCars;
    [SerializeField] private Material MaterialOfCar;

    // Start is called before the first frame update
    void Start()
    {
        MaterialOfCar.mainTexture = colorOfCars[Random.Range(0, colorOfCars.Count)];
    }
}
