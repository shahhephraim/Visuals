using System.IO;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class MyAnimator : MonoBehaviour
{
    [SerializeField]
    private Animator[] _animators;


    [ContextMenu("hIDE")]
    public void Hide()
    {
        _animators[0].Play("Hide");
    }

    [ContextMenu("pop")]
    public void Pop()
    {
        
        foreach (var animator in _animators)
        {
            animator.Play("Pop");
        }
    }

    private void Update()
    {
        using (var stream = new FileStream(NewTest.GetParent() + "animation.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
        {
            using (var reader = new StreamReader(stream))
            {
                var text = reader.ReadLine();

                if (text == "pop")
                {
                    Pop();
                }
                else if (text == "hide")
                {
                    Hide();
                }
                
            }
        }

        using (var stream = new FileStream(NewTest.GetParent() + "animation.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
        {
            using (var writer = new StreamWriter(stream))
            {
                writer.WriteLine("");
            }
        }
    }
}
