using System;
using System.Dynamic;

namespace SimpleStudentManagementProjectCSharpProject1
{
    internal class Program
    {
        // declare student array to store data
        static string[] studentName =new string[2];
         static int[] studentAge = new int[2];
         static  double[] studentMark = new double[2];
         static DateTime[] dateTime = new DateTime[2];

        //declare variables to store student number
        static int count = 0;



        static void Main(string[] args)
        {




            while (true)
            {
                Console.Clear();

                // display the options
                Console.WriteLine("\nChoose an One:");
                Console.WriteLine("1. Add a new student record");
                Console.WriteLine("2. View all students with formatted output and subject-wise marks");
                Console.WriteLine("3.  Find a student by name");
                Console.WriteLine("4. Calculate the class average");
                Console.WriteLine("5. Find the top-performing student");
                Console.WriteLine("6. Sort students by marks");
                Console.WriteLine("7. Delete a student record ");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                int choice = int.Parse(Console.ReadLine());

                // handle the user's choice 

                switch (choice)
                {
                    case 1: addNewStudentRecord(); break;
                    case 2: viewAllStudents(); break;
                    case 3: findStudentByName(); break;
                    case 4: calculateTheClassArerage(); break;
                    case 5: findTopProrfomingStudent(); break;
                    case 6: sortStudentsByMark(); break;
                    case 7: deleteStudentRecordAndShifiing(); break;
                    case 0: return;
                    default: Console.WriteLine("Invalid choice! Try again."); break;
                }

                Console.ReadLine();
            }










        }

        static void addNewStudentRecord()
        {
            Console.WriteLine("######  Enter student Data #####\n\n");

            // add  student in student record 
            for (int i = 0; i < studentName.Length; i++)
            {
               
                Console.WriteLine("Enter student Name");
                string name = Console.ReadLine();
                studentName[i] = name;

                // exception handling
                int age = 0;
                bool validAge = false;
                while (!validAge)
                {
                    try
                    {
                        Console.WriteLine("Enter student Age");
                        age = int.Parse(Console.ReadLine());

                        // check  student age is greater than or equal to 21
                        if (age < 21)
                        {
                            Console.WriteLine("age must  21. Please try again.");
                        }
                        else
                        {
                            validAge = true;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("invalid input. Please enter a valid integer for age.");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Age value is too large or too small. Please enter a valid age.");
                    }
                }
                studentAge[i] = age;

                // input student mark 
                double mark = 0;
                bool validMark = false;
                while (!validMark)
                {
                    // exception handling
                    try
                    {
                        Console.WriteLine("Enter student Mark");
                        mark = double.Parse(Console.ReadLine());

                        // validate mark 
                        if (mark < 0 || mark > 100)
                        {
                            Console.WriteLine(" the mark between 0 and 100. Please try again.");
                        }
                        else
                        {
                            validMark = true;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("invalid input. Please enter a valid number for mark.");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Mark value is too large or too small. Please enter a valid mark.");
                    }
                }
                studentMark[i] = mark;

                
                dateTime[i] = DateTime.Today;
                count++;
            }

            Console.WriteLine("**** Enter **** ");


        }


        static void viewAllStudents()
        {
            // view all student data
            Console.WriteLine("######  View student Data #####\n\n");

            for (int i = 0; i < studentName.Length; i++)
            {
                Console.WriteLine($"Stuent Name {studentName[i]} student Age {studentAge[i]} student mark {studentMark[i]} Student Enrollment Date {dateTime[i]} ");
            }





        }
        static void findStudentByName()
        {
            Console.WriteLine("######  Find student Data  By Name #####\n\n");

            // find student by name
            bool found = false;
            while (!found)
            {
                try
                {
                    Console.WriteLine("Enter student Name");
                    string name = Console.ReadLine();

                    // Check  the name is empty or null
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("Student name cannot be empty.");
                        continue;
                    }

                    // search for the student by name
                    int index = Array.IndexOf(studentName, name);

                    // check if student name is found
                    if (index != -1)
                    {
                        Console.WriteLine($"Student Name: {studentName[index]}");
                        Console.WriteLine($"Student Age: {studentAge[index]}");
                        Console.WriteLine($"Student Mark: {studentMark[index]}");
                        Console.WriteLine($"Enrollment Date: {dateTime[index]}");
                        found = true; 
                    }
                    else
                    {
                        Console.WriteLine("Student Name not found.");
                    }
                }
                catch (Exception ex) // Catch any unexpected exceptions
                {
                    Console.WriteLine($" error : {ex.Message}");
                }
            }


        }



        }


        static void calculateTheClassArerage ()
        {
            Console.WriteLine("######  Calculate the class average #####\n\n");
            double number = 0,avr=0;
            // calculate the class average
            for (int i=0;i<studentMark.Length;i++)
            {
                number += studentMark[i];
            }
            avr = number / count;


            Console.WriteLine($"   Class Average  {avr}\n\n");



        }
        static void findTopProrfomingStudent()
        {
            // find the top-performing student
            int index =0 ;
            double top = 0;
            for(int i=0;i< count; i++)
            {
                if (studentMark[i] > top)
                {
                    top = studentMark[i];
                    index = i;

                }
            }

            index = Array.IndexOf(studentMark, top);
            Console.WriteLine($" student Name {studentName[index]}  student Age {studentAge[index]}   student Mark {studentMark[index]}  ");


        }

        static void sortStudentsByMark()
        {
            // sort students by marks
            Console.WriteLine("######  sort student by Mark #####\n\n");
            try
            {
                // Create an array of indices to keep track of the original positions
                int[] indices = new int[studentMark.Length];
                for (int i = 0; i < indices.Length; i++)
                {
                    indices[i] = i;
                }

                // Perform selection sort on the indices array based on student marks
                for (int i = 0; i < studentMark.Length - 1; i++)
                {
                    int maxIndex = i;
                    for (int j = i + 1; j < studentMark.Length; j++)
                    {
                        // Find the index of the student with the highest mark
                        if (studentMark[indices[j]] > studentMark[indices[maxIndex]])
                        {
                            maxIndex = j;
                        }
                    }

                    // Swap the indices
                    if (maxIndex != i)
                    {
                        int temp = indices[maxIndex];
                        indices[maxIndex] = indices[i];
                        indices[i] = temp;
                    }
                }

                // Display the sorted students
                for (int i = 0; i < indices.Length; i++)
                {
                    int currentIndex = indices[i];
                    Console.WriteLine($"Student Name: {studentName[currentIndex]}, " +
                                      $"Age: {studentAge[currentIndex]}, " +
                                      $"Mark: {studentMark[currentIndex]}");
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("error: student data is not initialized.");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("error: Index out of range.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" error : {ex.Message}");
            }
        }





        static void deleteStudentRecordAndShifiing ()
        {
            // delete a student record
            Console.WriteLine("######  delete student by Name #####\n\n");

            Console.Write("Enter student name to delete: ");
            string nameToDelete = Console.ReadLine();
            // find the index of the student to delete
            int deleteIndex = -1;
            for (int i = 0; i < studentName.Length; i++)
            {
                if (studentName[i] == nameToDelete)
                {
                    deleteIndex = i;
                    break;
                }
            }
            // if the student is not found
            if (deleteIndex == -1)
            {
                Console.WriteLine("not found");
                return;
            }

          
            string[] newNames = new string[studentName.Length - 1];
            int[] newAges = new int[studentAge.Length - 1];
            double[] newMarks = new double[studentMark.Length - 1];
            // shift the elements to the left
            for (int i = 0, j = 0; i < studentName.Length; i++)
            {
                if (i == deleteIndex)     ;

                newNames[j] = studentName[i];
                newAges[j] = studentAge[i];
                newMarks[j] = studentMark[i];
                j++;
            }

            studentName = newNames;
            studentAge = newAges;
            studentMark = newMarks;

            Console.WriteLine("Student deleted");
        }
    }
}
