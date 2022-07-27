using System;
using System.Collections.Generic;
using System.Linq;
using LinqPlayGround.Core;




List<Student> students = Student.GetStudents();

var nameOfStudent = from name in  students orderby name.FirstName select new { name.FirstName, Name = name.FirstName + " " + name.LastName};
Console.WriteLine("List of the student's:\n");
foreach (var item in nameOfStudent)
{
    Console.WriteLine(item.Name);
}
Console.WriteLine($"Total number of students is = {nameOfStudent.Count()}");


var topperformer = from name in students orderby name.Scores?.Values.Average() descending select  name;
var top = topperformer.FirstOrDefault();

Console.WriteLine($"\nTopper name is: {top?.FirstName} And percentage is: {top?.Scores?. Values.Average()}");

Console.WriteLine( "\n----Math Topper---");

var mathTopper = from name in students 
                 orderby name.Scores["maths"] descending
                 select new {Name = name.FirstName+" " + name.LastName, MathMarks = name.Scores["maths"] };

var mathsTopper = 0;
foreach (var marks in mathTopper)
{
    if (marks.MathMarks>= mathsTopper)
    {
        mathsTopper = marks.MathMarks;
    }
    else
    {
        break;
    }
    Console.WriteLine($"{marks.Name} {marks.MathMarks}");
}

Console.WriteLine("\n----Biology Topper---");

var bioTopper = from name in students
                orderby name.Scores["biology"] descending
                select new { Name = name.FirstName + " " + name.LastName, BioMarks = name.Scores["biology"] };

var biosTopper = 0;
foreach (var marks in bioTopper)
{
    if (marks.BioMarks >= biosTopper)
    {
        biosTopper = marks.BioMarks;
    }
    else
    {
        break;
    }
    Console.WriteLine($"{marks.Name} {marks.BioMarks}");
}


//Console.WriteLine("\n---Highest percentage in Math & Bio---");
//var mathAndBioTopper = from name  in students where name?.Scores?["maths"]>= 95 && name?.Scores?["biology"] >= 90 orderby name.Scores?["maths"],"biology"  select name;
//foreach (var item in mathAndBioTopper)
//{
//    Console.WriteLine($"{item.FirstName} Math percentage is {item.Scores["maths"]} And Biology percentage is {item.Scores["biology"]}");
//}

//var topperformer = from name in students order by Average select name.Scores
//foreach (var students in firstNameOfStudent)
//{

//}
//var topPerfomer = from name in students

// ---------------------------


// public static List<Student> students = Student.GetStudents();
//static void Main(string[] args)
//{

//    var studentsQuery = GetStudentsWithQuerySyntax(30, 1);
//    //var studentsQuery = GetStudentsWithMethodSyntax(3, 2);

//    // Projection transformation to string
//    //var qualifiedStudents = from student in studentsQuery
//    //                        select student.First + " " + student.Last;

//    // Projection transformation to annonymous collection.
//    var qualifiedStudents = from student in studentsQuery
//                            select new { student.First, Name = student.First + " " + student.Last, Average = student.Scores.Average() };

//    var qualifiedStudent = qualifiedStudents.FirstOrDefault();

//    Console.Write(qualifiedStudent?.Name + " " + qualifiedStudent?.Average + "\n");


//    //// First OR Default
//    //var firstStudent = students.FirstOrDefault();
//    //Console.WriteLine($"{firstStudent?.First} {firstStudent?.Last}");


//    foreach (var student in studentsQuery)
//    {
//        Console.WriteLine($"{student.First} {student.Last} {student.Scores.Average()}");
//    }
//    Console.WriteLine(studentsQuery.Count());
//}

//public static IEnumerable<Student> GetStudentsWithQuerySyntax(int rowCount, int pageIndex)
//{
//    var skipRows = (pageIndex - 1) * rowCount;
//    return (from student in students
//            let average = student.Scores.Average()
//            orderby average descending
//            select student).Skip(skipRows).Take(rowCount);
//}

//public static IEnumerable<Student> GetStudentsWithMethodSyntax(int rowCount, int pageIndex)
//{
//    var skipRows = (pageIndex - 1) * rowCount;
//    return students.OrderBy(st => st.First).OrderBy(st => st.Last).MySkip(skipRows).MyTake(rowCount);
//}
//    }
//    static class StudentExtensions
//{
//    public static IEnumerable<Student> MySkip(this IEnumerable<Student> students, int value)
//    {
//        return students.Skip(value);
//    }
//    public static IEnumerable<Student> MyTake(this IEnumerable<Student> students, int value)
//    {
//        return students.Take(value);
//    }
//}
//}