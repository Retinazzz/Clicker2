using UnityEngine;


public class homya_deliverer : MonoBehaviour//, ISaveable
{
    public Artifact _artifact;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private AudioClip enterSound; // Звук при входе
    [SerializeField] private float volume = 1f;
    [SerializeField] private GameObject hit;

    private float volumefix;
    private AudioSource _audioSource;
    private static int Hommvalue = 5, ValuePrice = 50, speedcost = 30, ValuePrice2nd = 10000;

    private int maxHomyakks = 8, CurrentHomyakks = 0;


    public CircleCollider2D col;

    
    private Animator animator;

    public Vector3 pointA = new Vector3(-9, -2,10);
    public Vector3 pointB = new Vector3(9, -2,10);

    private static float speed = 2f;
    private bool ismuted = false;
    public float _speed => speed;
    public int _hommvalue => Hommvalue;
    public int _speedcost => speedcost;
    public int _valueprice => ValuePrice;

    public int _valueprice2nd => ValuePrice2nd;

    public Vector3 target;

    
    /*public SavedObject GetSaveData()
    {
        return new SavedObject
        {
            prefabName = gameObject.name.Replace("(Clone)", ""),
            position = transform.position,
            rotation = transform.rotation,
            value = Hommvalue,
            sspeed = speed
        };
    }

    // Метод для загрузки данных
    public void LoadData(SavedObject data)
    {
        transform.position = data.position;
        transform.rotation = data.rotation;
        Hommvalue = data.value;
        speed = data.sspeed;
    }*/

    private void Start()
    {
        volumefix = volume;    
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
          {
            _audioSource = gameObject.AddComponent<AudioSource>();
            _audioSource.playOnAwake = false;
          }
        Hommvalue = PlayerPrefs.GetInt("hommvalue", Hommvalue);
        ValuePrice = PlayerPrefs.GetInt("hommvalueprice", ValuePrice);
        speed = PlayerPrefs.GetFloat("hommspeed", speed);
        speedcost = PlayerPrefs.GetInt("hommspeedcost", speedcost);
    }
    private void OnEnable()
    {
        target = pointB;
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (ismuted == true)
        {
            volumefix = 0;
        }
        else volumefix = volume;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = (target == pointA) ? pointB : pointA;  // Switch target
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        _artifact.Addclicks(Hommvalue);
        Instantiate(hit);

        animator.SetBool("Trigger", true);
        PlaySound();

    }
    public void OnTriggerExit2D(Collider2D other)
    {
        animator.SetBool("Trigger", false);
    }
    public void AddHommValue(int Value)
    {
        if (_artifact.Clicks >= ValuePrice)
        {
            Hommvalue += Value;
            _artifact.DecreaseClicks(ValuePrice);
            AddCostForValue();
        }
        PlayerPrefs.SetInt("hommvalue", Hommvalue);
    }
    public void AddCostForValue()
    {
        ValuePrice = (int)(ValuePrice * 3 + 50);
        PlayerPrefs.SetInt("hommvalueprice", ValuePrice);
    }
    public void AddCostForSpeed()
    {
        speedcost = speedcost * 2 + 40;
        PlayerPrefs.SetInt("hommspeedcost", speedcost);
    }
    public void AddHommSpeed(float Value)
    {
        if (_artifact.Clicks >= speedcost)
        {
            _artifact.DecreaseClicks(speedcost);
            speed += Value;
            AddCostForSpeed();
            PlayerPrefs.SetFloat("hommspeed", speed);
        }

    }
    public void AdderSecond(int Value)
    {
        if (_artifact.Clicks >= ValuePrice2nd)
        {
            Hommvalue += Value;
            _artifact.DecreaseClicks(ValuePrice2nd);
            ValuePrice2nd *= (int)1.7;
        }
        PlayerPrefs.SetInt("hommvalue", Hommvalue);
    }
    void PlaySound()
    {
        
            _audioSource.PlayOneShot(enterSound, volumefix);
        

    }
    public void ToggleSound()
    {
        ismuted = !ismuted;
    }
}
