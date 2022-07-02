using UnityEngine;

public class PlayerShootingController : MonoBehaviour
{
    public Transform weapon;
    public GameObject projectile;
    public Camera cam;

    [HideInInspector] public Vector3 aimDir;

    public float fireRate = 0.5f;
    public float arrowForce = 20f;
    [HideInInspector] public float reloadTime = 0f;
    [HideInInspector] public bool canShoot = true;

    private Transform weaponPivot;
    private Transform firePoint;

    private float nextFire = 0f;

    private void Start() {
        weaponPivot = weapon.parent;
        firePoint = weapon.Find("FirePoint");
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateShootDirection();

        if(canShoot) {
            reloadTime = nextFire - Time.time;

            if(PlayerInventoryController.arrowCount >= 1) {
                if(Input.GetButtonDown("Fire1") && Time.time > nextFire) {
                    nextFire = Time.time + fireRate;
                    Shoot();
                }
            }
        }
    }

    void Shoot()
    {
        GameObject arrow = Instantiate(projectile, firePoint.position, firePoint.rotation);
        Rigidbody2D arrowRb2d = arrow.GetComponent<Rigidbody2D>();

        arrowRb2d.AddForce(weaponPivot.up * arrowForce, ForceMode2D.Impulse);
        PlayerInventoryController.arrowCount--;
    }

    private void UpdateShootDirection() {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        aimDir = mousePos - weaponPivot.position;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg - 90f;
        weaponPivot.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
