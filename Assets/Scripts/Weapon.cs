using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float fireRate;
    public float effectSpawnRate;
    public float damage = 10;
    public LayerMask whatToHit;
    public Transform bulletTrailPrefab;
    public Transform muzzleFlashPrefab;

    private float _timeToFire;
    private float _timeToSpawnEffect;
    
    private Transform _firePoint;
    private Camera _camera;
    private Transform muzzleFlashInstance;

    private void Awake()
    {
        _camera = Camera.main;
        _firePoint = transform.Find("FirePoint");
        if (_firePoint == null)
        {
            Debug.LogError("No FirePoint found");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && Time.time > _timeToFire)
            {
                _timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        var mousePos = new Vector2(_camera.ScreenToWorldPoint(Input.mousePosition).x,
            _camera.ScreenToWorldPoint(Input.mousePosition).y);
        var firePointPositionRaw = _firePoint.position;
        var firePointPosition = new Vector2(firePointPositionRaw.x, firePointPositionRaw.y);
        var hit = Physics2D.Raycast(firePointPosition, mousePos - firePointPosition, 100, whatToHit);

        if (Time.time > _timeToSpawnEffect)
        {
            Effect();
            
            _timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
        }
        
        Debug.DrawLine(firePointPosition, (mousePos - firePointPosition) * 100, Color.cyan, .2f);

        if (hit.collider != null)
        {
            Debug.DrawLine(firePointPosition, hit.point, Color.red, .5f);
            Debug.Log("Hit " + hit.collider.name + " (Damage: " + damage + ")");
        }
    }

    private void Effect()
    {
        Instantiate(bulletTrailPrefab, _firePoint.position, _firePoint.rotation);
        muzzleFlashInstance = Instantiate(muzzleFlashPrefab, _firePoint.position, _firePoint.rotation);
        muzzleFlashInstance.parent = _firePoint;
        var size = Random.Range(.6f, .9f);
        muzzleFlashInstance.localScale = new Vector3(size, size, 0);

        Destroy(muzzleFlashInstance, 0.02f);
    }

    
}