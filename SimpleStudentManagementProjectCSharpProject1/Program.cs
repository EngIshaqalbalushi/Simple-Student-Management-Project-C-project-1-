using System;
using System.Dynamic;

namespace SimpleStudentManagementProjectCSharpProject1
{
    internal class Program
    {

         static string[] studentName =new string[2];
         static int[] studentAge = new int[2];
         static  double[] studentMark = new double[2];
         static DateTime[] dateTime = new DateTime[2];
         static int count = 0;



        static void Main(string[] args)
        {




            while (true)
            {
                Console.Clear();
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

            for(int i = 0; i < studentName.Length; i++)
            {
                Console.WriteLine("Enter student Name");
                string name = Console.ReadLine();

                studentName[i] = name;

             
                Console.WriteLine("Enter student Age");
                int age = int.Parse(Console.ReadLine());


                if (age < 21)
                {
                    Console.WriteLine(" validated");

                   while (age < 21)
                    {
                        Console.WriteLine("Enter student Age");
                        int age2 = int.Parse(Console.ReadLine());

                        age = age2;
                        
                        

                    }

                }
                    studentAge[i] = age;





                Console.WriteLine("Enter student Mark");
                double mark = double.Parse(Console.ReadLine());

                studentMark[i] = mark;


                DateTime time = DateTime.Today;
                dateTime[i] = time;

                count++;


            }

              Console.WriteLine("**** Enter **** ");


            //for (int i = 0; i < studentName.Length; i++)
            //{
            //    Console.WriteLine($"Stuent Name {studentName[i]} student Age {studentAge[i]} student mark {studentMark[i]} Student Enrollment Date {dateTime[i]} ");
            //}




        }
        static void viewAllStudents()
        {

            Console.WriteLine("######  View student Data #####\n\n");

            for (int i = 0; i < studentName.Length; i++)
            {
                Console.WriteLine($"Stuent Name {studentName[i]} student Age {studentAge[i]} student mark {studentMark[i]} Student Enrollment Date {dateTime[i]} ");
            }





        }
        static void findStudentByName()
        {
            Console.WriteLine("######  Find student Data  By Name #####\n\n");


            int index = 0;
            for (int i = 0; i < studentName.Length; i++)
            {
                Console.WriteLine("Enter student Name");
                string name = Console.ReadLine();

                index = Array.IndexOf(studentName, name);
               
                
                if (index!=-1)
                {

                    Console.WriteLine($" student Name {studentName[index]}  student Age {studentAge[index]}   student Mark {studentMark[index]}  ");



                }
                else
                {
                    Console.WriteLine(" student Name not found");

                }


            }



        }


        static void calculateTheClassArerage ()
        {
            Console.WriteLine("######  Calculate the class average #####\n\n");
            double number = 0,avr=0;
            
            for(int i=0;i<studentMark.Length;i++)
            {
                number += studentMark[i];
            }
            avr = number / count;


            Console.WriteLine($"   Class Average  {avr}\n\n");



        }
        static void findTopProrfomingStudent()
        {
            int index=0 ;
            double top = 0;
            for(int i=0;i<studentMark.Length;i++)
            {
                if (studentMark[i] > top)
                {
                    top = studentMark[i]
                    ;
                }else
                {
                    top = top;
                }
            }

            index = Array.IndexOf(studentMark, top);
            Console.WriteLine($" student Name {studentName[index]}  student Age {studentAge[index]}   student Mark {studentMark[index]}  ");


        }

        static void sortStudentsByMark()
        {

            Console.WriteLine("######  sort student by Mark #####\n\n");
            int[] indices = new int[studentMark.Length];
            for (int i = 0; i < indices.Length; i++)
            {
                indices[i] = i;
            }

          
            for (int i = 0; i < studentMark.Length - 1; i++)
            {
               
                int maxIndex = i;
                for (int j = i + 1; j < studentMark.Length; j++)
                {
                    if (studentMark[indices[j]] > studentMark[indices[maxIndex]])
                    {
                        maxIndex = j;
                    }
                }

             
                int temp = indices[maxIndex];
                indices[maxIndex] = indices[i];
                indices[i] = temp;
            }

           
            for (int i = 0; i < indices.Length; i++)
            {
                int currentIndex = indices[i];
                Console.WriteLine($"Student Name: {studentName[currentIndex]}, " +
                                  $"Age: {studentAge[currentIndex]}, " +
                                  $"Mark: {studentMark[currentIndex]}");
            }
        }





        static void deleteStudentRecordAndShifiing ()
        {

            Console.WriteLine("######  delete student by Name #####\n\n");

            Console.Write("Enter student name to delete: ");
            string nameToDelete = Console.ReadLine();

            int deleteIndex = -1;
            for (int i = 0; i < studentName.Length; i++)
            {
                if (studentName[i] == nameToDelete)
                {
                    deleteIndex = i;
                    break;
                }
            }

            if (deleteIndex == -1)
            {
                Console.WriteLine("not found");
                return;
            }

          
            string[] newNames = new string[studentName.Length - 1];
            int[] newAges = new int[studentAge.Length - 1];
            double[] newMarks = new double[studentMark.Length - 1];

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
