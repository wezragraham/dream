using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveItem : MonoBehaviour
{
    public bool canBePickedUp;
    public string itemName;
    public bool pickedUp;
    // Start is called before the first frame update
    void Start()
    {
        pickedUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pickedUp)
        {
            Destroy(this.gameObject);
        }
    }
}
