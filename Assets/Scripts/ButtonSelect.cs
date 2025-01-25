using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelect : MonoBehaviour
{
    public Button selectedButtonOnWake;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        selectedButtonOnWake.Select();
    }
}
