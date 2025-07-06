using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    [Header("��������� �����")]
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private float fadeDuration = 0.5f;

    [Header("UI ��������")]
    [SerializeField] private Button toggleButton;
    [SerializeField] private Image buttonIcon;
    [SerializeField] private Sprite musicOnSprite;
    [SerializeField] private Sprite musicOffSprite;

    [Header("��������� �����")]
    [SerializeField] private AudioSource Allsound;
    //[SerializeField] private AudioSource Allsound2;
    //[SerializeField] private AudioSource Allsound3;
    //[SerializeField] private AudioSource Allsound4;
    [SerializeField] private float fadeDuration2 = 0.5f;

    [Header("UI ��������")]
    [SerializeField] private Button toggleButton2;
    [SerializeField] private Image buttonIcon2;
    [SerializeField] private Sprite soundOnSprite;
    [SerializeField] private Sprite soundOffSprite;

    private bool isMuted = false;
    private float originalVolume;
    public bool isSoundMuted = false;
    public bool _isSoundMuted => isSoundMuted;
    private float SoundVolume, SoundVolume2, SoundVolume3;
    void Start()
    {
        // ��������� ������������ ���������
        originalVolume = backgroundMusic.volume;

        // ��������� ���������� ������
        //toggleButton.onClick.AddListener(ToggleSound);

        // ��������� ������
        UpdateButtonIcon();
        
        // ��������� ������
        UpdateButtonIcon2();
    }

    public void ToggleSound()
    {
        isMuted = !isMuted;
        backgroundMusic.volume = isMuted ? 0f : originalVolume;
        UpdateButtonIcon();
    }

    void UpdateButtonIcon()
    {
        buttonIcon.sprite = isMuted ? musicOffSprite : musicOnSprite;
    }
    public void ToggleSound2()
    {
        
        isSoundMuted = !isSoundMuted;
        
        
        UpdateButtonIcon2();
    }

    void UpdateButtonIcon2()
    {
        buttonIcon2.sprite = isSoundMuted ? soundOffSprite : soundOnSprite;
    }
}
