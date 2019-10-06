using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Datos.Entidades
{
    public class Inventario
    {
        int _id;
        int _idDepa;
        Char _internet;
        int _baño;
        int _dormitorio;
        int _tv;
        int _mesa;
        int _asiento;
        int _mueble;

        public int Id { get => _id; set => _id = value; }
        public int IdDepa { get => _idDepa; set => _idDepa = value; }
        public char Internet { get => _internet; set => _internet = value; }
        public int Baño { get => _baño; set => _baño = value; }
        public int Dormitorio { get => _dormitorio; set => _dormitorio = value; }
        public int Tv { get => _tv; set => _tv = value; }
        public int Mesa { get => _mesa; set => _mesa = value; }
        public int Asiento { get => _asiento; set => _asiento = value; }
        public int Mueble { get => _mueble; set => _mueble = value; }

        public Inventario()
        {
            Init();
        }

        public void Init()
        {
            Id = 0;
            IdDepa = 0;
            Internet = '\0';
            Baño = 0;
            Dormitorio = 0;
            Tv = 0;
            Mesa = 0;
            Asiento = 0;
            Mueble = 0;
        }


    }
}
