
using AutoMapper;
using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TestWebApi
{
    public class PersonTypeConverter : JsonConverter<Person>
    {
        enum TypeDiscriminator
        {
            Person = 0,
            Doctor = 1,
            Student = 2
        }

        public override bool CanConvert(Type typeToConvert) =>
            typeof(Person).IsAssignableFrom(typeToConvert);

        public override Person Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            reader.Read();
            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }

            string propertyName = reader.GetString();
            if (propertyName != "TypeDiscriminator")
            {
                throw new JsonException();
            }

            reader.Read();
            if (reader.TokenType != JsonTokenType.Number)
            {
                throw new JsonException();
            }

            TypeDiscriminator typeDiscriminator = (TypeDiscriminator)reader.GetInt32();
            Person person = typeDiscriminator switch
            {
                TypeDiscriminator.Person => new Person(),
                TypeDiscriminator.Doctor => new Doctor(),
                TypeDiscriminator.Student => new Student(),
                _ => throw new JsonException()
            };

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return person;
                }

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    propertyName = reader.GetString();
                    reader.Read();
                    switch (propertyName.ToUpper())
                    {
                        case "HOSPITALNAME":
                            string hname = reader.GetString();
                            ((Doctor)person).HospitalName = hname;
                            break;
                        case "SCHOOLNAME":
                            string sname = reader.GetString();
                            ((Student)person).SchoolName = sname;
                            break;
                        case "FIRSTNAME":
                            string fname = reader.GetString();
                            person.FirstName = fname;
                            break;
                        case "LASTNAME":
                            string lname = reader.GetString();
                            person.LastName = lname;
                            break;
                    }
                }
            }

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, Person person, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            if (person is Student customer)
            {
                writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.Student);
                writer.WriteString("schoolName", customer.SchoolName);
            }
            else if (person is Doctor employee)
            {
                writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.Doctor);
                writer.WriteString("hospitalName", employee.HospitalName);
            }

            writer.WriteString("FirstName", person.FirstName);
            writer.WriteString("LastName", person.LastName);

            writer.WriteEndObject();
        }
    }
}

//[{
//	"TypeDiscriminator":0,
//    "firstName": "Mike",
//    "lastName": "Li"
//}, {
//	"TypeDiscriminator":2,
//    "firstName": "Stephie",
//    "lastName": "Wang",
//    "schoolName": "No.15 Middle School"
//}, {
//	"TypeDiscriminator":1,
//    "firstName": "Jacky",
//    "lastName": "Chen",
//    "hospitalName": "Center Hospital"
//}]