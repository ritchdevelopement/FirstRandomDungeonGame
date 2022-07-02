using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingController : MonoBehaviour
{
    [Header("Projectile Prefabs")]
    public GameObject projectile;

    [Header("General Shooting Settings")]
    public float minTimeBtwShots;
    public float maxTimeBtwShots;
    public float projectileSpeed;

    [Header("Radial Projectile Settings")]
    public bool isRadial;
    public int numberOfProjectiles;

    [Header("AoE Projectile Settings")]
    public bool isAoe;

    [Header("Fired Projectiles List")]
    public List<GameObject> firedProjectiles = new List<GameObject>();

    private EnemyController enemyController;
    private Transform firePoint;

    private float timeBtwShots;
    private float currentTimeBtwShots;
    private float shootAngle;

    // Start is called before the first frame update
    private void Start()
    {
        enemyController = GetComponent<EnemyController>();
        firePoint = transform.Find("FirePoint");
        timeBtwShots = Random.Range(minTimeBtwShots, maxTimeBtwShots);
        currentTimeBtwShots = timeBtwShots;
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateShootDirection();

        if(currentTimeBtwShots <= 0 && !enemyController.dead) {
            if(isRadial) {
                RadialShot();
            } else {
                SingleShot();
            }
            
            if(isAoe && !isRadial) {
                AoeShot(firePoint.up);
            }
            currentTimeBtwShots = timeBtwShots;
        } else {
            currentTimeBtwShots -= Time.deltaTime;
        }
    }

    private void UpdateShootDirection() {
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 shootDir = playerPos - firePoint.position;
        shootAngle = Mathf.Atan2(shootDir.y, shootDir.x) * Mathf.Rad2Deg - 90f;
        firePoint.transform.rotation = Quaternion.AngleAxis(shootAngle, Vector3.forward);   
    }
    
    private void SingleShot() {
        InstantiateProjectile(firePoint.position.x, firePoint.position.y).GetComponent<Rigidbody2D>().AddForce(firePoint.up * projectileSpeed, ForceMode2D.Impulse);
    }


    private void RadialShot() {
        float angleStep = 360f / numberOfProjectiles;
        float angle = 0f;

        for(int i = 0; i < numberOfProjectiles; i++) {
            float projectileDirXPosition = firePoint.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * 1f;
            float projectileDirYPosition = firePoint.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * 1f;

            Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0);
            Vector3 projectileMoveDirection = (projectileVector - firePoint.position).normalized;

            InstantiateProjectile(firePoint.position.x, firePoint.position.y).GetComponent<Rigidbody2D>().AddForce(projectileMoveDirection * projectileSpeed, ForceMode2D.Impulse);
            if(isAoe) {
                AoeShot(projectileMoveDirection);
            }
            angle += angleStep;
        }
    }

    private void AoeShot(Vector2 forceDirection) {
        InstantiateProjectile(firePoint.position.x + 0.5f, firePoint.position.y + 0.5f).GetComponent<Rigidbody2D>().AddForce(forceDirection * projectileSpeed, ForceMode2D.Impulse);
        InstantiateProjectile(firePoint.position.x - 0.5f, firePoint.position.y + 0.5f).GetComponent<Rigidbody2D>().AddForce(forceDirection * projectileSpeed, ForceMode2D.Impulse);
        InstantiateProjectile(firePoint.position.x + 0.5f, firePoint.position.y - 0.5f).GetComponent<Rigidbody2D>().AddForce(forceDirection * projectileSpeed, ForceMode2D.Impulse);
        InstantiateProjectile(firePoint.position.x - 0.5f, firePoint.position.y - 0.5f).GetComponent<Rigidbody2D>().AddForce(forceDirection * projectileSpeed, ForceMode2D.Impulse);
        InstantiateProjectile(firePoint.position.x + 1f, firePoint.position.y).GetComponent<Rigidbody2D>().AddForce(forceDirection * projectileSpeed, ForceMode2D.Impulse);
        InstantiateProjectile(firePoint.position.x - 1f, firePoint.position.y).GetComponent<Rigidbody2D>().AddForce(forceDirection * projectileSpeed, ForceMode2D.Impulse);
        InstantiateProjectile(firePoint.position.x, firePoint.position.y + 1f).GetComponent<Rigidbody2D>().AddForce(forceDirection * projectileSpeed, ForceMode2D.Impulse);
        InstantiateProjectile(firePoint.position.x, firePoint.position.y - 1f).GetComponent<Rigidbody2D>().AddForce(forceDirection * projectileSpeed, ForceMode2D.Impulse);
    }

    private GameObject InstantiateProjectile(float positionX, float positionY) {
        Vector2 position = new Vector2(positionX, positionY);
        GameObject firedProjectile = Instantiate(projectile, position, Quaternion.identity);
        firedProjectiles.Add(firedProjectile);
        return firedProjectile;
    }
}
