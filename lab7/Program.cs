using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Reflection;
using AnimalsLib;

namespace Csh_lab07
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assemb = Assembly.Load(new AssemblyName("AnimalsLib"));
            Attribute userAttr = assemb.GetCustomAttribute(typeof(CommentAttribute));
            XDocument xDoc = new XDocument();
            XElement ClassElems = new XElement("Classes");
            XElement OtherElems = new XElement(assemb.GetName().Name);

            foreach (Type assembElems in assemb.ExportedTypes)
            {
                Type elemType = assemb.GetType($"AnimalsLib.{assembElems.Name}");

                if (assembElems.IsAbstract)
                {
                    XElement mainClass = new XElement($"{assembElems.Name}");
                    ClassElems.Add(mainClass);
                }

                if ((assembElems.Name != "CommentAttribute") && assembElems.IsClass && !assembElems.IsAbstract)
                {
                    XElement tempElement = new XElement($"{assembElems.Name}");
                    var objectType = elemType.GetTypeInfo();


                    string commentsNames = "";
                    foreach (Attribute comment in objectType.GetCustomAttributes())
                    {
                        if (comment is CommentAttribute animalComment)
                        {
                            commentsNames = animalComment.Comment;
                        }
                    }
                    XAttribute comments = new XAttribute("Attribute", commentsNames);
                    //XElement comments = new XElement("Attribute", commentsNames);

                    string fieldsNames = " ";
                    foreach(var classField in assembElems.GetFields())
                    {
                        fieldsNames += $"{classField.Name} ";
                    }
                    XElement fields = new XElement("Field", fieldsNames);

                    string propsNames = " ";
                    foreach (var property in assembElems.GetProperties())
                    {
                        propsNames += $"{property.Name} ";
                    }
                    XElement properties = new XElement("Proporties", propsNames);

                    string mathodsNames = " ";
                    foreach(var method in assembElems.GetMethods())
                    {
                        if (method.Name.Substring(0, 3) != "get" && method.Name.Substring(0, 3) != "set")
                        {
                            if (method.Name != "Equals" && method.Name != "GetHashCode" && method.Name != "GetType" && method.Name != "ToString")
                            {
                                mathodsNames += $"{method.Name} ";
                            }
                            //mathodsNames += $"{method.Name} ";
                        }
                            
                    }
                    XElement methods = new XElement("Methods", mathodsNames); 


                    tempElement.Add(comments);
                    tempElement.Add(fields);
                    tempElement.Add(properties);
                    tempElement.Add(methods);
                    ClassElems.Add(tempElement);
                }

                if (assembElems.IsEnum)
                {
                    XElement allEnums = new XElement($"{assembElems.Name}");
                    string enums = " ";
                    foreach(var enumElem in assembElems.GetEnumNames())
                    {
                        enums += $"{enumElem} ";
                    }
                    allEnums.Add(enums);
                    OtherElems.Add(allEnums);
                }
                /*
                if(assembElems.Name == "CommentAttribute")
                {
                    XElement tempElement = new XElement($"{assembElems.Name}");
                    string fieldsNames = " ";
                    foreach (var classField in assembElems.GetFields())
                    {
                        fieldsNames += $"{classField.Name} ";
                    }
                    XElement fields = new XElement("Field", fieldsNames);
                    string propsNames = " ";
                    foreach (var property in assembElems.GetProperties())
                    {
                        propsNames += $"{property.Name} ";
                    }
                    XElement properties = new XElement("Proporties", propsNames);
                    string mathodsNames = " ";
                    foreach (var method in assembElems.GetMethods())
                    {
                        if (method.Name.Substring(0, 3) != "get" && method.Name.Substring(0, 3) != "set")
                        {
                            if (method.Name != "Equals" && method.Name != "GetHashCode" && method.Name != "GetType" && method.Name != "ToString")
                            {
                                mathodsNames += $"{method.Name} ";
                            }
                            //mathodsNames += $"{method.Name} ";
                        }
                    }
                    XElement methods = new XElement("Methods", mathodsNames);
                    tempElement.Add(fields);
                    tempElement.Add(properties);
                    tempElement.Add(methods);
                    OtherElems.Add(tempElement);
                }
                */
            }
            OtherElems.Add(ClassElems);
            xDoc.Add(OtherElems);
            xDoc.Save("MyX.xml");
        }
    }
}
