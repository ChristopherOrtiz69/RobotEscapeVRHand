using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IExplode
{
    void Explode();
}

public class SomeClass : MonoBehaviour, IExplode
{
    public void Explode()
    {
        // Implementa la l�gica de la explosi�n aqu�
    }
}
