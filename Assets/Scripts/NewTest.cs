using System.IO;
using TMPro;
using UnityEngine;

public class NewTest : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _text;
    [SerializeField]
    TextMeshProUGUI[] _content;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(GetParent());
    }

    private void Update()
    {
        string content, address;
        using (var stream = new FileStream(GetParent() + "content.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
        {
            using (var reader = new StreamReader(stream))
            {
                content = reader.ReadLine();
            }
        }

        using (var stream = new FileStream(GetParent() + "address.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
        {
            using (var reader = new StreamReader(stream))
            {
                address = reader.ReadLine();
            }
        }


        _text.text = address;

        foreach (var text in _content)
        {
            text.text = content;
        }
    }


    public static string GetParent()
    {
        var path = Directory.GetParent(Application.dataPath).Parent.ToString();
        return Path.GetFullPath(path) + Path.DirectorySeparatorChar;
    }
}
