using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LosePanel : MonoBehaviour
{
    [SerializeField] Text recordText;
    // Start is called before the first frame update
    void Start()
    {
        int lastRunScore = PlayerPrefs.GetInt("lastRunScore");
        int record = PlayerPrefs.GetInt("record");

        if(lastRunScore > record)
        {
            record = lastRunScore;
            PlayerPrefs.SetInt("record", record);
            recordText.text = record.ToString();
        }
        else
        {
            recordText.text = record.ToString();
        }
            
    }

}
