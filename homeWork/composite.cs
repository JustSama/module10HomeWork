using System;
using System.Collections.Generic;

abstract class FileSystemComponent
{
    public string Name { get; protected set; }
    public abstract void Display();
    public abstract int GetSize();
}

class File : FileSystemComponent
{
    private int size;

    public File(string name, int size)
    {
        Name = name;
        this.size = size;
    }

    public override void Display()
    {
        Console.WriteLine($"Файл: {Name}, Размер: {size}KB");
    }

    public override int GetSize()
    {
        return size;
    }
}

class Directory : FileSystemComponent
{
    private List<FileSystemComponent> components = new List<FileSystemComponent>();

    public Directory(string name)
    {
        Name = name;
    }

    public void Add(FileSystemComponent component)
    {
        if (!components.Contains(component))
        {
            components.Add(component);
        }
    }

    public void Remove(FileSystemComponent component)
    {
        components.Remove(component);
    }

    public override void Display()
    {
        Console.WriteLine($"Папка: {Name}");
        foreach (var component in components)
        {
            component.Display();
        }
    }

    public override int GetSize()
    {
        int totalSize = 0;
        foreach (var component in components)
        {
            totalSize += component.GetSize();
        }
        return totalSize;
    }
}

class Program
{
    static void Main()
    {
        File file1 = new File("file1.txt", 100);
        File file2 = new File("file2.txt", 200);
        File file3 = new File("file3.txt", 300);

        Directory dir1 = new Directory("Folder1");
        dir1.Add(file1);
        dir1.Add(file2);

        Directory dir2 = new Directory("Folder2");
        dir2.Add(file3);

        Directory root = new Directory("Root");
        root.Add(dir1);
        root.Add(dir2);

        root.Display();
        Console.WriteLine($"Общий размер: {root.GetSize()}KB");
    }
}
