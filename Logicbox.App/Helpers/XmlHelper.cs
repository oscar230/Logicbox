﻿using System.Xml.Serialization;

namespace Logicbox.App.Helpers
{
    internal static class XmlHelper
    {
        internal static T Deserialize<T>(Stream stream) where T : class
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            T? obj = serializer.Deserialize(stream) as T;
            return obj ?? throw new Exception($"Could not deserialize to type {typeof(T)}.");
        }

        internal static T Deserialize<T>(FileInfo fileInfo) where T : class
        {
            if (!fileInfo.Exists)
            {
                throw new FileNotFoundException($"File {fileInfo.Name} does not exist.");
            }
            if (fileInfo.Length.Equals(0))
            {
                throw new FileLoadException($"File {fileInfo.Name} is of zero length.");
            }
            Stream stream = new FileStream(fileInfo.FullName, FileMode.Open);
            return Deserialize<T>(stream);
        }

        internal static T Deserialize<T>(string fileName) where T : class => Deserialize<T>(new FileInfo(fileName));
    }
}