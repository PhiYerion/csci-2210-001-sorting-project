using System.Text.RegularExpressions;

namespace sorting_algos;

public class Book : IComparable<Book>
{
    public String LastName;
    public String FirstName;
    public String Title;
    public String ReleaseDate;

    public Book(String lastName, String firstName, String title, String releaseDate)
    {
        LastName = lastName;
        FirstName = firstName;
        Title = title;
        ReleaseDate = releaseDate;
    }

    public static Book Parse(String str)
    {
        string title_pattern = "^.* by ";
        string author_pattern = " by .*";
        string date_pattern = " on .*";

        string title = Regex.Match(str, title_pattern).Value;
        title = title.Remove(title.Length - 4); // Remove " by "

        string author = Regex.Match(str, author_pattern).Value;
        author = author.Remove(0, 4); // Remove " by "
        var names = author.Split(" ");
        (string first, string last) = (names[0], names[1]);

        string date = Regex.Match(str, date_pattern).Value;
        date = date.Remove(0, 4); // Remove "on "

        return new Book(last, first, title, date);
    }

    public static Book? TryParse(String str)
    {
        string title_pattern = "^.* by ";
        string author_pattern = " by .*";
        string date_pattern = " on .*";

        // Title
        var titleResult = Regex.Match(str, title_pattern);

        if (!titleResult.Success) return null;

        string title = titleResult.Value;
        title = title.Remove(title.Length - 4); // Remove " by "

        // Author
        var authorResult = Regex.Match(str, author_pattern);
        if (!authorResult.Success) return null;

        string author = authorResult.Value;
        author = author.Remove(0, 4); // Remove " by "
        var names = author.Split(" ");
        (string first, string last) = (names[0], names[1]);

        // Date
        var dateResult = Regex.Match(str, date_pattern);
        if (!dateResult.Success) return null;
        string date = dateResult.Value;
        date = date.Remove(0, 4); // Remove "on "

        return new Book(last, first, title, date);

    }

    public override String ToString()
    {
        return Title + " by " + FirstName + LastName + " on " + ReleaseDate;
    }

    public int CompareTo(Book? other)
    {
        if (other == null) return 1;

        int result = LastName.CompareTo(other.LastName);
        if (result != 0) return result;

        result = FirstName.CompareTo(other.FirstName);
        if (result != 0) return result;

        result = Title.CompareTo(other.Title);
        if (result != 0) return result;

        return ReleaseDate.CompareTo(other.ReleaseDate);
    }
}
