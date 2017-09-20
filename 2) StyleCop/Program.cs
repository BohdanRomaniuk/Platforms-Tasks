using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LNU.AMI33.Task_1
{
	public class Program
	{
		private static void Main(string[] args)
		{
			string[] fileArr = File.ReadAllLines("../../input.txt");
			Student[] students = new Student[fileArr.Length];
			int idNum = 1;
			for (int i = 0; i < fileArr.Length; ++i)
			{
				string[] lineArr = fileArr[i].Split(' ');
				students[i] = new Student(lineArr[0], int.Parse(lineArr[1]), new Person(lineArr[2], int.Parse(lineArr[3])));
				students[i].Id = idNum;
				idNum++;
			}

			StreamWriter file = new StreamWriter("../../output.txt");
			var selectTeachers = (from t in students
								 select t.Curator).Distinct();

			Teacher[] teachers = new Teacher[selectTeachers.LongCount()];
			List<Teacher> teach = teachers.ToList();
			foreach (var elem in selectTeachers)
			{
				List<Student> studList = new List<Student>();
				for (int i = 0; i < students.LongCount(); ++i)
				{
					if (students[i].Curator.Equals(elem))
					{
						studList.Add(students[i]);
					}
				}
				teach.Add(new Teacher(elem, studList));
			}

			teachers = teach.ToArray();
			for (int i = 0; i < teachers.LongCount(); ++i)
			{
				if (teachers[i] != null)
				{
					teachers[i].Id = idNum;
				}

				idNum++;
			}

			////2
			Student[] studentsClone = new Student[students.Length];
			studentsClone = (Student[])students.Clone();
			Teacher[] teachersClone = new Teacher[teachers.Length];
			teachersClone = (Teacher[])teachers.Clone();
			file.WriteLine("TEACHERS::::");
			foreach (var i in teachersClone)
			{
				if (i != null)
				{
					i.Print(file);
				}
			}
			file.WriteLine("\nSTUDENTS::::");
			foreach (var i in studentsClone)
			{
				if (i != null)
				{
					i.Print(file);
				}
			}
			file.Close();

			//3
			List<Person> all = new List<Person>();
			foreach (var i in teachersClone)
			{
				all.Add(i);
			}
			foreach (var i in studentsClone)
			{
				all.Add(i);
			}
            int teachersCount = all.Count(x => x is Teacher);
			int studentsCount = all.Count(x => x is Student);
			Console.WriteLine("Teachers Count: {0}\nStudents Count: {1}", teachersCount, studentsCount);
			Console.ReadKey();
		}
	}

	public class Person
	{
		private string name;
		private int age;
		private int id;
		
		public Person(string _name, int _age)
		{
			name = _name;
			age = _age;
		}

		public Person(Person _person)
		{
			name = _person.name;
			age = _person.age;
		}

		public int Id
		{
			get
			{
				return id;
			}
			set
			{
				id = value;
			}
		}

		public override bool Equals(object obj)
		{
			return name == (obj as Person).name && age == (obj as Person).age;
		}

		public override int GetHashCode()
		{
			return id;
		}

		public override string ToString()
		{
			string person;
			person = name + "  " + age.ToString() + " years ";
			return person;
		}
	}

	public class Student : Person
	{
		private Person curator;

		public Student(string _name, int _age, Person _curator) : base(_name, _age)
		{
			curator = _curator;
		}

		public Person Curator
		{
			get
			{
				return curator;
			}
		}

		public void Print(StreamWriter _file)
		{
			_file.Write(this.ToString());
		}

		public override string ToString()
		{
			string student;
			student = base.ToString() + "\n  curator: " + curator.ToString() + "\n";
			return student;
		}

		public override bool Equals(object stud_2)
		{
			return base.Equals(stud_2);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}

	public class Teacher : Person
	{
		private List<Student> students;

		public Teacher(Person _teacher, List<Student> _students) : base(_teacher)
		{
			students = _students;
		}

		public void Print(StreamWriter file)
		{
			file.Write(this.ToString());
		}

		public override string ToString()
		{
			string teacher;
			teacher = base.ToString() + "-----\n";
			foreach (var i in students)
			{
				teacher += "\n" + i.ToString();
			}

			return teacher;
		}

		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}
