using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Standart_Interfaces
{
    internal class Program
    {
        enum Genre
        {
            None = 0,
            Comedy,
            Horror,
            Adventure,
            Drama,
            Fantasy
        }

        class Director : ICloneable
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public override string ToString()
            {
                return $"{LastName} {FirstName}";
            }

            public object Clone()
            {
                return this.MemberwiseClone();
            }
        }

        class Movie : ICloneable, IComparable<Movie>
        {
            public string Title { get; set; }
            public Director Director { get; set; }
            public string Country { get; set; }

            private Genre _genre;
            public Genre Genre
            {
                get { return _genre; }
                set
                {
                    if (!System.Enum.IsDefined(typeof(Genre), value)) _genre = Genre.None;
                    else _genre = value;
                }
            }

            private int _year;
            public int Year
            {
                get { return _year; }
                set
                {
                    if (value < 1800 || value > System.DateTime.Now.Year) _year = 0;
                    else _year = value;
                }
            }

            private short _rating;
            public short Rating
            {
                get { return _rating; }
                set
                {
                    if (value < 0) _rating = 0;
                    else if (value > 10) _rating = 10; 
                    else _rating = value;
                }
            }

            public Movie(string title, Director director, string country, Genre genre, int year, short rating)
            {
                Title = title;
                Director = director;
                Country = country;
                Genre = genre;
                Year = year;
                Rating = rating;
            }

            public Movie()
            {
                Title = "Unknown";
                Director = new Director() { FirstName = "Unknown", LastName = "Unknown" };
                Country = "Unknown";
                Genre = Genre.None;
                Year = 0;
                Rating = 0;
            }

            public override string ToString()
            {
                return $"{Title} ({Year}), {Genre}, Dir: {Director}, Rate: {Rating}, Country: {Country}";
            }

            public object Clone()
            {
                Movie clonedMovie = (Movie)this.MemberwiseClone();
                clonedMovie.Director = (Director)this.Director.Clone();
                return clonedMovie;
            }

            public int CompareTo(Movie? other)
            {
                if (other == null) return 1;
                return this.Rating.CompareTo(other.Rating);
            }
        }

        class CompareByRating : IComparer<Movie>
        {
            public int Compare(Movie? x, Movie? y)
            {
                if (x == null || y == null) return 0;
                return x.Rating.CompareTo(y.Rating);
            }
        }

        class CompareByYear : IComparer<Movie>
        {
            public int Compare(Movie? x, Movie? y)
            {
                if (x == null || y == null) return 0;
                return x.Year.CompareTo(y.Year);
            }
        }

        class Cinema : IEnumerable
        {
            private Movie[] movies;
            public string Address { get; set; }

            public Cinema()
            {
                movies = new Movie[0];
                Address = "Unknown";
            }

            public Cinema(params Movie[] movies)
            {
                this.movies = new Movie[movies.Length];
                for (int i = 0; i < movies.Length; i++)
                {
                    this.movies[i] = (Movie)movies[i].Clone();
                }
            }

            public Cinema(string address, params Movie[] movies) : this(movies)
            {
                Address = address;
            }

            public IEnumerator GetEnumerator()
            {
                return movies.GetEnumerator();
            }

            public void Sort()
            {
                Array.Sort(movies);
            }

            public void Sort(IComparer<Movie> comparer)
            {
                Array.Sort(movies, comparer);
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Director kleban = new Director { FirstName = "Nazar", LastName = "Kleban" };
            Director spielberg = new Director { FirstName = "Steven", LastName = "Spielberg" };

            Movie m1 = new Movie("Inception", kleban, "USA", Genre.Fantasy, 2010, 9);
            Movie m2 = new Movie("Jaws", spielberg, "USA", Genre.Horror, 1975, 8);
            Movie m3 = new Movie("Tenet", kleban, "UK", Genre.Adventure, 2020, 7);
            Movie m4 = new Movie("Interstellar", kleban, "USA", Genre.Fantasy, 2014, 10);

            Cinema cinema = new Cinema("Kyiv, Khreshchatyk 132A", m1, m2, m3, m4);

            Console.WriteLine("--- Початковий список ---");
            foreach (Movie m in cinema)
                Console.WriteLine(m);

            Console.WriteLine("\n--- Сортування за Rating (Default Sort) ---");
            cinema.Sort();
            foreach (Movie m in cinema)
                Console.WriteLine(m);

            Console.WriteLine("\n--- Сортування за Year (використовуючи CompareByYear) ---");
            cinema.Sort(new CompareByYear());
            foreach (Movie m in cinema)
                Console.WriteLine(m);

            Console.WriteLine("\n--- Сортування за Rating (використовуючи CompareByRating) ---");
            cinema.Sort(new CompareByRating());
            foreach (Movie m in cinema)
                Console.WriteLine(m);

            Console.ReadKey();
        }
    }
}