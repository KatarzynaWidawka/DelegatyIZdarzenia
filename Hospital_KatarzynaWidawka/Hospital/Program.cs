using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Hospital
{
   

    class Program
    {
        #region Zadanie 1

        
        #endregion
        public delegate void Delegata(int a, int b);
  
        public static void Method(int x, int y)
        {
            Console.WriteLine("Wartość metody Method:{0}, {1}", x, y);
        }

        public static void Method2(int x2, int y2)
        {
            Console.WriteLine("Wartość metody Method:{0}, {1}", x2, y2);
        }
        
        #region Zadanie 2

      class Person
      {
          public int Id { get; set; }

          public Person(int Id)
          {
              this.Id = Id;
          }
          public override string ToString()
          {
              return string.Format("Id osoby: {0}",Id);
          }


          
      }

        class PersonGenerator
        {
            private Random r;
            public delegate void Delegata(Person p);
            public event Delegata Zdarzenie;

            public PersonGenerator ()
            {
                this.r = new Random();
            }

            public void Generate()
            {
                while(true)
                {
                    var p = new Person(r.Next());
                    if(Zdarzenie!=null )
                    {
                        Zdarzenie(p);
                    }
                    
                }
                System.Threading.Thread.Sleep(1000); //ms 
                
            }
        }
        #endregion

        #region Program główny - testy
       
        static void Main(string[] args)
        {
            {
                // Zadanie 2 
                Delegata d = new Delegata(Method);
                d(2, 2);
                
                Console.WriteLine("Wartość właściwości metod: {0}", d.Method); 
                d += Method2;
                Console.WriteLine("Usunięcie Method, wyświetlenie Method2:");
                d -= Method;
                d(1, 2);
                Console.WriteLine(d.Method);

                PersonGenerator pg = new PersonGenerator();
                pg.Zdarzenie += Wyswietl;
                pg.Generate();
               
                

            }
            Console.ReadKey();
        }

       

        //Zadanie 2 
        static void Wyswietl(Person p)
        {
            DateTime dt = DateTime.Now;
            Console.WriteLine(dt.ToString(System.Globalization.CultureInfo.InvariantCulture));
            Console.WriteLine(p);
        }
       
        

        #endregion
        
        
   
        #region Zadanie 3

        class PatientInfo
        {
            public List<string> InterventionList { get; private set; }
            public PatientInfo()
            {
                this.InterventionList = new List<string>();
            }
        }
        class Patient
        {
            //...
            private PatientInfo patient;
            public Patient(PatientInfo patient)
            {
                this.patient = patient;
            }
            //...

            //...
            public void ShowState()
            {
                //...
                foreach (var i in patient.InterventionList)
                {
                    Console.WriteLine(i);
                }
            }
        }
        class Hospital
        {
            private Random r;
            private Patient patient;
            public Hospital(Patient patient)
            {
                this.patient = patient;
                this.r = new Random();
            }
            public void Simulate()
            {
                //...
                patient.ShowState();
            }

            private void AddPacjent(PatientInfo patient)
            { patient.InterventionList.Add("Pacjent zarejestrowny!"); }
            private void RemovePacjent(PatientInfo patient)
            { patient.InterventionList.Add("Pacjent wypisany!"); }
            private void RTG(PatientInfo patient)
            { patient.InterventionList.Add("Pacjent poddany został badaniu RTG!"); }
            private void CT(PatientInfo patient)
            { patient.InterventionList.Add("Pacjent poddany został badaniu CT"); }
            private void MRI(PatientInfo patient)
            { patient.InterventionList.Add("Pacjent poddany został badaniu MRI"); }
        }
    }
        #endregion
}