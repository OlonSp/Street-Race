using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBonus : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        switch (Random.Range(0, 3))
        {
            case 0:
                gameObject.SetActive(false);
                break;
            case 1:
                gameObject.SetActive(false);
                break;
        }

    }

}
