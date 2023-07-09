using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
public class DogPickupGun : Singleton<DogPickupGun>
{
    public WeaponScript HoldingGun;
    public Transform DogMouth;
    public List<WeaponScript> GunOnInventory;
    public float rotationForceWhenThrown;
    WeaponScript gunonFront;
    enum ThrowState
    {
        CanThrow, CanPickup
    }
    ThrowState ts = ThrowState.CanPickup;

    Vector2 GetThrowDirection()
    {

        //  Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //   mousePosition.z = 0f;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        screenPoint.z = 0;
        Vector3 direction = (Vector3)(Input.mousePosition - screenPoint);
        direction.z = 0;
        direction.Normalize();
        // Vector2 throwDirection = mousePosition - transform.position;
        //  throwDirection.Normalize();

        return direction;
    }



    private void Update()
    {
        if (ts == ThrowState.CanThrow)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (HoldingGun != null)
                    ThrowWeapon();
            }
        }
        if (ts == ThrowState.CanPickup)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (gunonFront == null) return;

                if (HoldingGun != null)
                    ThrowWeapon();
                TakeWeapon(gunonFront);
                gunonFront = null;
            }
        }


        if (HoldingGun != null)
        {
            HoldingGun.transform.position = DogMouth.position;


            WeaponDescription.Instance.ShowText(HoldingGun);

        }
        else
        {
            WeaponDescription.Instance.CloseText();
        }

    }

    public void ThrowWeapon()
    {

        GameObject throwable = HoldingGun.gameObject;
        AudioManager.Instance.PlaySound("DogThrow");

        HoldingGun.sr.flipX = false;
        Vector2 throwDirection = GetThrowDirection() / 2;
        CameraFollow.Instance.ShakeCam(throwDirection,1);
        Rigidbody2D throwableRb = HoldingGun.rb;
        throwableRb.AddForce(throwDirection * PlayerStats.Instance.ThrowForce, ForceMode2D.Impulse);
        int i = Random.Range(0, 2);
        if (i == 0)
            throwableRb.AddTorque(PlayerStats.Instance.ThrowForce * -rotationForceWhenThrown);
        if (i == 1)
            throwableRb.AddTorque(PlayerStats.Instance.ThrowForce * rotationForceWhenThrown);
        HoldingGun.enabled = true;
        HoldingGun = null;

    }

    public void TakeWeapon(WeaponScript GunOnFloor)
    {
        Debug.Log("took wpn");
        AudioManager.Instance.PlaySound("DogPickup");
        HoldingGun = GunOnFloor;
        HoldingGun.enabled = false;
        gunonFront = null;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            WeaponScript weaponScript = collision.transform.GetComponent<WeaponScript>();

            if (weaponScript.enabled && weaponScript!=WandererStats.Instance.CurrentWeapon)
            {
                gunonFront = weaponScript;
                ts = ThrowState.CanPickup;

            }
            else
            {
                ts = ThrowState.CanThrow;

            }
            if (weaponScript.onAir) { gunonFront = null; ts = ThrowState.CanThrow; }


        }
    }

}
