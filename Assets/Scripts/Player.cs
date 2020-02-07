using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D Target;
    [SerializeField] private Transform ForceApplyPoint;
    [SerializeField] private float Power = 10;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Target != null)
        {
            Debug.Log("APPLY");
            //var dir = Target.position - (Vector2)transform.position;
            var deltaX = Target.position.x - ForceApplyPoint.position.x;
            var dir = new Vector2(deltaX, 0);
            var force = dir.normalized * Power;
            var pos = (Vector2)transform.position;
            Target.gravityScale = 1;
            Target.AddForceAtPosition(force, pos, ForceMode2D.Impulse);
            Target = null;
        }
    }
}
