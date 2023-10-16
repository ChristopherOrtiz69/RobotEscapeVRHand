using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour, IExplode
    {
        [SerializeField] private Rigidbody _rb;
        public Rigidbody Rb => _rb;

        public void Explode()
        {
            // Elimina esta l�nea para evitar que el objeto Target se destruya
        }
    }
