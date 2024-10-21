public interface IReportBuilder
{
    void SetHeader(string header);
    void SetContent(string content);
    void SetFooter(string footer);
    Report GetReport();
}
// Реализация строителя для текстового отчета
public class TextReportBuilder : IReportBuilder
{
    private Report report = new Report();

    public void SetHeader(string header)
    {
        report.Header = "**** " + header + " ****\n";
    }

    public void SetContent(string content)
    {
        report.Content = content + "\n";
    }

    public void SetFooter(string footer)
    {
        report.Footer = "**** " + footer + " ****\n";
    }

    public Report GetReport()
    {
        return report;
    }
}
// Реализация строителя для HTML отчета
public class HtmlReportBuilder : IReportBuilder
{
    private Report report = new Report();

    public void SetHeader(string header)
    {
        report.Header = $"<h1>{header}</h1>\n";
    }

    public void SetContent(string content)
    {
        report.Content = $"<p>{content}</p>\n";
    }

    public void SetFooter(string footer)
    {
        report.Footer = $"<footer>{footer}</footer>\n";
    }

    public Report GetReport()
    {
        return report;
    }
}
// Класс-директор, который управляет процессом создания отчета
public class ReportDirector
{
    public void ConstructReport(IReportBuilder builder)
    {
        builder.SetHeader("Ежемесячный отчет");
        builder.SetContent("Это содержание ежемесячного отчета.");
        builder.SetFooter("Нижний колонтитул отчета");
    }
}
// Класс, представляющий результат работы строителя (Отчет)
public class Report
{
    public string Header { get; set; }
    public string Content { get; set; }
    public string Footer { get; set; }

    public override string ToString()
    {
        return Header + Content + Footer;
    }
}
