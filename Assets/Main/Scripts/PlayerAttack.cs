using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    [SerializeField] private float attackCooldown;
    [SerializeField] private AudioClip shootSound;


    private void Awake() {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update() {
        if(Keyboard.current.spaceKey.wasPressedThisFrame && 
            cooldownTimer > attackCooldown && 
            playerMovement.canAttack()
        ) {
            Attack();
        }
        cooldownTimer += Time.deltaTime;

    }

    private void Attack() {
        SoundManager.instance.PlaySound(shootSound);
        Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
        anim.SetTrigger("attack");
        cooldownTimer = 0;
    }
}