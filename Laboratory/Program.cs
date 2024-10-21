using Laboratory;
/*class Program
{
    static void 
    Main(string[] args)
    {
        // Создаем офисный компьютер
        IComputerBuilder officeBuilder = new OfficeComputerBuilder();
        ComputerDirector director = new ComputerDirector(officeBuilder);
        director.ConstructComputer();
        Computer officeComputer = director.GetComputer();
        Console.WriteLine(officeComputer);

        // Создаем игровой компьютер
        IComputerBuilder gamingBuilder = new GamingComputerBuilder();
        director = new ComputerDirector(gamingBuilder);
        director.ConstructComputer();
        Computer gamingComputer = director.GetComputer();
        Console.WriteLine(gamingComputer);
    }
}*/

using System;

public class Program
{
    public static void Main(string[] args)
    {
        var documentManager = new DocumentManager();

        // Создание оригинального документа
        var originalDoc = new Document("Original Title", "Original Content");
        originalDoc.AddSection(new Section("Introduction", "This is the introduction section."));
        originalDoc.AddImage(new Image("http://example.com/image1.png"));

        // Клонирование документа
        var clonedDoc = (Document)documentManager.CreateDocument(originalDoc);

        // Изменение клонированного документа
        clonedDoc.Title = "Cloned Title";
        clonedDoc.Sections[0].Text = "This is the modified introduction section.";
        clonedDoc.AddImage(new Image("http://example.com/image2.png"));

        // Вывод оригинального и клонированного документов
        Console.WriteLine($"Original Document Title: {originalDoc.Title}");
        Console.WriteLine($"Cloned Document Title: {clonedDoc.Title}");
        Console.WriteLine($"Original Section Text: {originalDoc.Sections[0].Text}");
        Console.WriteLine($"Cloned Section Text: {clonedDoc.Sections[0].Text}");
        Console.WriteLine($"Original Images Count: {originalDoc.Images.Count}");
        Console.WriteLine($"Cloned Images Count: {clonedDoc.Images.Count}");
    }
}
