using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Item Target;

    [SerializeField] private float Power = 10;

    public void ResetAll()
    {
        Target = null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Target != null)
        {
            Debug.Log("APPLY");
            Target.Push(Power);
            Target = null;
        }
    }
}
