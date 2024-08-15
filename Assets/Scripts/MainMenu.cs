using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text coinText;
    [SerializeField] private TextMeshPro recordText;
    // Start is called before the first frame update
    void Start()
    {
        int coins = PlayerPrefs.GetInt("coins");
        int record = PlayerPrefs.GetInt("record");
        coinText.text = coins.ToString();
        recordText.text = "Your record: " + record.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
