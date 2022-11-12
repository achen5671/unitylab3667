using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;

    [SerializeField] private AudioClip shootSound;


    void Update() {
        if(Keyboard.current.spaceKey.wasPressedThisFrame) {
            SoundManager.instance.PlaySound(shootSound);
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
        }
    }
}