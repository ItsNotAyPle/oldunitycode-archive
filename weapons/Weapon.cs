using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// i realized is_active is pretty useless lmao
// note: im too lazy to change it
public class Weapon : MonoBehaviour
{

    public WeaponData weapon_data;
    [SerializeField] private ParticleSystem muzzle_flash;

    private float nextTimeToFire = 0f;
    public bool is_active;

    [Header("Reloading")]
    private uint ammo_in_clip;
    private uint ammo_clip_max;
    [SerializeField] private uint ammo_spare;

    void Awake() {
        is_active = true;
    }




    void FixedUpdate()
    {
        if (!is_active) return;

        // remember to pit !OutOFAmmo() as a condition
        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire) {

            nextTimeToFire = Time.time + 1f / weapon_data.firerate;

            if (weapon_data.weapon_type == WEAPON_TYPE.SHOTGUN) 
            {
                // shoot multiple pellets 
                return;
            }

            PlayMuzzleFlash();
            ShootCast();
            // ammo_in_clip--;

        }
        
    }

    protected void ShootCast() 
    {
        RaycastHit hit;
        Camera player_cam = Player.instance.player_camera;
        if (Physics.Raycast(player_cam.transform.position, player_cam.transform.TransformDirection(Vector3.forward) * weapon_data.shoot_distance, out hit, Mathf.Infinity)) {
            GameObject collider_obj = hit.collider.gameObject;
            if (collider_obj.tag == "npc") {
                collider_obj.GetComponent<Health>().TakeDamage((int) weapon_data.damage);
                Instantiate(Globals.instance.blood_splatter_go, hit.point, hit.transform.rotation);
                collider_obj.GetComponent<NPC>().OnPlayerHit();
            }
        }
        
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * weapon_data.shoot_distance, Color.white);
    }

    protected void Reload() 
    {
        weapon_data.reload_animation.Play();
        int spare = (int) Mathf.Min(0, ammo_spare - ammo_clip_max);

        // 30 -> ammo_clip_max
        // 40 -> ammo spare
        // Mathf.Min(0, 40 - 30) 
    }

    protected bool OutOfAmmo() 
    {
        return (ammo_in_clip <= 0);
    }

    protected void PlayMuzzleFlash() 
    {
        muzzle_flash.Play();
    }

}
