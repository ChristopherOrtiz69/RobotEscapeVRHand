using System.Diagnostics;
using Unity.XR.CoreUtils;
using Unity.XR.CoreUtils.Bindings;
using Unity.XR.CoreUtils.Bindings.Variables;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.State;

namespace UnityEngine.XR.Interaction.Toolkit.Filtering
{
    /// <summary>
    /// Filter component that allows for basic poke functionality
    /// and to define constraints for when the interactable will be selected.
    /// </summary>
    [AddComponentMenu("XR/XR Poke Filter", 11)]
    
    public class Pruebas : MonoBehaviour
    {
     public Animator Navervr;

        [SerializeField]
        [Tooltip("The interactable associated with this poke filter.")]
        XRBaseInteractable m_Interactable;
        // Start is called before the first frame update
        void Start()
    {
        Navervr = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Interactable == true)
        {
            Debug.Log("servi");
            Navervr.Play("Nave_movement_Tutorial");


        }
    }
}
}
