namespace Wizards.Miscellaneous.Helper;

public abstract class MakefileHelper
{
    private const string FileExtension = ".sln_mk.json";

    public static string GetFullName(string directory, string name)
    {
        return directory + Path.DirectorySeparatorChar + name + FileExtension;
    }
}
