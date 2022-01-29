using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveButton : MonoBehaviour
{

    /// <summary>
    /// RemoveBox ditambahkan pada event OnClick Button Remove
    /// </summary>
    public void RemoveBox(GameObject box)
    {
        box.gameObject.SetActive(false);
    }
}
