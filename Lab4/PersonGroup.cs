

namespace Lab4
{
    public class PersonGroup
    {
        public List<Person> Persons { get; set; } = new List<Person>();

        public char? StartingLetter {
            get {
                // if Persons is SORTED
                return Persons[0].FirstName[0];
            }
        }

        // TODO
        public char? EndingLetter {
            get {
                return Persons[Count - 1].LastName[-1];
            } 
        }

        public int Count => Persons.Count;

        public Person this[int i]
        {
            get
            {
                if (Persons == null)
                    throw new NullReferenceException("Persons is null");

                if (i < 0 || i > Persons.Count)
                    throw new IndexOutOfRangeException();

                Persons.Sort();
                return Persons[i];
            }
        }

        public PersonGroup(List<Person>? persons = null)
        {
            if( persons != null)
            {
                foreach(var p in persons)
                {
                    Persons.Add(p);
                }
            }

            Persons.Sort();
        }

        public override string ToString()
        {
            return "[" + String.Join(", ", Persons)+ "]";
        }


        // TODO
        public static List<PersonGroup> GeneratePersonGroups(List<Person> persons, int distance)
        {
            var personGroups = new List<PersonGroup>();
            persons.Sort();

            var currentGroup = new PersonGroup();

            foreach (var person in persons)
            {
                if (currentGroup.Count == 0)
                {
                    currentGroup.Persons.Add(person);
                }

                else if (person.Distance(person) <= distance)
                {
                    currentGroup.Persons.Add(person);
                }

                else
                {
                    personGroups.Add(currentGroup);

                    var newGroup = new List<Person>
                    {
                        person
                    };

                    GeneratePersonGroups(newGroup, distance);
                }
            }

            return personGroups;
        }
    }

}

