using TMPro;
using UnityEngine;


public class itemManager : MonoBehaviour
{
    [Header("Text Components")] 
    [SerializeField] private TextMeshProUGUI item;
    [SerializeField] private TextMeshProUGUI item2;
    [SerializeField] private TextMeshProUGUI item3;
    [SerializeField] private TextMeshProUGUI item4;
    [SerializeField] private TextMeshProUGUI item5;

    [Header("Other")] 
    public GameObject itemClass;
    

    private int index;
    
    private void Start()
    {
        item2.text = string.Empty;
        item3.text = string.Empty;
        item4.text = string.Empty;
        item5.text = string.Empty;
    }

    void Update()
    {
        if (item != null && itemClass != null)
        {
            ObtainItem(item.text);
        }
    }

    public void ObtainItem(string itemName)
    {
        if (itemClass.CompareTag("Item") && itemName.Length <= 8)
        {
            item2.text = itemName;
        }
    }
}
