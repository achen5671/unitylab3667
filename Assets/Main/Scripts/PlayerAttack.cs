using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;

    void Update() {
        if(Keyboard.current.spaceKey.wasPressedThisFrame) {
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
        }
    }
}