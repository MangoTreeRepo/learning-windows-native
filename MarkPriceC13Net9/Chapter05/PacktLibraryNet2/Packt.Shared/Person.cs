namespace Packt.Shared;

public class Person
{
    #region Fields: Data or state for this person.
    public string? Name;
    public DateTimeOffset Born;
    public WondersOfTheAncientWorld FavoriteAncientWonder;
    public WondersOfTheAncientWorld BucketList;
    public List<Person> Children = [];
    #endregion
}
