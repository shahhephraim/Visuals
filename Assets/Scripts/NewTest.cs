using System;
using System.IO;
using TMPro;
using UnityEngine;

public class NewTest : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _text;
    [SerializeField]
    TextMeshProUGUI[] _content;
    [SerializeField]
    private MyAnimator _animator;

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

        if (_content[0].text == content)
        {
            return;
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

        _animator.UpdateLinePositions();
    }


    public static string GetParent()
    {
        var path = Directory.GetParent(Application.dataPath).Parent.ToString();
        return Path.GetFullPath(path) + Path.DirectorySeparatorChar;
    }
}
