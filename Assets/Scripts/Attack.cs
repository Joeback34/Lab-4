using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform attackLocation;
    private Vector3 rightAttack;
    private Vector3 leftAttack;
    // Start is called before the first frame update
    void Start()
    {
        leftAttack = new Vector3(6.78f, -1.4f, 0);
        rightAttack = new Vector3(-6.78f, -1.4f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<FlipCharacter>().IsFacingRight)
        {
            attackLocation.localPosition = rightAttack;
        }
        else
        {
            attackLocation.localPosition = leftAttack;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(attackLocation.position, .3f);
    }
}
