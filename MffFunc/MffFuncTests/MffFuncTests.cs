using MffFunc;

namespace MffFunctTests;

public class Tests
{
    private record Student(string Name);

    [Test]
    public void MapForNormalValue_ShouldReturnCorrectResult()
        => Assert.That(Map.MapFunction([1, 2, 3], x => x * 2), 
            Is.EqualTo(new List<int> { 2, 4, 6 }));
    
    [Test]
    public void MapForEmptyList_ShouldReturnCorrectResult()
        => Assert.That(Map.MapFunction(new List<int>(), x => x * 2), Is.Empty);
    
    [Test]
    public void MapForClassList_ShouldReturnCorrectResult()
    {
        var students = new List<Student> { new Student("John"), new Student("Kate") };
        Assert.That(Map.MapFunction(students, person => person.Name[0]),
            Is.EqualTo(new List<char> { 'J', 'K' }));
    }
    
    [Test]
    public void FilterForNormalValue_ShouldReturnCorrectResult()
        => Assert.That(Filter.FilterFunction([1, 2, 3], x => x % 2 == 0), 
            Is.EqualTo(new List<int> { 2 }));
    
    [Test]
    public void FilterForEmptyList_ShouldReturnCorrectResult()
        => Assert.That(Filter.FilterFunction(new List<int>(), x => x % 2 == 0), Is.Empty);

    [Test]
    public void FilterForClassList_ShouldReturnCorrectResult()
    {
        var students = new List<Student> { new Student("John"), new Student("Kate") };
        Assert.That(Filter.FilterFunction(students, person => person.Name[0] == 'K'),
            Is.EqualTo(new List<Student> { new Student("Kate") }));
    }
    
    [Test]
    public void FoldForNormalValue_ShouldReturnCorrectResult()
        => Assert.That(Fold.FoldFunction([1, 2, 3], 1, (x, y) => x * y), 
            Is.EqualTo(6));
    
    [Test]
    public void FoldForEmptyList_ShouldReturnCorrectResult()
        => Assert.That(Fold.FoldFunction(new List<int>(), 1, (x, y) => x * y), Is.EqualTo(1));

    [Test]
    public void FoldForClassList_ShouldReturnCorrectResult()
    {
        var students = new List<Student> { new Student("John"), new Student("Kate") };
        Assert.That(Fold.FoldFunction(students, "", (x, y) => y + x.Name[0]),
            Is.EqualTo("JK"));
    }
}