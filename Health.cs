using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    public bool _dead = false;
    public UnityEvent ondead;


    public void AddHealth(int amount)
    {
        ChangeHealth(_health + amount);

    }

    public void TakeDamage(int amount)
    {
        ChangeHealth(_health - amount);
    }

    public int GetHealth() { return this._health; }

    protected void ChangeHealth(int amount)
    {
        if (_dead) return;

        _health = amount;
        _health = (int) Mathf.Clamp(_health, 0.0f, 100f);

        if (_health <= 0)
        {
            Debug.Log("Dead!");
            _dead = true;
            ondead.Invoke();
        }
    }
}
