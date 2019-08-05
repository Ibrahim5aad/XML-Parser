using System;
using System.Collections.Generic;
using System.Xml;
using System.Text.RegularExpressions;
using OpenTK;
using OpenGL;

namespace XMLParser
{
    class ExtractElements
    {


        public static List<Edge> NodesToEdges(XmlNodeList nods)
        {
            List<Edge> edgesf = new List<Edge>();
            foreach (XmlNode edge in nods)
            {

                string id = edge.Attributes["Id"].Value;
                string uv0 = edge.Attributes["uv0"].Value;
                string uv1 = edge.Attributes["uv1"].Value;
                int Id = Int32.Parse(id);

                MatchCollection matches0 = Regex.Matches(uv0, @"-?\d+\.?\d+");
                double X0 = Convert.ToDouble(matches0[0].Value);
                double Y0 = Convert.ToDouble(matches0[1].Value);

                PointD UV0 = new PointD(X0, Y0);


                MatchCollection matches1 = Regex.Matches(uv1, @"-?\d+\.?\d+");
                Double X1 = Convert.ToDouble(matches1[0].Value);
                Double Y1 = Convert.ToDouble(matches1[1].Value);

                PointD UV1 = new PointD(X1, Y1);


                Edge edge_ = new Edge(Id, UV0, UV1);
                edgesf.Add(edge_);

            }

            return edgesf;
        }

        public List<Element> Start()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load("Data.xml");  /// XML file path in the debug folder

            XmlNode root = doc.DocumentElement;

            XmlNodeList elementList = root.SelectNodes("//Element");
            List<Element> elements = new List<Element>();

            foreach (XmlNode elem in elementList)
            {
                XmlNodeList faceList = elem.SelectNodes(".//Face");
                XmlNodeList transform = elem.SelectNodes(".//Transform");
                string id = elem.Attributes["Id"].Value;
                int Id = Int32.Parse(id);

                if (transform.Count > 0)
                {

                    MatchCollection positions = Regex.Matches(transform[0].InnerText, @"-?\d+\.?\d+");
                    double X = Convert.ToDouble(positions[9].Value);
                    double Y = Convert.ToDouble(positions[10].Value);
                    double Z = Convert.ToDouble(positions[11].Value);
                    List<float> arr = new List<float>();

                    foreach (Match i in positions) {
                        float pp = (float)Convert.ToDouble(i.Value);
                        arr.Add(pp);
                    };


                   

                    OpenTK.Matrix4 trans = new OpenTK.Matrix4(
                        1, 0, 0, arr[9],
                        0, 1, 0, arr[10],
                        0, 0, 1, arr[11],
                        0, 0, 0, 1

                        );

                    OpenTK.Matrix4 scale = new OpenTK.Matrix4(
                        arr[0], arr[3], arr[6], 0,
                        arr[1], arr[4], arr[7], 0,
                        arr[2], arr[5], arr[9], 0,
                        0, 0, 0, 1

                        );

                    
                    Transform transform1 = new Transform(trans, scale);
                    List<Face> faces = new List<Face>();

                    int j = 0;

                    for (int i = 0; i < faceList.Count; i++)
                    {

                        string idf = faceList[i].Attributes["Id"].Value;
                        int Idf = Int32.Parse(idf);
                        XmlNodeList faceEdges = faceList[i].SelectNodes(".//Edge");
                        List<Edge> edgesConverted = NodesToEdges(faceEdges);
                        Face face_ = new Face(Idf, edgesConverted);
                        faces.Add(face_);

                        Element element = new Element(Id, faces, transform1);

                        elements.Add(element);
                    }
                        
                }
            };

            
            return elements;
        }
    }
}
