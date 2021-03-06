﻿namespace Übung.Types
{
    public class Person
    {
        /// <inheritdoc />
        public Person (string vorname, string name, int alter)
        {
            Vorname = vorname;
            Name = name;
            Alter = alter;
        }

        public string Vorname { get; set; }
        public string Name { get; set; }
        public int Alter { get; set; }
    }
}