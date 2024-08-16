using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderGO : MonoBehaviour
{
    public Transform PlayerTransform;

    public void CallPlayerMethod()
    {
        PlayerTransform.GetComponent<Player>().CallThisMethod();
    }
}
