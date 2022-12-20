using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatWeapoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colision:" + collision.gameObject.tag);
    }
}
