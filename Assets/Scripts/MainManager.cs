using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    private static string ColorDataFile => Application.persistentDataPath + "/savefile.json";

    [SerializeField]
    private Color teamColor;

    public Color TeamColor
    {
        get => teamColor;
        set => teamColor = value;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        TryLoadColor();
    }

    public void SaveColor()
    {
        var data = new SaveData
        {
            TeamColor = teamColor
        };

        var json = JsonUtility.ToJson(data);

        File.WriteAllText(ColorDataFile, json);
    }

    public void TryLoadColor()
    {
        if (File.Exists(ColorDataFile))
        {
            var json = File.ReadAllText(ColorDataFile);
            var data = JsonUtility.FromJson<SaveData>(json);
            TeamColor = data.TeamColor;
        }
    }
}
