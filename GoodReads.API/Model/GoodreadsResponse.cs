﻿using System.Xml.Serialization;

namespace GoodReads.API.Model
{
    [XmlRoot(ElementName = "GoodreadsResponse")]
    public class GoodreadsResponse
    {
        [XmlElement(ElementName = "Request")]
        public Request Request { get; set; }

        [XmlElement(ElementName = "updates")]
        public Updates Updates { get; set; }

        [XmlElement(ElementName = "search")]
        public Search Search { get; set; }

        [XmlElement(ElementName = "user")]
        public User User { get; set; }

        [XmlElement(ElementName = "shelves")]
        public Shelves Shelves { get; set; }

        [XmlElement(ElementName = "reviews")]
        public Reviews Reviews { get; set; }

        [XmlElement(ElementName = "book")]
        public Book Book { get; set; }

        [XmlElement(ElementName = "author")]
        public Author Author { get; set; }

        [XmlElement(ElementName = "notifications")]
        public Notifications Notifications { get; set; }

        [XmlElement(ElementName = "user_status")]
        public UserStatus UserStatus { get; set; }
    }
}
