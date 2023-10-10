using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldLogic : MonoBehaviour
{
    public GameObject shield  ;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    private void Update()
    {
       
    }
   public  void ActiveShield()
    {
        gameObject.SetActive(true);
    }
    public void DesactiveShield()
    {
        gameObject.SetActive(false);
    }
}
