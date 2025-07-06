using UnityEngine;


public class ClonerHomyak : MonoBehaviour
{
    public GameObject objectToClone; // Объект, который будем клонировать
    [SerializeField] private Artifact artifact;
    public static int Cost1homyak = 50;
    
    public static int maxHomyakks = 8;
    public static int CurrentHomyakks = 0;

    private void Start()
    {
        PlayerPrefs.GetInt("Cost4Homm", Cost1homyak);
        PlayerPrefs.GetInt("CurrentHommyaks", CurrentHomyakks);
        for (int i = 0; i < CurrentHomyakks; i++)
        {
            Vector3 newpos = new Vector3(Random.Range(-9, 9), -2, 10);
            Instantiate(objectToClone, newpos, Quaternion.identity);
        }
    }

    public void Clone() 
    {
        
        
        if ((objectToClone != null)&(CurrentHomyakks<maxHomyakks)&(artifact.Clicks>=Cost1homyak))
        {
            Instantiate(objectToClone);
            CurrentHomyakks++;
            
            artifact.DecreaseClicks(Cost1homyak);
            Cost1homyak = 4* Cost1homyak + 50;
        }
        else if (CurrentHomyakks>=maxHomyakks)
        {
            Debug.Log("МНогочета");
           
        }
        else
        {
            Debug.LogError("Не назначен объект для клонирования!");
        }
        PlayerPrefs.SetInt("Cost4Homm", Cost1homyak);
        PlayerPrefs.SetInt("CurrentHommyaks", CurrentHomyakks);


    }
}
