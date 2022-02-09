using System;
using System.Linq;

namespace cs24_paskaita_Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("cs24_PASKAITA_Generics!");
            #region TEORIJA - GENERICS

            //
            // To decouple data type from logic - labai gerai pernaudojamumui
            //

            #endregion

            #region Dėstytojo PVZ
            ShowItem("Labas");

            var human = new Human("Vardas", "Pavardė");

            //ShowItem(Human);

            var list = new MyList<double>();

            for (double i = 0; i < 10000; i++)
            {
                list.AddElement(i);
            }
            #endregion

            //Valditation<string>(null);
            Valditation.Validate<string>(null); // <-- Problem1
            Validation2<string>.Validate2(null); // <-- Problem1(2)

            TwoParameters.ShowValues<string, decimal>("Obuolys", 100m);  // <-- Problem2

            var MyList = new MySelfMadeList<double>();
            MyList.AddElement(10d);
            MyList.AddElement(15d);
            MyList.AddElement(20d);
            MyList.AddElement(25d);
            MyList.AddElement(30d);

            MyList.PrintList();

            //MyList.RemoveElement(1, 0); // <-- LABAI blogai, nors funkciją kind-of atlieka, bet čia reikia for'ą prasileisti kažkaip
            MyList.RemoveElementAt(2);

            MyList.PrintList();


        }
        #region Dėstytojo PVZ
        public static void ShowItem<T>(T input)
        {
            Console.WriteLine(input);
            Console.WriteLine(input.GetType().Name);
        }

        public class Human
        {
            public string Name;
            public string LastName;

            public Human(string name, string lastName)
            {
                Name = name;
                LastName = lastName;
            }
            public override string ToString()
            {
                return $"{Name} {LastName}";
            }
        }

        public class MyList<T>
        {
            private T[] Array;
            private int Index = 0;
            private int Size = 10;

            public MyList()
            {
                Array = new T[Size];
            }

            public void AddElement(T elementToAdd)
            {
                if (CheckIfFull())
                    Array = IncreseListSize();
                if (elementToAdd != null)
                {
                    Array[Index] = elementToAdd;
                    Index++;
                }
                else
                {
                    throw new NullReferenceException(nameof(elementToAdd));
                }
            }

            public bool CheckIfFull()
            {
                return Index == Size;
            }

            public T[] IncreseListSize()
            {
                Size += Size / 2;
                var newArray = new T[Size];
                Array.CopyTo(newArray, 0);
                return newArray;
            }
        }
        #endregion

        #region Problem1
        // Sukurkite generic klasę Validation, kuri turėtų funckciją Validate
        // Validate Funkcijos paskirtis būtų patikrinti ar perduotas paramentras yra null
        // Jeigu jis yra null tai išmestų error’ą

        //Papildykite pirmosios užduoties programą taip, kad validation klasės inicializuoti nereikėtų
        //Būtų galima tiesiog iškviesti metodą validate
        //Validation.Validate<String>(null)
        public class Valditation
        {
            public static void Validate<T>(T Input)
            {
                Console.WriteLine(); // <-- Tarpas;
                if (Input == null)
                {
                    Console.WriteLine($"Input is null");
                    //throw new NullReferenceException($"Input is null");

                    // A NullReferenceException exception is thrown when you try
                    // to access a member on a type whose value is null .
                    // A NullReferenceException exception typically reflects
                    // developer error and is thrown in the following scenarios:
                    // You've forgotten to instantiate a reference type.
                }
                else
                {
                    Console.WriteLine($"Įvesta reikšmė {Input}");
                }
            }
        }
        public class Validation2<T> // Nežinau aš ką aš čia padariau
        {
            public static void Validate2(T Input)
            {
                Console.WriteLine(); // <-- Tarpas;
                if (Input == null)
                {
                    Console.WriteLine($"Input2 is null");
                    //throw new NullReferenceException($"Input is null");

                    // A NullReferenceException exception is thrown when you try
                    // to access a member on a type whose value is null .
                    // A NullReferenceException exception typically reflects
                    // developer error and is thrown in the following scenarios:
                    // You've forgotten to instantiate a reference type.
                }
                else
                {
                    Console.WriteLine($"Įvesta 2 reikšmė {Input}");
                }
            }
        }
        #endregion

        #region TEORIJA2 - GENERICS

        //
        // Using objects results in cast operations;
        // Generics are faster and more elegant;
        // Generics are faster and errors are visible at compile-time;

        #endregion

        #region Problem2
        // Type T paramentrai gali būti nurodyti ne tik vienas, pvz ShowValues<T1, T2>
        // Sukurkite funckciją, kuri prašo nurodyti 2 generic tipus
        // Per parametrus pasiima 2 kintamuosius vieną pirmojo generic tipo, antrą antrojo generic tipo
        // Juos abu išspausdinti į konsolę

        public class TwoParameters
        {
            public static void ShowValues<T1, T2>(T1 Input, T2 Input2)
            {
                Console.WriteLine($"Pirmasis kintamasis: {Input}, jo tipas yra {Input.GetType()} tipo");
                Console.WriteLine($"Antrasis kintamasis: {Input2}, jo tipas yra {Input2.GetType()} tipo");
            }
        }
        #endregion

        #region Problem3
        //Papildykite pavyzdinę "MySelfCreatedList" klasę metodu ištrinti elementą iš masyvo.

        public class MySelfMadeList<T>
        {
            private T[] Array;
            private int Index = 0;
            private int Size = 10;

            public MySelfMadeList()
            {
                Array = new T[Size];
            }

            public void AddElement(T elementToAdd)
            {
                if (CheckIfFull())
                    Array = IncreseListSize();
                if (elementToAdd != null)
                {
                    Array[Index] = elementToAdd;
                    Index++;
                }
                else
                {
                    throw new NullReferenceException(nameof(elementToAdd));
                }
            }

            public bool CheckIfFull()
            {
                return Index == Size;
            }

            public T[] IncreseListSize()
            {
                Size += Size / 2;
                var newArray = new T[Size];
                Array.CopyTo(newArray, 0);
                return newArray;
            }

            public void RemoveElement(int index, T value)
            {
                Array[index] = value;   
            }
            public bool CheckIfEqual(int index, int i)
            {
                return (i == index);
            }
            public T[] RemoveElementAt(int index)
            {
                var newArray = new T[Size];
                int j = 0;
                for (int i = 0; i < Array.Length; i++)
                {
                    if (CheckIfEqual(index-1, i))
                    {
                        continue;
                    }
                    else
                    {
                        newArray[j] = Array[i];
                        j++;
                    }
                }
                newArray.CopyTo(Array, 0);
                return Array;
            }

            public void PrintList()
            {
                foreach (var item in Array)
                {
                    Console.WriteLine(item);
                }
            }
        }
        #endregion
    }
}

