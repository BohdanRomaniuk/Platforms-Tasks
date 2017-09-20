using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LNU.AMI33.Task_1
{
	/// <summary>
	/// Main Program Class
	/// </summary>
	public class Program
	{
		/// <summary>
		/// Main Program Method
		/// </summary>
		/// <param name="args">Method arguments</param>
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

			////3
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

	/// <summary>
	/// Class which is base and contain information about Person
	/// </summary>
	public class Person
	{
		/// <summary>
		/// Person Name
		/// </summary>
		private string name;

		/// <summary>
		/// Person Age
		/// </summary>
		private int age;

		/// <summary>
		/// Person identifier
		/// </summary>
		private int id;

		/// <summary>
		/// Constructor that create Person from name and age
		/// </summary>
		/// <param name="_name">Name of the Person</param>
		/// <param name="_age">Age of the Person</param>
		public Person(string _name, int _age)
		{
			name = _name;
			age = _age;
		}

		/// <summary>
		/// Copy Constructor
		/// </summary>
		/// <param name="_person">Copy information from _person to this</param>
		/// <see cref="Person" />
		public Person(Person _person)
		{
			name = _person.name;
			age = _person.age;
		}

		/// <summary>
		/// Gets or sets Person Id
		/// </summary>
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

		/// <summary>
		/// Check if object is Equal to Person
		/// </summary>
		/// <param name="obj">Element with which we compare</param>
		/// <returns>Return true if elements are equal</returns>
		public override bool Equals(object obj)
		{
			return name == (obj as Person).name && age == (obj as Person).age;
		}

		/// <summary>
		/// Get Hash Code of Person
		/// </summary>
		/// <returns>Person Hash Code</returns>
		public override int GetHashCode()
		{
			return id;
		}

		/// <summary>
		/// Return information about Person
		/// </summary>
		/// <returns>Formatted string of Persons fields</returns>
		public override string ToString()
		{
			string person;
			person = name + "  " + age.ToString() + " years ";
			return person;
		}
	}

	/// <summary>
	/// Class which contains information about Student
	/// </summary>
	public class Student : Person
	{
		/// <summary>
		/// Field which contain information about student's curator
		/// </summary>
		private Person curator;

		/// <summary>
		/// Constructor that create Student from name, age and his curator
		/// </summary>
		/// <param name="_name">Name of the Student</param>
		/// <param name="_age">Age of the Student</param>
		/// <param name="_curator">Curator of the Student</param>
		public Student(string _name, int _age, Person _curator) : base(_name, _age)
		{
			curator = _curator;
		}

		/// <summary>
		/// Gets Student Curator
		/// </summary>
		public Person Curator
		{
			get
			{
				return curator;
			}
		}

		/// <summary>
		/// Write Student to file using StreamWriter
		/// </summary>
		/// <param name="_file">Using for writing to file</param>
		public void Print(StreamWriter _file)
		{
			_file.Write(this.ToString());
		}

		/// <summary>
		/// Return information about Student
		/// </summary>
		/// <returns>Formatted string of Student fields and base.ToString()</returns>
		public override string ToString()
		{
			string student;
			student = base.ToString() + "\n  curator: " + curator.ToString() + "\n";
			return student;
		}

		/// <summary>
		/// Check if object is Equal to Student
		/// </summary>
		/// <param name="stud_2">Element with which we compare</param>
		/// <returns>Return true if elements are equal</returns>
		public override bool Equals(object stud_2)
		{
			return base.Equals(stud_2);
		}

		/// <summary>
		/// Get Hash Code of Student
		/// </summary>
		/// <returns>Student Hash Code</returns>
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}

	/// <summary>
	/// Class which contains information about Teacher
	/// </summary>
	public class Teacher : Person
	{
		/// <summary>
		/// Contains set of student, who are studying with this Teacher
		/// </summary>
		private List<Student> students;

		/// <summary>
		/// Constructor that create Teacher from _teacher and his _students list
		/// </summary>
		/// <param name="_teacher">Information about teacher as person</param>
		/// <param name="_students">List of his/her students</param>
		public Teacher(Person _teacher, List<Student> _students) : base(_teacher)
		{
			students = _students;
		}

		/// <summary>
		/// Write Teacher to file using StreamWriter
		/// </summary>
		/// <param name="file">Using for writing to file</param>
		public void Print(StreamWriter file)
		{
			file.Write(this.ToString());
		}

		/// <summary>
		/// Return information about Teacher
		/// </summary>
		/// <returns>Formatted string of Teacher fields, base.ToString() and Students</returns>
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

		/// <summary>
		/// Check if object is Equal to Teacher
		/// </summary>
		/// <param name="obj">Element with which we compare</param>
		/// <returns>Return true if elements are equal</returns>
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		/// <summary>
		/// Get Hash Code of Teacher
		/// </summary>
		/// <returns>Teacher Hash Code</returns>
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}
