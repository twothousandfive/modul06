public interface IReportBuilder
{
    void SetHeader(string header);
    void SetContent(string content);
    void SetFooter(string footer);
    void AddSection(string sectionName, string sectionContent);
    void SetStyle(ReportStyle style);
    Report GetReport();
}
public class TextReportBuilder : IReportBuilder
{
    private Report _report = new Report();

    public void SetHeader(string header)
    {
        _report.Header = "Header: " + header;
    }

    public void SetContent(string content)
    {
        _report.Content = "Content: " + content;
    }

    public void SetFooter(string footer)
    {
        _report.Footer = "Footer: " + footer;
    }

    public void AddSection(string sectionName, string sectionContent)
    {
        _report.Sections.Add(sectionName, "Section Content: " + sectionContent);
    }

    public void SetStyle(ReportStyle style)
    {
        _report.Style = style; // Текстовые отчеты могут игнорировать стиль
    }

    public Report GetReport()
    {
        return _report;
    }
}
public class HtmlReportBuilder : IReportBuilder
{
    private Report _report = new Report();

    public void SetHeader(string header)
    {
        _report.Header = $"<h1>{header}</h1>";
    }

    public void SetContent(string content)
    {
        _report.Content = $"<p>{content}</p>";
    }

    public void SetFooter(string footer)
    {
        _report.Footer = $"<footer>{footer}</footer>";
    }

    public void AddSection(string sectionName, string sectionContent)
    {
        _report.Sections.Add(sectionName, $"<section><h2>{sectionName}</h2><p>{sectionContent}</p></section>");
    }

    public void SetStyle(ReportStyle style)
    {
        _report.Style = style; // Используем стиль при экспорте
    }

    public Report GetReport()
    {
        return _report;
    }
}
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

public class PdfReportBuilder : IReportBuilder
{
    private Report _report = new Report();

    public void SetHeader(string header)
    {
        _report.Header = header;
    }

    public void SetContent(string content)
    {
        _report.Content = content;
    }

    public void SetFooter(string footer)
    {
        _report.Footer = footer;
    }

    public void AddSection(string sectionName, string sectionContent)
    {
        _report.Sections.Add(sectionName, sectionContent);
    }

    public void SetStyle(ReportStyle style)
    {
        _report.Style = style;
    }

    public Report GetReport()
    {
        return _report;
    }

    public void ExportPdf(string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            Document doc = new Document();
            PdfWriter.GetInstance(doc, fs);
            doc.Open();

            doc.Add(new Paragraph(_report.Header));
            doc.Add(new Paragraph(_report.Content));

            foreach (var section in _report.Sections)
            {
                doc.Add(new Paragraph(section.Key + ": " + section.Value));
            }

            doc.Add(new Paragraph(_report.Footer));
            doc.Close();
        }
    }
}
public class ReportStyle
{
    public string BackgroundColor { get; set; }
    public string FontColor { get; set; }
    public int FontSize { get; set; }
}
public class Report
{
    public string Header { get; set; }
    public string Content { get; set; }
    public string Footer { get; set; }
    public Dictionary<string, string> Sections { get; set; } = new Dictionary<string, string>();
    public ReportStyle Style { get; set; }

    public void Export()
    {
        Console.WriteLine(Header);
        Console.WriteLine(Content);
        foreach (var section in Sections)
        {
            Console.WriteLine($"Section {section.Key}: {section.Value}");
        }
        Console.WriteLine(Footer);
    }
}
public class ReportDirector
{
    public void ConstructReport(IReportBuilder builder, ReportStyle style)
    {
        builder.SetStyle(style);
        builder.SetHeader("Sample Report Header");
        builder.SetContent("This is the main content of the report.");
        builder.AddSection("Section 1", "Content of Section 1");
        builder.AddSection("Section 2", "Content of Section 2");
        builder.SetFooter("Sample Report Footer");
    }
}
