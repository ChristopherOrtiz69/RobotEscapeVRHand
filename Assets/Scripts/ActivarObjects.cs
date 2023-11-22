using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarObjects : MonoBehaviour
{
    public List<GameObject> buttons = new List<GameObject>();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            foreach (var button in buttons)
            {
                button.SetActive(true);
            }
        }
    }
}
