using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class ActivateVFXBullet : MonoBehaviour
{
    public VisualEffect vfx; // Asigna tu efecto visual desde el Inspector
    private bool isVFXActive = false;

    void Start()
    {
        // Asegúrate de que el VFX no se reproduzca automáticamente al iniciar
        if (vfx != null)
        {
            vfx.Stop(); // Puedes intentar detener el sistema al inicio para asegurarte de que esté detenido.
        }
    }

    // Función para activar el VFX en loop
    public void ActivarVFX()
    {
        if (vfx != null && !isVFXActive)
        {
            isVFXActive = true;
            StartCoroutine(ReproducirVFXContinuamente());
        }
    }

    // Función para desactivar el VFX
    public void DesactivarVFX()
    {
        if (vfx != null && isVFXActive)
        {
            isVFXActive = false;
            vfx.Stop(); // Detén el sistema
        }
    }

    // Corrutina para reproducir el VFX continuamente mientras isVFXActive es true
    private IEnumerator ReproducirVFXContinuamente()
    {
        while (isVFXActive)
        {
            if (vfx != null )
            {
                vfx.Play(); // Intenta iniciar el sistema si no está reproduciéndose
            }
            yield return null; // Espera hasta el próximo frame
        }
    }

    // Función para obtener el estado de reproducción del VFX
   
}
