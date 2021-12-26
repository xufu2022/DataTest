namespace InDepth.NoRelationProperties;

public class CollationsClass
{
    public int Id { get; set; }

    public string NormalString { get; set; }

    public string CaseSensitiveString { get; set; }

    public string CaseSensitiveStringWithIndex { get; set; }

    private CollationsClass() { }
    public CollationsClass(string setAll)
    {
        NormalString = setAll;
        CaseSensitiveString = setAll;
        CaseSensitiveStringWithIndex = setAll;
    }
}