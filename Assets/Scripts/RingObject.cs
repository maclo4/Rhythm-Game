using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingObject : MonoBehaviour
{
    public GameObject nineRingPrefab, threeRingPrefab, fourRingPrefab, sixRingPrefab, sevenRingPrefab, tenRingPrefab, twelveRingPrefab, oneRingPrefab;
    [HideInInspector]
   // public Animator nineRing, threeRing, fourRing, sixRing, sevenRing, tenRing, twelveRing, oneRing;

    public void Awake()
    {
        //GetAnimator(nineRingPrefab, ref nineRing);
        //GetAnimator(threeRingPrefab, ref threeRing);
        //GetAnimator(fourRingPrefab, ref fourRing);
        
    }

    public void GetAnimator(GameObject prefab, ref Animator ring)
    {
        if (prefab.TryGetComponent(out Animator animator))
        {
            ring = animator;
        }
    }
    public void setAnimationSpeed(float speed)
    {

        //nineRing.speed = speed;
        //threeRing.speed = speed;
        //fourRing.speed = speed;
        //sixRing.speed = speed;
        //sevenRing.speed = speed;
        //tenRing.speed = speed;
        //twelveRing.speed = speed;
        //oneRing.speed = speed;
    }
}
