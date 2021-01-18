using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.Composition;

namespace DAL
{
    //[Export(typeof(IGrabador))]
    public class PersistenciaCsv : IGrabador
    {
        public bool Grabar(Estudiante estudiante)
        {
            try
            {
                estudiante.EstudianteId = new Random().Next(1000, 9999);
                System.IO.File.AppendAllLines("Data.csv",
                    new List<string>
                    {
                    string.Format("{0},{1},{2}"
                    ,estudiante.EstudianteId
                    ,estudiante.Nombre
                    ,estudiante.Apellido)
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