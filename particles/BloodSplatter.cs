using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class BloodSplatter : MonoBehaviour
{
    [SerializeField] private ParticleSystem blood_splatter;

    public void Awake() 
    {
        this.blood_splatter = GetComponent<ParticleSystem>();
        this.blood_splatter.Play();
        Destroy(this.gameObject, 2f);
    }


}