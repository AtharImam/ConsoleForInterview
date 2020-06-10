using Ninject.Infrastructure.Language;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace ConsoleForInterview.Examples
{
    class LinqExample
    {
        static List<int> list1 = new List<int> { 40, 20, 60, 3, 55 };
        static List<int> list2 = new List<int> { 20, 70, 55, 80 };
        static int[] nums = { 1, 4, 2, 8, 7, 3, 9, 6 };
        static List<Person> persons = null;
        static string[] countries = { "Australia", "Germany", "Italy", "India", "US", "UK", "Canada", "Australia" };
        static List<Student> students = null;
        static List<Employee> employees = null;
        static List<Department> departments = null;

        public static void Execute()
        {
            //SequenceExqualExample();
            //ConcatExample();
            //UnionExample();
            //IntersectExample();
            //ExceptExample();
            //CreatePersonsList();
            //CreateStudentsList();
            //CreateEmplyeesList();
            //CreateDepartmentsList();
            //Console.WriteLine($"Min: {list1.Where(n=>n>20).Min()}");
            //Console.WriteLine($"Max: {list1.Where(n => n < 60).Max()}");
            //Console.WriteLine($"Sum: {list1.Where(n => n%2==0).Sum()}");
            //Console.WriteLine($"Count: {nums.Where(n => n % 2 != 0).Count()}");
            //Console.WriteLine($"Average: {nums.Average()}");

            //Console.WriteLine($"Min: {students.Min(s=>s.Id)}");
            //Console.WriteLine($"Max: {students.Max(s => s.Id)}");
            //Console.WriteLine($"Sum: {students.Sum(s => s.Id)}");
            //Console.WriteLine($"Count: {students.Count(s => s.Gender == "Male")}");
            //Console.WriteLine($"Average: {students.Average(s => s.Id)}");

            //Console.WriteLine($"Aggregate: {countries.Aggregate((a, b) => $"{a}, {b}")}");
            //int aggregate = nums.Aggregate((a, b) =>
            //{
            //    Console.WriteLine($"{a} * {b}");
            //    return a * b;
            //});
            //Console.WriteLine($"Aggregate: {aggregate}");
            //int[] tnums = { 4, 3, 2, 1 };
            //Console.WriteLine($"Aggregate: {tnums.Aggregate(10, (a, b) => a * b)}");
            // DisplayStudentByLinqWithWhere();
            //string str = "Athar";
            //Console.WriteLine(ExtensionMethods.MakeUpper(str));
            //DisplayStudentByLinqAnonymousWithIndex();
            //DispalySubjectsBySelectMany();
            //DispalySubjectsByLinqBySelectMany();
            //DisplayCharsBySelectMany();
            //DispalySubjectsByLinqBySelectMany();
            //DisplayStudentNameWithSubjects();
            //DisplayStudentWithOrderBy();
            //DisplayOrderWithReverse();
            //TakeAndSkip();
            //DefferedExecution();
            //DisplayStudentAsDictionary();
            //LookupExample();
            //CastExample();
            //OfTypeExample();
            //GroupByExample();
            //GroupJoinExample();
            //JoinExample();
            //LeftOuterJoinExample();
            //CrossJoinExample();
            //DistinctExample();
            //DistinctExampleWithComparer();
            //UnionExampleOnObject();
            //RangeExample();
            //RepeatExample();
            //EmptyExample();
            //AllAnyContainsExample();
            FindAllVsWhere();
        }

        static void FindAllVsWhere()
        {
            List<int> list1 = new List<int> { 1, 2, 3, 4, 5 };
            var result1 = list1.FindAll(item => item > 3);
            list1.Add(6);
            Console.WriteLine(string.Join(", ", result1.Select(i => i.ToString())));

            List<int> list2 = new List<int> { 1, 2, 3, 4, 5 };
            var result2 = list1.Where(item => item > 3);
            list2.Add(6);
            Console.WriteLine(string.Join(", ", result2.Select(i => i.ToString())));
        }

        static void AllAnyContainsExample()
        {
            int[] nums = {2,4,3,1,6,5,9 };
            bool allLess10 = nums.All(i => i < 10);
            bool allLess5 = nums.All(i => i < 5);
            bool anyEven = nums.Any(i => i % 2 == 0);
            bool anyLessZero = nums.Any(i => i < 1);
            string[] countries = { "Australia", "uk", "us", "India", "US", "UK", "Canada", "AUSTRALIA" };
            bool indiaPresent = countries.Contains("InDiA", StringComparer.OrdinalIgnoreCase);
            Console.WriteLine($"{allLess10} {allLess5} {anyEven} {anyLessZero} {indiaPresent}");
        }

        static void EmptyExample()
        {
            List<int> list = null;
            IEnumerable<int> list2 = list ?? Enumerable.Empty<int>();
            Console.WriteLine("Count: "+list2.Count());
            foreach(var l in list2)
            {
                Console.WriteLine(l);
            }
        }

        static void RepeatExample()
        {
            var list = Enumerable.Repeat("Athar ", 5);
            foreach (var l in list)
            {
                Console.WriteLine(l);
            }
        }

        static void RangeExample()
        {
            var list = Enumerable.Range(0, 10).Where(i => i % 2 == 0);
            foreach(var l in list)
            {
                Console.WriteLine(l);
            }
        }

        static void UnionExampleOnObject()
        {
            List<Employee> list1 = new List<Employee>();
            list1.Add(new Employee { Id = 1, Name = "Athar" });
            list1.Add(new Employee { Id = 2, Name = "Imam" });
            list1.Add(new Employee { Id = 3, Name = "Shaheen" });

            List<Employee> list2 = new List<Employee>();
            list2.Add(new Employee { Id = 2, Name = "Imam" });
            list2.Add(new Employee { Id = 4, Name = "Afeefah" });
            list2.Add(new Employee { Id = 5, Name = "Aliya" });

            var result = list1.Union(list2, new EmployeeComparer());
            foreach (var v in result)
            {
                Console.WriteLine($"{v.Id} {v.Name}");
            }
        }

        class EmployeeComparer : IEqualityComparer<Employee>
        {
            public bool Equals([AllowNull] Employee x, [AllowNull] Employee y)
            {
                return x.Id == y.Id && x.Name == y.Name;
            }

            public int GetHashCode([DisallowNull] Employee obj)
            {
                return obj.Id.GetHashCode() ^ obj.Name.GetHashCode();
            }
        }

        static void DistinctExampleWithComparer()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee { Id = 1, Name = "Athar" });
            employees.Add(new Employee { Id = 1, Name = "Athar" });
            employees.Add(new Employee { Id = 2, Name = "Imam" });
            //var result = employees.Distinct(new EmployeeComparer());
            //var result = employees.Distinct();
            var result = employees.Select(emp => new { emp.Id, emp.Name }).Distinct();  
            foreach (var v in result)
            {
                Console.WriteLine($"{v.Id} {v.Name}");
            }
        }

        static void DistinctExample()
        {
            string[] countries = { "Australia", "uk", "us", "India", "US", "UK", "Canada", "AUSTRALIA" };
            var result = countries.Distinct(StringComparer.OrdinalIgnoreCase);
            foreach(var v in result)
            {
                Console.WriteLine(v);
            }
        }

        static void CrossJoinExample()
        {
            //var result = from emp in employees
            //             from dept in departments
            //             select new { emp, dept };

            //var result = employees.SelectMany(emp => departments, (emp, dept) => new { emp, dept });

            var result = employees.Join(departments, emp => true, dept => true, (emp, dept) => new { emp, dept });

            foreach(var v in result)
            {
                Console.WriteLine($"{v.emp.Name} {v.dept.Name}");
            }
        }

        //Left outer join is like group join
        static void LeftOuterJoinExample()
        {
            //var empByDept = from emp in employees
            //                join dept in departments
            //                on emp.DepartmentId equals dept.Id into eGroup
            //                from dept in eGroup.DefaultIfEmpty()
            //                select new { EmpName = emp.Name, DeptName = dept == null ? "No Department" : dept.Name };

            var empByDept = employees.GroupJoin(departments, e => e.DepartmentId, d => d.Id,
                (emp, depts) => new { emp, depts })
                .SelectMany(z => z.depts.DefaultIfEmpty(), (a, b) => new { EmpName = a.emp.Name, DeptName = b == null ? "No Department" : b.Name });

            foreach (var ebd in empByDept)
            {
                Console.WriteLine($"{ebd.EmpName} {ebd.DeptName}");
            }
        }

        static void JoinExample()
        {
            //var empByDept = employees.Join(departments, e => e.DepartmentId, d => d.Id,
            //    (emp, dept) => new { EmpName = emp.Name, DeptName = dept.Name });

            var empByDept = from emp in employees
                            join dept in departments
                            on emp.DepartmentId equals dept.Id
                            select new { EmpName = emp.Name, DeptName = dept.Name };

            foreach (var ebd in empByDept)
            {
                Console.WriteLine($"{ebd.EmpName} {ebd.DeptName}");
            }
        }

        static void GroupJoinExample()
        {
            //var empByDepartment = departments.GroupJoin(employees, d => d.Id, e => e.DepartmentId, (dept, emp) => new { dept, emp });
            var empByDepartment = from dept in departments
                                  join emp in employees
                                  on dept.Id equals emp.DepartmentId into eGroup
                                  select new { dept, emp = eGroup };

            foreach (var ebd in empByDepartment)
            {
                Console.WriteLine(ebd.dept.Name);
                foreach(var emp in ebd.emp)
                {
                    Console.WriteLine("--"+emp.Name);
                }
            }
        }

        static void GroupByExample()
        {
            //var groups = employees.GroupBy(emp => new { emp.Department, emp.Gender })
            //    .OrderBy(g=>g.Key.Department).ThenBy(g=>g.Key.Gender)
            //    .Select(g=>new { Dept = g.Key.Department, Sex = g.Key.Gender, Employees = g.OrderBy(e => e.Name) });
            var groups = from employee in employees
                         group employee by new { employee.Department, employee.Gender } into eGroup
                         orderby eGroup.Key.Department, eGroup.Key.Gender
                         select new { Dept = eGroup.Key.Department, Sex = eGroup.Key.Gender, Employees = eGroup.OrderBy(e => e.Name) };

            foreach (var g in groups)
            {
                Console.WriteLine($"{g.Dept} - {g.Sex} - {g.Employees.Count()}");
                Console.WriteLine("------------------------------");
                foreach (var e in g.Employees)
                {
                    Console.WriteLine($"{e.Name} {e.Department} {e.Gender}");
                }
                Console.WriteLine("\n");
            }
        }

        static void OfTypeExample()
        {
            ArrayList list = new ArrayList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add("1"); // casts only compatible type.
            list.Add("ABC");
            list.Add(4);
            var intList = list.OfType<int>();
            foreach (var num in intList)
            {
                Console.WriteLine(num);
            }
        }

        static void CastExample()
        {
            ArrayList list = new ArrayList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add("1"); // gives exception on typecast.
            var intList = list.Cast<int>();
            foreach( var num in intList)
            {
                Console.WriteLine(num);
            }
        }

        static void LookupExample()
        {
            var empJobTitle = employees.ToLookup(e => new { e.JobTitle, e.City });
            Console.WriteLine("Employees grouped by JobTitle and City");
            foreach(var kvp in empJobTitle)
            {
                Console.WriteLine($"{kvp.Key.City} {kvp.Key.City}");
                foreach(var emp in empJobTitle[kvp.Key])
                {
                    Console.WriteLine($"\tName: {emp.Name}, JobTitle: {emp.JobTitle}, City: {emp.City}");
                }
            }
        }

        static void DisplayStudentAsDictionary()
        {
            var dict = students.ToDictionary(student => student.Id, student => student.Name);
            foreach(KeyValuePair<int,string> kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }

        static void DefferedExecution()
        {
            var result = from student in students
                        where student.TotalMarks == 300
                        select student;
            Console.WriteLine($"Total Records: {result.Count()}");
            students.Add(new Student { Id = 15, TotalMarks = 300, Name = "Salma", Gender = "Male", Subjects = new List<string> { "Math", "English" } });
            DisplayStudents(result);
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"Total Records: {result.Count()}");
            students.Add(new Student { Id = 16, TotalMarks = 300, Name = "Salman", Gender = "Male", Subjects = new List<string> { "Math", "English" } });
            DisplayStudents(result);
        }

        static void ImmediateOrGreedyExecution()
        {
            var result = (from student in students
                         where student.TotalMarks == 300
                         select student).ToList()   ;
            Console.WriteLine($"Total Records: {result.Count()}");
            students.Add(new Student { Id = 15, TotalMarks = 300, Name = "Salma", Gender = "Male", Subjects = new List<string> { "Math", "English" } });
            DisplayStudents(result);
            Console.WriteLine("------------------------------------");
            students.Add(new Student { Id = 16, TotalMarks = 300, Name = "Salman", Gender = "Male", Subjects = new List<string> { "Math", "English" } });
            DisplayStudents(result);
        }

        static void DisplayStudnetByPaging()
        {
            int pageSize = 4;
            Console.Write("Please enter page no.:(1,2,3,4):- ");
            if(Int32.TryParse(Console.ReadLine(), out int pageNumber))
            {
                var stus = students.Skip((pageNumber - 1) * pageSize).Take(pageSize);
                DisplayStudents(stus);
            }
        }

        static void TakeWhileAnsSkipWhile()
        {
            //var cntrs = countries.TakeWhile(item => item.Length > 2);
            var cntrs = countries.SkipWhile(item => item.Length > 2);
            foreach (var c in cntrs)
            {
                Console.WriteLine(c);
            }
        }

        static void TakeAndSkip()
        {
            //var stus = students.Where(item => item.Id > 20).Skip(3);
            var stus = students.Skip(3);
            DisplayStudents(stus);
        }

        static void DisplayStudents(dynamic stus)
        {
            foreach (var s in stus)
            {
                Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Marks : {s.TotalMarks}");
            }
        }

        static void DisplayOrderWithReverse()
        {
            var stus = students.Reverse<Student>();
            foreach (var s in stus)
            {
                Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Marks : {s.TotalMarks}");
            }
        }

        static void DisplayStudentWithOrderBy()
        {
            //var stus = students.OrderBy(item => item.TotalMarks).ThenBy(item => item.Name).ThenByDescending(item=>item.Id);
            var stus = from student in students
                       orderby student.TotalMarks, student.Name, student.Id descending
                       select student;
            foreach (var s in stus)
            {
                Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Marks : {s.TotalMarks}");
            }
        }

        static void DisplayStudentNameWithSubjects()
        {
            //var results = students.SelectMany(student => student.Subjects, 
            //    (student, subject) => new { StudentName = student.Name, SubjectName = subject });

            var results = from student in students
                          from subject in student.Subjects
                          select new { StudentName = student.Name, SubjectName = subject };

            foreach (var res in results)
            {
                Console.WriteLine($"{res.StudentName} - {res.SubjectName}");
            }
        }

        static void DisplayCharsBySelectMany()
        {
            string[] arrs = new string[] {"Hello World","0123456789" };
            //IEnumerable<char> chars = arrs.SelectMany(item => item);
            IEnumerable<char> chars = from s in arrs
                                      from c in s
                                      select c;
            foreach (char c in chars)
            {
                Console.WriteLine(c);
            }
        }

        static void DispalySubjectsBySelectMany()
        {
            var subjects = students.SelectMany(student => student.Subjects).Distinct().Aggregate((a, b) => $"{a}, {b}");
            Console.WriteLine(subjects);
        }

        static void DispalySubjectsByLinqBySelectMany()
        {
            var subjects = (from student in students
                           from subject in student.Subjects
                           select subject).Distinct();
            foreach (var subject in subjects)
            {
                Console.WriteLine(subject);
            }
        }

        static void DisplayStudentByLinqAnonymousWithIndex()
        {
            var sts = persons.Select((student, index) => new { Index = index+1, FullName = $"{student.FirstName} {student.LastName}" });
            foreach (var s in sts)
            {
                Console.WriteLine($"{s.Index} {s.FullName}");
            }
        }

        static void DisplayStudentByLinqString()
        {
            var sts = from students in persons where students.Id > 3 select $"{students.FirstName} {students.LastName}";
            foreach (var s in sts)
            {
                Console.WriteLine(s);
            }
        }

        static void DisplayStudentByLinqAnonymous()
        {
            var sts = from student in persons where student.Id > 3 select new {FullName = $"{student.FirstName} {student.LastName}" };
            foreach (var s in sts)
            {
                Console.WriteLine(s.FullName);
            }
        }

        static void DisplayStudentByLinqWithWhere()
        {
            var sts = from student in persons where student.Id > 3 && student.Gender=="Female" select student;
            foreach (var s in sts)
            {
                Console.WriteLine(s);
            }
        }

        static void DisplayStudentByLinq()
        {
            var sts = from students in persons select students;
            foreach(var s in sts)
            {
                Console.WriteLine(s);
            }
        }

        private static void CreatePersonsList()
        {
            persons = new List<Person>();
            persons.Add(new Person { Id = 1, FirstName = "Athar", LastName = "Imam", Gender = "Male" });
            persons.Add(new Person { Id = 2, FirstName = "Anjuman", LastName = "Shaheen", Gender = "Female" });
            persons.Add(new Person { Id = 3, FirstName = "Afeefah", LastName = "Athar", Gender = "Female" });
            persons.Add(new Person { Id = 4, FirstName = "Aliya", LastName = "Anjuman", Gender = "Female" });
            persons.Add(new Person { Id = 5, FirstName = "Aftab", LastName = "Alam", Gender = "Male" });
            persons.Add(new Person { Id = 6, FirstName = "Kaisar", LastName = "Imam", Gender = "Male" });
        }

        private static void CreateStudentsList()
        {
            students = new List<Student>();
            students.Add(new Student { Id = 1, TotalMarks = 100, Name = "Athar", Gender = "Male", Subjects = new List<string> { "Hindi", "English" } });
            students.Add(new Student { Id = 2, TotalMarks = 100, Name = "Afeefah", Gender = "Female", Subjects = new List<string> { "Math", "English", "Arabic" } });
            students.Add(new Student { Id = 3, TotalMarks = 100, Name = "Athar", Gender = "Female", Subjects = new List<string> { "Arabic", "Hindi", "Urdu" } });
            students.Add(new Student { Id = 4, TotalMarks = 100, Name = "Aliya", Gender = "Female", Subjects = new List<string> { "English", "Hindi", "Math" } });
            students.Add(new Student { Id = 5, TotalMarks = 250, Name = "Aftab", Gender = "Male", Subjects = new List<string> { "Math", "English" } });
            students.Add(new Student { Id = 6, TotalMarks = 100, Name = "Imam", Gender = "Male", Subjects = new List<string> { "Hindi", "English" } });
            students.Add(new Student { Id = 7, TotalMarks = 100, Name = "Shaheen", Gender = "Female", Subjects = new List<string> { "Math", "English", "Arabic" } });
            students.Add(new Student { Id = 8, TotalMarks = 100, Name = "Alam", Gender = "Female", Subjects = new List<string> { "Arabic", "Hindi", "Urdu" } });
            students.Add(new Student { Id = 9, TotalMarks = 100, Name = "Kaisar", Gender = "Female", Subjects = new List<string> { "English", "Hindi", "Math" } });
            students.Add(new Student { Id = 10, TotalMarks = 250, Name = "Rahul", Gender = "Male", Subjects = new List<string> { "Math", "English" } });
            students.Add(new Student { Id = 11, TotalMarks = 100, Name = "Anwar", Gender = "Male", Subjects = new List<string> { "Hindi", "English" } });
            students.Add(new Student { Id = 12, TotalMarks = 100, Name = "Jamal", Gender = "Female", Subjects = new List<string> { "Math", "English", "Arabic" } });
            students.Add(new Student { Id = 13, TotalMarks = 100, Name = "Chand", Gender = "Female", Subjects = new List<string> { "Arabic", "Hindi", "Urdu" } });
            students.Add(new Student { Id = 14, TotalMarks = 300, Name = "Rahul", Gender = "Female", Subjects = new List<string> { "English", "Hindi", "Math" } });
            students.Add(new Student { Id = 15, TotalMarks = 300, Name = "Salim", Gender = "Male", Subjects = new List<string> { "Math", "English" } });
        }

        private static void CreateEmplyeesList()
        {
            employees = new List<Employee>();
            employees.Add(new Employee { DepartmentId = 1, Salary = 10000, Department = "IT", Gender = "Male", Name = "Athar", JobTitle = "Associate Lead", City = "Delhi" });
            employees.Add(new Employee { DepartmentId = 2, Salary = 15000, Department = "HR", Gender = "Male", Name = "Imam", JobTitle = "Lead", City = "Patna" });
            employees.Add(new Employee { DepartmentId = 4, Salary = 20000, Department = "Admin", Gender = "Female", Name = "Afeefah", JobTitle = "Sr. Developer", City = "Delhi" });
            employees.Add(new Employee { DepartmentId = 0, Salary = 15000, Department = "Admin", Gender = "Female", Name = "Aliya", JobTitle = "Lead", City = "Patna" });
            employees.Add(new Employee { DepartmentId = 2, Salary = 25000, Department = "HR", Gender = "Female", Name = "Anjuman", JobTitle = "Sr. Developer", City = "Patna" });
            employees.Add(new Employee { DepartmentId = 1, Salary = 30000, Department = "IT", Gender = "Male", Name = "Shaheen", JobTitle = "Associate Lead", City = "Delhi" });
        }

        private static void CreateDepartmentsList()
        {
            departments = new List<Department>();
            departments.Add(new Department { Id = 1, Name = "IT" });
            departments.Add(new Department { Id = 2, Name = "HR" });
            departments.Add(new Department { Id = 3, Name = "Payroll" });
            departments.Add(new Department { Id = 4, Name = "Admin" });
        }

        private static void IntersectExample()
        {
            Console.WriteLine($"Common elements: {string.Join(',', list1.Intersect(list2))}");
        }

        private static void ExceptExample()
        {
            Console.WriteLine($"Except elements: {string.Join(',', list1.Except(list2))}");
        }

        private static void UnionExample()
        {
            Console.WriteLine($"Union elements: {string.Join(',', list1.Union(list2))}");
        }

        private static void ConcatExample()
        {
            Console.WriteLine($"Union elements: {string.Join(',', list1.Concat(list2))}");
        }

        private static void SequenceExqualExample()
        {
            string[] ctrs1 = { "UK", "USA", "INDIA" };
            string[] ctrs2 = { "uk", "usa", "india" };

            bool areEqual = ctrs1.SequenceEqual(ctrs2, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine(areEqual);
        }

        class Person
        {
            public int Id { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Gender { get; set; }

            public override string ToString()
            {
                return $"Id: {Id}, Name: {FirstName} {LastName}, Gender: {Gender}";
            }
        }

        class Student
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string Gender { get; set; }

            public int TotalMarks { get; set; }

            public List<string> Subjects { get; set; }
        }

        class Employee
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string JobTitle { get; set; }

            public string City { get; set; }

            public string Gender { get; set; }

            public string Department { get; set; }

            public int DepartmentId { get; set; }

            public int Salary { get; set; }

            public override bool Equals(object obj)
            {
                Employee y = obj as Employee;
                return this.Id == y.Id && this.Name == y.Name;
            }

            public override int GetHashCode()
            {
                return this.Id.GetHashCode() ^ this.Name.GetHashCode();
            }
        }

        class Department
        {
            public int Id { get; set; }

            public string  Name { get; set; }
        }
    }

    public static class ExtensionMethods
    {
        public static string MakeUpper(this string str)
        {
            return str.ToUpper();
        }
    }
}
