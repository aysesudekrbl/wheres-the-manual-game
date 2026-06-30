using UnityEngine;

public class Manual: MonoBehaviour
{
    public GameObject statsTable;
    public GameObject manualTable;
    public GameObject outofpages;
    
    private void OnMouseDown()
    {
        statsTable.SetActive(false);
        manualTable.SetActive(true);
        outofpages.SetActive(true);
        if(manualTable.GetComponent<SpriteRenderer>() != null)
            manualTable.GetComponent<SpriteRenderer>().enabled = true;
        if(outofpages.GetComponent<SpriteRenderer>() != null)
            outofpages.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.SetActive(false);
    }
    
}
