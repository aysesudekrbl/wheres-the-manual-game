using UnityEngine;

public class CloseButton:MonoBehaviour
{
    public GameObject statsTable;
    public GameObject manualbookbutton;
    public GameObject manualbook;
    
    public void OnMouseDown()
    {
        manualbookbutton.SetActive(true);
        statsTable.SetActive(true);
        manualbook.SetActive(false);
        gameObject.SetActive(false);
    }
}
