namespace Laboratory;

using System;
using System.Collections.Generic;


public interface IPrototype
{
    IPrototype Clone();
}
public class Document : IPrototype
{
    public string Title { get; set; }
    public string Content { get; set; }
    public List<Section> Sections { get; private set; }
    public List<Image> Images { get; private set; }

    public Document()
    {
        Sections = new List<Section>();
        Images = new List<Image>();
    }

    public Document(string title, string content) : this()
    {
        Title = title;
        Content = content;
    }

    public IPrototype Clone()
    {
        var clonedDocument = (Document)MemberwiseClone();
        clonedDocument.Sections = new List<Section>(Sections.Count);
        foreach (var section in Sections)
        {
            clonedDocument.Sections.Add((Section)section.Clone());
        }
        clonedDocument.Images = new List<Image>(Images.Count);
        foreach (var image in Images)
        {
            clonedDocument.Images.Add((Image)image.Clone());
        }
        return clonedDocument;
    }

    public void AddSection(Section section)
    {
        Sections.Add(section);
    }

    public void AddImage(Image image)
    {
        Images.Add(image);
    }
}

public class Section : IPrototype
{
    public string Header { get; set; }
    public string Text { get; set; }

    public Section(string header, string text)
    {
        Header = header;
        Text = text;
    }

    public IPrototype Clone()
    {
        return (IPrototype)MemberwiseClone();
    }
}

public class Image : IPrototype
{
    public string Url { get; set; }

    public Image(string url)
    {
        Url = url;
    }

    public IPrototype Clone()
    {
        return (IPrototype)MemberwiseClone();
    }
}

public class DocumentManager
{
    public IPrototype CreateDocument(IPrototype prototype)
    {
        return prototype.Clone();
    }
}
