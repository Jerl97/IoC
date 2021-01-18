using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.Composition;

namespace DattaJuan
{
    [Export(typeof(IGrabador))]
    public class Persistencia : IGrabador
    {
        public bool Grabar(Estudiante estudiante)
        {
            try
            {
                estudiante.EstudianteId = new Random().Next(1000, 9999);
                var data = string.Format("{{\"EstudianteId\":{0},\"Nombre\":\"{1}\",\"Apellido\":\"{2}\"}}"
                    , estudiante.EstudianteId.ToString()
                    , estudiante.Nombre
                    , estudiante.Apellido);
                System.IO.File.AppendAllLines("Data.json",
                    new List<string>
                    {
                        data
                    },
                    Encoding.UTF8);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}