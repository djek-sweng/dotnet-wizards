namespace Wizards.UseCases.Abstractions;

public class FileInfoModel
{
    public string Directory { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Extension { get; set; } = string.Empty;
    public bool Exists { get; set; } = false;
}
