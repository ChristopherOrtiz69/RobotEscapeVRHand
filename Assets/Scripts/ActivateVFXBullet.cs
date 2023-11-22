using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class ActivateVFXBullet : MonoBehaviour
{
    public VisualEffect vfx; // Asigna tu efecto visual desde el Inspector
    private bool isVFXActive = false;

    void Start()
    {
        // Aseg�rate de que el VFX no se reproduzca autom�ticamente al iniciar
        if (vfx != null)
        {
            vfx.Stop(); // Puedes intentar detener el sistema al inicio para asegurarte de que est� detenido.
        }
    }

    // Funci�n para activar el VFX en loop
    public void ActivarVFX()
    {
        if (vfx != null && !isVFXActive)
        {
            isVFXActive = true;
            StartCoroutine(ReproducirVFXContinuamente());
        }
    }

    // Funci�n para desactivar el VFX
    public void DesactivarVFX()
    {
        if (vfx != null && isVFXActive)
        {
            isVFXActive = false;
            vfx.Stop(); // Det�n el sistema
        }
    }

    // Corrutina para reproducir el VFX continuamente mientras isVFXActive es true
    private IEnumerator ReproducirVFXContinuamente()
    {
        while (isVFXActive)
        {
            if (vfx != null )
            {
                vfx.Play(); // Intenta iniciar el sistema si no est� reproduci�ndose
            }
            yield return null; // Espera hasta el pr�ximo frame
        }
    }

    // Funci�n para obtener el estado de reproducci�n del VFX
   
}
