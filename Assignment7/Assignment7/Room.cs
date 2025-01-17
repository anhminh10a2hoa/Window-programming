﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
// Json
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Assignment7
{
    [Serializable, XmlType("room"), DataContract]
    public class Room : IRoom
    {
        int area;
        string roomNumber, type, description;
        double price;
        [XmlElement("roomNumber"), DataMember]
        public string RoomNumber
        {
            get
            {
                return this.roomNumber;
            }
            set
            {
                this.roomNumber = value;
            }
        }
        [XmlElement("area"), DataMember]
        public int Area
        {
            get
            {
                return this.area;
            }
            set
            {
                this.area = value;
            }
        }
        [XmlElement("type"), DataMember]
        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }
        [XmlElement("description"), DataMember]
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }
        [XmlElement("price"), DataMember]
        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }

        public Room(string roomNumber, int area, string type, double price, string description)
        {
            this.roomNumber = roomNumber;
            this.area = area;
            this.type = type;
            this.price = price;
            this.description = description;
        }

        public Room() { }

        public void WriteToFile(BinaryWriter binaryWriter)
        {
            try
            {
                binaryWriter.Write(roomNumber);
                binaryWriter.Write(area);
                binaryWriter.Write(type);
                binaryWriter.Write(price);
                binaryWriter.Write(description);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error writting");
            }
        }

        public void ReadFromFile(BinaryReader binaryReader)
        {
            try
            {
                roomNumber = binaryReader.ReadString();
                area = binaryReader.ReadInt32();
                type = binaryReader.ReadString();
                price = binaryReader.ReadDouble();
                description = binaryReader.ReadString();
            }
            catch (IOException)
            {
                Console.WriteLine("Error reading");
            }
        }

        public string WriteTextToFile(TextWriter textWriter)
        {
            StringBuilder result = new StringBuilder();
            try
            {
                textWriter.WriteLine(this.ToString());
                textWriter.Close();
            }
            catch (FileNotFoundException)
            {
                result.Append(" not found!");
            }
            catch (IOException)
            {
                result.Append("Error writing to file: ");
            }
            return result.ToString();
        }
        public override string ToString()
        {
            string res = "";
            res += "\nRoom number: " + this.roomNumber + "\n";
            res += "Area: " + this.area + " m2\n";
            res += "Type: " + this.type + "\n";
            res += "Price: " + this.price + "\n";
            res += "Description: " + this.description + "\n";
            return res;
        }
    }
}