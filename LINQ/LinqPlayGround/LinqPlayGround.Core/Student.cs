namespace LinqPlayGround.Core
{
    public class Student
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Id { get; set; }
        public Dictionary<string, int> ?Scores;
        public static List<Student> GetStudents()
        {
            return new List<Student>
            {
                new Student {FirstName="Svetlana", LastName="Omelchenko", Id=111, Scores = new Dictionary<string,int> { { "maths", 97 },{"science",92 },{"biology",81 },{ "social", 60 } } },
                new Student {FirstName="Claire", LastName="O'Donnell", Id=112, Scores= new Dictionary<string,int> { { "maths", 75},{"science", 84 },{"biology", 91},{ "social", 39} } },
                new Student {FirstName="Sven", LastName="Mortensen", Id=113, Scores= new Dictionary<string,int>   { { "maths", 88},{"science", 94}, {"biology", 65},{ "social", 91} } },
                new Student {FirstName="Cesar", LastName="Garcia", Id=114, Scores= new Dictionary<string,int>     { { "maths", 97},{"science", 89}, {"biology", 85},{ "social", 82} } },
                new Student {FirstName="Debra", LastName="Garcia", Id=115, Scores= new Dictionary<string,int>     { { "maths", 35},{"science", 72}, {"biology", 91},{ "social", 70} } },
                new Student {FirstName="Fadi", LastName="Fakhouri", Id=116, Scores= new Dictionary<string,int>    { { "maths", 99},{"science", 86}, {"biology", 90},{ "social", 94} } },
                new Student {FirstName="Hanying", LastName="Feng", Id=117, Scores= new Dictionary<string,int>     { { "maths", 93},{"science", 92}, {"biology", 80},{ "social", 87} } },
                new Student {FirstName="Hugo", LastName="Garcia", Id=118, Scores= new Dictionary<string,int>      { { "maths", 92},{"science", 90}, {"biology", 83},{ "social", 78} } },
                new Student {FirstName="Lance", LastName="Tucker", Id=119, Scores= new Dictionary<string,int>     { { "maths", 68},{"science", 79}, {"biology", 88},{ "social", 92} } },
                new Student {FirstName="Terry", LastName="Adams", Id=120, Scores= new Dictionary<string,int>      { { "maths", 99},{"science", 81}, {"biology", 81},{ "social", 79} } },
                new Student {FirstName="Eugene", LastName="Zabokritski", Id=121, Scores= new Dictionary<string,int>{ {"maths", 96},{"science", 85}, {"biology", 91},{ "social", 60} } },
                new Student {FirstName="Michael", LastName="Tucker", Id=122, Scores= new Dictionary<string,int>    { { "maths",94},{"science", 91}, {"biology", 91},{ "social", 91} } },
                new Student {FirstName="Michael", LastName="Fastbender", Id=122, Scores= new Dictionary<string,int>{ { "maths",94},{"science", 92}, {"biology", 91},{ "social", 91} } }
            };
        }
    }
}