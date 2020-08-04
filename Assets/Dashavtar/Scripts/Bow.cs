using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    #region Variables

    public GameObject projectile;
    public Transform shotPoint;
    public float launchForce;

    #endregion

    #region Functions

    public void Shoot()
    {
        GameObject newProjectile = Instantiate(projectile, shotPoint.position,projectile.transform.rotation);
        newProjectile.GetComponent<Rigidbody2D>().velocity = transform.right * -launchForce;
    }

    #endregion
}
