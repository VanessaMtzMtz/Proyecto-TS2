using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningsScript : MonoBehaviour
{

    public float TimeText = 3;
    

    // Update is called once per frame
    void Update()
    {
        TimeText -= Time.deltaTime;
        if (TimeText <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
