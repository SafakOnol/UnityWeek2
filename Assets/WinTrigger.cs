using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameObject youWinMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        youWinMenuUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            youWinMenuUI.SetActive(true);
            Cursor.visible = true;
        }
    }

}
