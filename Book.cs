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

    /// <summary>Parses following the format "&lt;title&gt; by &lt;first
    /// name&gt; &lt;last name&gt; on &lt;date&gt;. This does not check for a
    /// properly formatted string"</summary>
    public static Book Parse(String str)
    {
        string title_pattern = "^.* by ";
        string author_pattern = " by .*";
        string date_pattern = " on .*";

        string title = Regex.Match(str, title_pattern).Value;
        // Remove " by "
        title = title.Remove(title.Length - 4);

        string author = Regex.Match(str, author_pattern).Value;
        // Remove " by "
        author = author.Remove(0, 4);
        var names = author.Split(" ");
        (string first, string last) = (names[0], names[1]);

        string date = Regex.Match(str, date_pattern).Value;
        // Remove " on "
        date = date.Remove(0, 4);

        return new Book(last, first, title, date);
    }

    /// <summary>Parses following the format "&lt;title&gt; by &lt;first
    /// name&gt; &lt;last name&gt; on &lt;date&gt;. If the string is not
    /// properly formatted, null will be returned</summary>
    public static Book? TryParse(String str)
    {
        string title_pattern = "^.* by ";
        string author_pattern = " by .*";
        string date_pattern = " on .*";

        // Title
        var titleResult = Regex.Match(str, title_pattern);

        if (!titleResult.Success) return null;

        string title = titleResult.Value;
        // Remove " by "
        title = title.Remove(title.Length - 4);

        // Author
        var authorResult = Regex.Match(str, author_pattern);
        if (!authorResult.Success) return null;

        string author = authorResult.Value;
        // Remove " by "
        author = author.Remove(0, 4);
        // Split first and last name
        var names = author.Split(" ");
        (string first, string last) = (names[0], names[1]);

        // Date
        var dateResult = Regex.Match(str, date_pattern);
        if (!dateResult.Success) return null;
        string date = dateResult.Value;
        // Remove " on "
        date = date.Remove(0, 4);

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
