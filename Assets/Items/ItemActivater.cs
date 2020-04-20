using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemActivater : MonoBehaviour
{
    private BoxCollider2D bC2d;
    private Character_Base cB;
    [SerializeField] LayerMask layerMask;
    [SerializeField] LayerMask layerMaskMoster;

    // Start is called before the first frame update
    void Start()
    {
        cB = GetComponent<Character_Base>();
        bC2d = GetComponent<BoxCollider2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D ray = Physics2D.Raycast(bC2d.bounds.center, -transform.up, (bC2d.bounds.extents.y + 0.02f), layerMask);
        Raychecked(ray);

        RaycastHit2D ray2 = Physics2D.BoxCast(bC2d.bounds.center, bC2d.bounds.size * new Vector2(1, 0.9f), 0f, transform.right * (cB.MoveRight ? 1 : -1), 0.05f, layerMaskMoster);
        Raychecked(ray2);
    }

    private void Raychecked(RaycastHit2D ray)
    {
        //Color color = Color.green;
        if (ray.collider != null)
        {
            //color = Color.red;
            //Debug.Log(ray.collider.name);
            IInteractive item = ray.collider.GetComponent<IInteractive>();
            if (item != null)
            {
                item.Interact(this.gameObject);
            }
        }
        //Debug.DrawRay(bC2d.bounds.center, -transform.up * (bC2d.bounds.extents.y + 0.02f), color);
    }
}
