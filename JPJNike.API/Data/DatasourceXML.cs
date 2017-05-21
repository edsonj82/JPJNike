using JPJNike.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JPJNike.API.Data
{
    public class DatasourceXML
    {
        private List<Corrida> _corridas;
        private bool loaded;

        public List<Corrida> Corridas
        {
            get
            {
                return _corridas;
            }
        }

        public DatasourceXML()
        {
            LoadData();
        }

        public void LoadData()
        {
            if (!loaded)
            {
                XDocument xml = XDocument.Load("corridasjpj.xml");

                IEnumerable<XElement> corridasXML = xml
                    .Root
                    .Elements("Corrida");

                _corridas = new List<Corrida>();
                foreach (XElement nodeXml in corridasXML)
                {
                    _corridas.Add(new Corrida
                    {
                        Id = (int)nodeXml.Attribute("id"),
                        Distancia = (double)nodeXml.Attribute("distancia"),
                        TempoMinutos = (int)nodeXml.Attribute("tempoMinutos"),
                        TempoSegundos = (int)nodeXml.Attribute("tempoSegundos"),
                        Data = Convert.ToDateTime((string)nodeXml.Attribute("data"))
                    });
                }

                loaded = true;
            }
        }
    }
}
