using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateGameobject : MonoBehaviour
{
    public void DeactivateSelf()
    {
        Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
